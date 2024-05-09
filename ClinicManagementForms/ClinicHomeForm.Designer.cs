
namespace ClinicManagementForms
{
    partial class ClinicHomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancelarConsulta = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClinicManagement";
            // 
            // calendario
            // 
            this.calendario.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.calendario.Location = new System.Drawing.Point(44, 164);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 1;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.Location = new System.Drawing.Point(373, 356);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(116, 23);
            this.btn_cadastrar.TabIndex = 2;
            this.btn_cadastrar.Text = "Cadastrar Consulta";
            this.btn_cadastrar.UseVisualStyleBackColor = true;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecione uma data!";
            // 
            // btn_cancelarConsulta
            // 
            this.btn_cancelarConsulta.Location = new System.Drawing.Point(715, 356);
            this.btn_cancelarConsulta.Name = "btn_cancelarConsulta";
            this.btn_cancelarConsulta.Size = new System.Drawing.Size(132, 23);
            this.btn_cancelarConsulta.TabIndex = 4;
            this.btn_cancelarConsulta.Text = "Cancelar Consulta";
            this.btn_cancelarConsulta.UseVisualStyleBackColor = true;
            this.btn_cancelarConsulta.Click += new System.EventHandler(this.btn_cancelarConsulta_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.Location = new System.Drawing.Point(565, 356);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(89, 23);
            this.btn_alterar.TabIndex = 5;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = true;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(373, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(474, 201);
            this.dataGridView1.TabIndex = 6;
            // 
            // ClinicHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 503);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.btn_cancelarConsulta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.label1);
            this.Name = "ClinicHomeForm";
            this.Text = "ClinicHomeForm";
            this.Load += new System.EventHandler(this.ClinicHomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancelarConsulta;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}