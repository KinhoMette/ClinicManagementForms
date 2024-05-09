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
    public partial class FormLogin : ClinicBase
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private SqlConnection cn;

        private void btn_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegistration = new FormRegister();
            formRegistration.ShowDialog();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != string.Empty || txt_userName.Text != string.Empty)
            {
                var cmd = new SqlCommand("select * from Users where username='" + txt_userName.Text + "' and password='" + txt_password.Text + "'", cn);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    ClinicHomeForm home = new ClinicHomeForm();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=NOTEDESADM139\SQLEXPRESS;Initial Catalog=ClinicManegement;Integrated Security=true");
            cn.Open();
        }
    }
}