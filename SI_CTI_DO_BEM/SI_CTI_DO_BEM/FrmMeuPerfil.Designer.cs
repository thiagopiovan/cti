namespace CadastroDoacoes
{
    partial class FrmMeuPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMeuPerfil));
            this.txt_usu = new System.Windows.Forms.TextBox();
            this.cmb_sexo = new System.Windows.Forms.ComboBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_usu = new System.Windows.Forms.Button();
            this.btn_senha = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.conf_senha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_usu
            // 
            this.txt_usu.Enabled = false;
            this.txt_usu.Location = new System.Drawing.Point(115, 92);
            this.txt_usu.Name = "txt_usu";
            this.txt_usu.Size = new System.Drawing.Size(234, 20);
            this.txt_usu.TabIndex = 21;
            this.txt_usu.TextChanged += new System.EventHandler(this.txt_usu_TextChanged);
            this.txt_usu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_usu_KeyPress);
            // 
            // cmb_sexo
            // 
            this.cmb_sexo.Enabled = false;
            this.cmb_sexo.FormattingEnabled = true;
            this.cmb_sexo.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cmb_sexo.Location = new System.Drawing.Point(398, 21);
            this.cmb_sexo.Name = "cmb_sexo";
            this.cmb_sexo.Size = new System.Drawing.Size(34, 21);
            this.cmb_sexo.TabIndex = 20;
            this.cmb_sexo.SelectedIndexChanged += new System.EventHandler(this.cmb_sexo_SelectedIndexChanged);
            // 
            // txt_nome
            // 
            this.txt_nome.Enabled = false;
            this.txt_nome.Location = new System.Drawing.Point(115, 22);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(234, 20);
            this.txt_nome.TabIndex = 19;
            this.txt_nome.TextChanged += new System.EventHandler(this.txt_nome_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sexo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nome de Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tipo de Usuário:";
            // 
            // btn_usu
            // 
            this.btn_usu.BackColor = System.Drawing.Color.White;
            this.btn_usu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_usu.Image = global::SI_CTI_DO_BEM.Properties.Resources.edit;
            this.btn_usu.Location = new System.Drawing.Point(352, 90);
            this.btn_usu.Name = "btn_usu";
            this.btn_usu.Size = new System.Drawing.Size(27, 23);
            this.btn_usu.TabIndex = 27;
            this.btn_usu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_usu.UseVisualStyleBackColor = false;
            this.btn_usu.Click += new System.EventHandler(this.btn_usu_Click);
            // 
            // btn_senha
            // 
            this.btn_senha.BackColor = System.Drawing.Color.White;
            this.btn_senha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_senha.Image = global::SI_CTI_DO_BEM.Properties.Resources.edit;
            this.btn_senha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_senha.Location = new System.Drawing.Point(115, 125);
            this.btn_senha.Name = "btn_senha";
            this.btn_senha.Size = new System.Drawing.Size(92, 23);
            this.btn_senha.TabIndex = 25;
            this.btn_senha.Text = "Alterar Senha";
            this.btn_senha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_senha.UseVisualStyleBackColor = false;
            this.btn_senha.Click += new System.EventHandler(this.btn_senha_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Image = global::SI_CTI_DO_BEM.Properties.Resources.edit_validated256_25237;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(358, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 28;
            this.button1.Text = "Alterar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.Enabled = false;
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Items.AddRange(new object[] {
            "Visitante",
            "Administrasdor",
            "Profissional"});
            this.cmb_tipo.Location = new System.Drawing.Point(115, 59);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(234, 21);
            this.cmb_tipo.TabIndex = 18;
            // 
            // txt_senha
            // 
            this.txt_senha.Enabled = false;
            this.txt_senha.Location = new System.Drawing.Point(115, 125);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.Size = new System.Drawing.Size(113, 20);
            this.txt_senha.TabIndex = 22;
            this.txt_senha.UseSystemPasswordChar = true;
            this.txt_senha.Visible = false;
            this.txt_senha.TextChanged += new System.EventHandler(this.txt_senha_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Confirmar senha:";
            this.label4.Visible = false;
            // 
            // conf_senha
            // 
            this.conf_senha.Location = new System.Drawing.Point(115, 154);
            this.conf_senha.Name = "conf_senha";
            this.conf_senha.Size = new System.Drawing.Size(113, 20);
            this.conf_senha.TabIndex = 23;
            this.conf_senha.UseSystemPasswordChar = true;
            this.conf_senha.Visible = false;
            this.conf_senha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.conf_senha_KeyPress);
            // 
            // FrmMeuPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(480, 232);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_usu);
            this.Controls.Add(this.btn_senha);
            this.Controls.Add(this.conf_senha);
            this.Controls.Add(this.txt_senha);
            this.Controls.Add(this.txt_usu);
            this.Controls.Add(this.cmb_sexo);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMeuPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meu Perfil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMeuPerfil_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_usu;
        private System.Windows.Forms.ComboBox cmb_sexo;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_usu;
        private System.Windows.Forms.Button btn_senha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox conf_senha;
    }
}