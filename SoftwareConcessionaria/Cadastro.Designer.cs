namespace SoftwareConcessionaria
{
    partial class Cadastro
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
            this.btnCadEntrar = new System.Windows.Forms.Button();
            this.txtCadEmail = new System.Windows.Forms.TextBox();
            this.txtCadNome = new System.Windows.Forms.TextBox();
            this.lblCadEmail = new System.Windows.Forms.Label();
            this.lblCadNome = new System.Windows.Forms.Label();
            this.txtCadConfirmaSenha = new System.Windows.Forms.TextBox();
            this.txtCadSenha = new System.Windows.Forms.TextBox();
            this.lblCadConfirmaSenha = new System.Windows.Forms.Label();
            this.lblCadSenha = new System.Windows.Forms.Label();
            this.lblCadLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCadEntrar
            // 
            this.btnCadEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadEntrar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCadEntrar.Location = new System.Drawing.Point(279, 404);
            this.btnCadEntrar.Name = "btnCadEntrar";
            this.btnCadEntrar.Size = new System.Drawing.Size(247, 40);
            this.btnCadEntrar.TabIndex = 26;
            this.btnCadEntrar.Text = "Entrar";
            this.btnCadEntrar.UseVisualStyleBackColor = true;
            this.btnCadEntrar.Click += new System.EventHandler(this.btnCadEntrar_Click);
            // 
            // txtCadEmail
            // 
            this.txtCadEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadEmail.Location = new System.Drawing.Point(279, 156);
            this.txtCadEmail.Name = "txtCadEmail";
            this.txtCadEmail.Size = new System.Drawing.Size(247, 38);
            this.txtCadEmail.TabIndex = 25;
            this.txtCadEmail.TextChanged += new System.EventHandler(this.txtCadEmail_TextChanged);
            // 
            // txtCadNome
            // 
            this.txtCadNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadNome.Location = new System.Drawing.Point(279, 70);
            this.txtCadNome.Name = "txtCadNome";
            this.txtCadNome.Size = new System.Drawing.Size(247, 38);
            this.txtCadNome.TabIndex = 24;
            this.txtCadNome.TextChanged += new System.EventHandler(this.txtCadNome_TextChanged);
            // 
            // lblCadEmail
            // 
            this.lblCadEmail.AutoSize = true;
            this.lblCadEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadEmail.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadEmail.Location = new System.Drawing.Point(274, 121);
            this.lblCadEmail.Name = "lblCadEmail";
            this.lblCadEmail.Size = new System.Drawing.Size(81, 31);
            this.lblCadEmail.TabIndex = 23;
            this.lblCadEmail.Text = "Email";
            // 
            // lblCadNome
            // 
            this.lblCadNome.AutoSize = true;
            this.lblCadNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadNome.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadNome.Location = new System.Drawing.Point(274, 30);
            this.lblCadNome.Name = "lblCadNome";
            this.lblCadNome.Size = new System.Drawing.Size(86, 31);
            this.lblCadNome.TabIndex = 22;
            this.lblCadNome.Text = "Nome";
            // 
            // txtCadConfirmaSenha
            // 
            this.txtCadConfirmaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadConfirmaSenha.Location = new System.Drawing.Point(279, 331);
            this.txtCadConfirmaSenha.Name = "txtCadConfirmaSenha";
            this.txtCadConfirmaSenha.Size = new System.Drawing.Size(247, 38);
            this.txtCadConfirmaSenha.TabIndex = 30;
            this.txtCadConfirmaSenha.TextChanged += new System.EventHandler(this.txtCadConfirmaSenha_TextChanged);
            // 
            // txtCadSenha
            // 
            this.txtCadSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadSenha.Location = new System.Drawing.Point(279, 245);
            this.txtCadSenha.Name = "txtCadSenha";
            this.txtCadSenha.Size = new System.Drawing.Size(247, 38);
            this.txtCadSenha.TabIndex = 29;
            this.txtCadSenha.TextChanged += new System.EventHandler(this.txtCadSenha_TextChanged);
            // 
            // lblCadConfirmaSenha
            // 
            this.lblCadConfirmaSenha.AutoSize = true;
            this.lblCadConfirmaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadConfirmaSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadConfirmaSenha.Location = new System.Drawing.Point(274, 296);
            this.lblCadConfirmaSenha.Name = "lblCadConfirmaSenha";
            this.lblCadConfirmaSenha.Size = new System.Drawing.Size(209, 31);
            this.lblCadConfirmaSenha.TabIndex = 28;
            this.lblCadConfirmaSenha.Text = "Confirma Senha";
            // 
            // lblCadSenha
            // 
            this.lblCadSenha.AutoSize = true;
            this.lblCadSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadSenha.Location = new System.Drawing.Point(274, 205);
            this.lblCadSenha.Name = "lblCadSenha";
            this.lblCadSenha.Size = new System.Drawing.Size(92, 31);
            this.lblCadSenha.TabIndex = 27;
            this.lblCadSenha.Text = "Senha";
            // 
            // lblCadLogin
            // 
            this.lblCadLogin.AutoSize = true;
            this.lblCadLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadLogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadLogin.Location = new System.Drawing.Point(275, 473);
            this.lblCadLogin.Name = "lblCadLogin";
            this.lblCadLogin.Size = new System.Drawing.Size(132, 20);
            this.lblCadLogin.TabIndex = 31;
            this.lblCadLogin.Text = "Já é cadastrado?";
            this.lblCadLogin.Click += new System.EventHandler(this.lblCadLogin_Click);
            // 
            // Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 583);
            this.Controls.Add(this.lblCadLogin);
            this.Controls.Add(this.txtCadConfirmaSenha);
            this.Controls.Add(this.txtCadSenha);
            this.Controls.Add(this.lblCadConfirmaSenha);
            this.Controls.Add(this.lblCadSenha);
            this.Controls.Add(this.btnCadEntrar);
            this.Controls.Add(this.txtCadEmail);
            this.Controls.Add(this.txtCadNome);
            this.Controls.Add(this.lblCadEmail);
            this.Controls.Add(this.lblCadNome);
            this.Name = "Cadastro";
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Cadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadEntrar;
        private System.Windows.Forms.TextBox txtCadEmail;
        private System.Windows.Forms.TextBox txtCadNome;
        private System.Windows.Forms.Label lblCadEmail;
        private System.Windows.Forms.Label lblCadNome;
        private System.Windows.Forms.TextBox txtCadConfirmaSenha;
        private System.Windows.Forms.TextBox txtCadSenha;
        private System.Windows.Forms.Label lblCadConfirmaSenha;
        private System.Windows.Forms.Label lblCadSenha;
        private System.Windows.Forms.Label lblCadLogin;
    }
}