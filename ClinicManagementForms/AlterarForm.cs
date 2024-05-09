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
    public partial class AlterarForm : ClinicBase
    {
        public AlterarForm()
        {
            InitializeComponent();
        }

        private Consulta consulta;

        public AlterarForm(Consulta consultaModel)
        {
            consulta = consultaModel;
            InitializeComponent();
        }

        private SqlConnection cn;

        private void AlterarForm_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=NOTEDESADM139\SQLEXPRESS;Initial Catalog=ClinicManegement;Integrated Security=true");
            cn.Open();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            try
            {
                string comandoSql = "Update Consulta Set Data = @Data where Id = @Id";

                using (SqlCommand command = new SqlCommand(comandoSql, cn))
                {
                    command.Parameters.AddWithValue("@Id", consulta.Id);
                    command.Parameters.AddWithValue("@Data", dataConsulta.Value);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Data alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar data", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}