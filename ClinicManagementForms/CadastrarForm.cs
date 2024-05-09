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
    public partial class CadastrarForm : ClinicBase
    {
        public CadastrarForm()
        {
            InitializeComponent();
        }

        private SqlConnection cn;
        private DateTime dataNovaConsulta;

        public CadastrarForm(DateTime dataConsulta)
        {
            dataNovaConsulta = dataConsulta;
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var idPaciente = CadastrarPaciente();
                CadastrarConsulta(idPaciente);

                MessageBox.Show("Consulta cadastrada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu algum erro ao cadastrar a consulta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastrarConsulta(int idPaciente)
        {
            string comandoSql = "insert into Consulta values(@dataConsulta,@idPaciente)";

            using (SqlCommand command = new SqlCommand(comandoSql, cn))
            {
                command.Parameters.AddWithValue("@dataConsulta", dataNovaConsulta);
                command.Parameters.AddWithValue("@idPaciente", idPaciente);

                // Abre a conexão se ainda não estiver aberta
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                command.ExecuteNonQuery();
            }
        }

        private int CadastrarPaciente()
        {
            string comandoSql = "insert into Paciente values(@nome,@dataNascimento,@contatoTelefonico,@email,@endereco); SELECT SCOPE_IDENTITY();";
            int idPaciente = 0;
            //string dataNascimentoFormatada = dataNascimento.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");

            using (SqlCommand command = new SqlCommand(comandoSql, cn))
            {
                command.Parameters.AddWithValue("@nome", txt_nome.Text);
                command.Parameters.AddWithValue("@dataNascimento", dataNascimento.Value);
                command.Parameters.AddWithValue("@contatoTelefonico", txt_contatoTelefonico.Text);
                command.Parameters.AddWithValue("@email", txt_email.Text);
                command.Parameters.AddWithValue("@endereco", txt_endereco.Text);

                // Abre a conexão se ainda não estiver aberta
                if (cn.State != ConnectionState.Open)
                    cn.Open();

                // Executa o comando SQL para inserir o registro e obter o ID gerado
                idPaciente = Convert.ToInt32(command.ExecuteScalar());
            }
            return idPaciente;
        }

        private void CadastrarForm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=NOTEDESADM139\SQLEXPRESS;Initial Catalog=ClinicManegement;Integrated Security=true");
            cn.Open();
        }
    }
}