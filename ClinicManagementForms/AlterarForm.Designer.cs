
namespace ClinicManagementForms
{
    partial class AlterarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_dataConsulta = new System.Windows.Forms.Label();
            this.dataConsulta = new System.Windows.Forms.DateTimePicker();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_dataConsulta
            // 
            this.lbl_dataConsulta.AutoSize = true;
            this.lbl_dataConsulta.Location = new System.Drawing.Point(117, 70);
            this.lbl_dataConsulta.Name = "lbl_dataConsulta";
            this.lbl_dataConsulta.Size = new System.Drawing.Size(115, 13);
            this.lbl_dataConsulta.TabIndex = 16;
            this.lbl_dataConsulta.Text = "Nova data da consulta";
            // 
            // dataConsulta
            // 
            this.dataConsulta.Location = new System.Drawing.Point(68, 102);
            this.dataConsulta.Name = "dataConsulta";
            this.dataConsulta.Size = new System.Drawing.Size(234, 20);
            this.dataConsulta.TabIndex = 15;
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(133, 164);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(75, 21);
            this.btn_alterar.TabIndex = 21;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // AlterarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 260);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.lbl_dataConsulta);
            this.Controls.Add(this.dataConsulta);
            this.Name = "AlterarForm";
            this.Text = "AlterarForm";
            this.Load += new System.EventHandler(this.AlterarForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_dataConsulta;
        private System.Windows.Forms.DateTimePicker dataConsulta;
        private System.Windows.Forms.Button btn_alterar;
    }
}