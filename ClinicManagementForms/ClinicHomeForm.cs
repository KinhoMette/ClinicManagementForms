using ClinicManagementForms.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementForms
{
    public partial class ClinicHomeForm : ClinicBase
    {
        public ClinicHomeForm()
        {
            InitializeComponent();
        }

        private BindingList<Consulta> consultas = new BindingList<Consulta>();
        private SqlConnection cn;
        private DateTime dataSelecionada;

        private void ClinicHomeForm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=NOTEDESADM139\SQLEXPRESS;Initial Catalog=ClinicManegement;Integrated Security=true");
            cn.Open();

            // Vincula a lista de consultas à DataGridView
            dataGridView1.DataSource = consultas;

            // Configuração das colunas da DataGridView
            dataGridView1.AutoGenerateColumns = false;

            // Adiciona colunas para exibir as propriedades do paciente

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nome",
                DataPropertyName = "Paciente.Nome"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Contato Telefônico",
                DataPropertyName = "Paciente.ContatoTelefonico"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Data de Nascimento",
                DataPropertyName = "Paciente.DataNascimento"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Email",
                DataPropertyName = "Paciente.Email"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Endereço",
                DataPropertyName = "Paciente.Endereco"
            });

            RemoveColunas();

            // Atualiza a exibição
            // Assina o evento CellFormatting para formatar as células do paciente
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            DateRangeEventArgs args = new DateRangeEventArgs(dataSelecionada, dataSelecionada); // Crie os argumentos do evento
            calendario_DateChanged(calendario, args); // Chame o método associado ao evento
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verifica se a célula pertence à coluna do paciente
                if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.StartsWith("Paciente"))
                {
                    var consulta = dataGridView1.Rows[e.RowIndex].DataBoundItem as Consulta;
                    if (consulta != null && consulta.Paciente != null)
                    {
                        var paciente = consulta.Paciente;
                        switch (dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Replace("Paciente.", ""))
                        {
                            case "Nome":
                                e.Value = paciente.Nome;
                                break;

                            case "ContatoTelefonico":
                                e.Value = paciente.ContatoTelefonico;
                                break;

                            case "DataNascimento":
                                e.Value = paciente.DataNascimento;
                                break;

                            case "Email":
                                e.Value = paciente.Email;
                                break;

                            case "Endereco":
                                e.Value = paciente.Endereco;
                                break;
                        }
                    }
                }
            }
        }

        private void btn_cancelarConsulta_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente cancelar essa consulta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Consulta consulta = dataGridView1.SelectedRows[0].DataBoundItem as Consulta;

                    string comandoSql = "Delete from Consulta where id = @id";

                    using (SqlCommand command = new SqlCommand(comandoSql, cn))
                    {
                        command.Parameters.AddWithValue("@id", consulta.Id);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma linha selecionada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DateRangeEventArgs args = new DateRangeEventArgs(dataSelecionada, dataSelecionada); // Crie os argumentos do evento
            calendario_DateChanged(calendario, args); // Chame o método associado ao evento
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            consultas.Clear();

            dataSelecionada = calendario.SelectionStart;

            var cmd = new SqlCommand($"SELECT * FROM consulta a INNER JOIN Paciente b ON a.idPaciente = b.id WHERE CONVERT(date, a.data) = '{dataSelecionada.Date}'", cn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Adiciona uma nova consulta com um paciente
                Consulta consulta = new Consulta
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Data = Convert.ToDateTime(dr["data"]),
                    Paciente = new Paciente
                    {
                        Nome = dr["nome"].ToString(),
                        ContatoTelefonico = dr["contatoTelefonico"].ToString(),
                        DataNascimento = Convert.ToDateTime(dr["dataNascimento"]),
                        Email = dr["email"].ToString(),
                        Endereco = dr["endereco"].ToString()
                    }
                };

                // Adiciona a consulta à lista de consultas
                consultas.Add(consulta);
            }

            dr.Close();
        }

        private void RemoveColunas()
        {
            try
            {
                dataGridView1.Columns.Remove("Paciente");
                dataGridView1.Columns.Remove("idPaciente");
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            CadastrarForm cadastro = new CadastrarForm(calendario.SelectionStart);
            cadastro.ShowDialog();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Consulta consulta = dataGridView1.SelectedRows[0].DataBoundItem as Consulta;

                AlterarForm alteracao = new AlterarForm(consulta);
                alteracao.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}