namespace SoftwareConcessionaria
{
    partial class Login
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLoginEsqueceuSuaSenha = new System.Windows.Forms.Label();
            this.btnLoginEntrar = new System.Windows.Forms.Button();
            this.txtLoginSenha = new System.Windows.Forms.TextBox();
            this.txtLoginUsuario = new System.Windows.Forms.TextBox();
            this.lblLoginSenha = new System.Windows.Forms.Label();
            this.lblLoginUsuario = new System.Windows.Forms.Label();
            this.txtResposta = new System.Windows.Forms.Label();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoginEsqueceuSuaSenha
            // 
            this.lblLoginEsqueceuSuaSenha.AutoSize = true;
            this.lblLoginEsqueceuSuaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginEsqueceuSuaSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginEsqueceuSuaSenha.Location = new System.Drawing.Point(249, 331);
            this.lblLoginEsqueceuSuaSenha.Name = "lblLoginEsqueceuSuaSenha";
            this.lblLoginEsqueceuSuaSenha.Size = new System.Drawing.Size(168, 20);
            this.lblLoginEsqueceuSuaSenha.TabIndex = 22;
            this.lblLoginEsqueceuSuaSenha.Text = "Esqueceu sua senha?";
            this.lblLoginEsqueceuSuaSenha.Click += new System.EventHandler(this.lblLoginEsqueceuSuaSenha_Click);
            // 
            // btnLoginEntrar
            // 
            this.btnLoginEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginEntrar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnLoginEntrar.Location = new System.Drawing.Point(253, 288);
            this.btnLoginEntrar.Name = "btnLoginEntrar";
            this.btnLoginEntrar.Size = new System.Drawing.Size(311, 40);
            this.btnLoginEntrar.TabIndex = 21;
            this.btnLoginEntrar.Text = "Entrar";
            this.btnLoginEntrar.UseVisualStyleBackColor = true;
            this.btnLoginEntrar.Click += new System.EventHandler(this.btnLoginEntrar_Click);
            // 
            // txtLoginSenha
            // 
            this.txtLoginSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginSenha.Location = new System.Drawing.Point(253, 226);
            this.txtLoginSenha.Name = "txtLoginSenha";
            this.txtLoginSenha.Size = new System.Drawing.Size(311, 32);
            this.txtLoginSenha.TabIndex = 20;
            // 
            // txtLoginUsuario
            // 
            this.txtLoginUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUsuario.Location = new System.Drawing.Point(253, 140);
            this.txtLoginUsuario.Name = "txtLoginUsuario";
            this.txtLoginUsuario.Size = new System.Drawing.Size(311, 32);
            this.txtLoginUsuario.TabIndex = 19;
            // 
            // lblLoginSenha
            // 
            this.lblLoginSenha.AutoSize = true;
            this.lblLoginSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginSenha.Location = new System.Drawing.Point(248, 191);
            this.lblLoginSenha.Name = "lblLoginSenha";
            this.lblLoginSenha.Size = new System.Drawing.Size(92, 31);
            this.lblLoginSenha.TabIndex = 18;
            this.lblLoginSenha.Text = "Senha";
            // 
            // lblLoginUsuario
            // 
            this.lblLoginUsuario.AutoSize = true;
            this.lblLoginUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginUsuario.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginUsuario.Location = new System.Drawing.Point(248, 100);
            this.lblLoginUsuario.Name = "lblLoginUsuario";
            this.lblLoginUsuario.Size = new System.Drawing.Size(81, 31);
            this.lblLoginUsuario.TabIndex = 17;
            this.lblLoginUsuario.Text = "Email";
            // 
            // txtResposta
            // 
            this.txtResposta.AutoSize = true;
            this.txtResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResposta.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtResposta.Location = new System.Drawing.Point(43, 397);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.Size = new System.Drawing.Size(30, 20);
            this.txtResposta.TabIndex = 23;
            this.txtResposta.Text = "R=";
            this.txtResposta.Click += new System.EventHandler(this.txtResposta_Click);
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastro.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCadastro.Location = new System.Drawing.Point(250, 361);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(96, 20);
            this.lblCadastro.TabIndex = 24;
            this.lblCadastro.Text = "Cadastre-se";
            this.lblCadastro.Click += new System.EventHandler(this.lblCadastro_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCadastro);
            this.Controls.Add(this.txtResposta);
            this.Controls.Add(this.lblLoginEsqueceuSuaSenha);
            this.Controls.Add(this.btnLoginEntrar);
            this.Controls.Add(this.txtLoginSenha);
            this.Controls.Add(this.txtLoginUsuario);
            this.Controls.Add(this.lblLoginSenha);
            this.Controls.Add(this.lblLoginUsuario);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginEsqueceuSuaSenha;
        private System.Windows.Forms.Button btnLoginEntrar;
        private System.Windows.Forms.TextBox txtLoginSenha;
        private System.Windows.Forms.TextBox txtLoginUsuario;
        private System.Windows.Forms.Label lblLoginSenha;
        private System.Windows.Forms.Label lblLoginUsuario;
        private System.Windows.Forms.Label txtResposta;
        private System.Windows.Forms.Label lblCadastro;
    }
}

