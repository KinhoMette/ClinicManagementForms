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
    public partial class FormRegister : ClinicBase
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private SqlConnection cn;

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_confirmPassoword.Text != string.Empty || txt_password.Text != string.Empty || txt_username.Text != string.Empty)
            {
                if (txt_password.Text == txt_confirmPassoword.Text)
                {
                    var cmd = new SqlCommand("select * from Users where username='" + txt_username.Text + "'", cn);
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Users values (@password, @username)", cn);
                        cmd.Parameters.AddWithValue("username", txt_username.Text);
                        cmd.Parameters.AddWithValue("password", txt_password.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=NOTEDESADM139\SQLEXPRESS;Initial Catalog=ClinicManegement;Integrated Security=true");
            cn.Open();
        }
    }
}