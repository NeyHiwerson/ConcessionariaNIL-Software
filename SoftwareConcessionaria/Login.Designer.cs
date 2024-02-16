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
            this.resposta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoginEsqueceuSuaSenha
            // 
            this.lblLoginEsqueceuSuaSenha.AutoSize = true;
            this.lblLoginEsqueceuSuaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginEsqueceuSuaSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginEsqueceuSuaSenha.Location = new System.Drawing.Point(275, 331);
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
            this.btnLoginEntrar.Location = new System.Drawing.Point(279, 288);
            this.btnLoginEntrar.Name = "btnLoginEntrar";
            this.btnLoginEntrar.Size = new System.Drawing.Size(247, 40);
            this.btnLoginEntrar.TabIndex = 21;
            this.btnLoginEntrar.Text = "Entrar";
            this.btnLoginEntrar.UseVisualStyleBackColor = true;
            this.btnLoginEntrar.Click += new System.EventHandler(this.btnLoginEntrar_Click);
            // 
            // txtLoginSenha
            // 
            this.txtLoginSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginSenha.Location = new System.Drawing.Point(279, 226);
            this.txtLoginSenha.Name = "txtLoginSenha";
            this.txtLoginSenha.Size = new System.Drawing.Size(247, 38);
            this.txtLoginSenha.TabIndex = 20;
            this.txtLoginSenha.TextChanged += new System.EventHandler(this.txtLoginSenha_TextChanged);
            // 
            // txtLoginUsuario
            // 
            this.txtLoginUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUsuario.Location = new System.Drawing.Point(279, 140);
            this.txtLoginUsuario.Name = "txtLoginUsuario";
            this.txtLoginUsuario.Size = new System.Drawing.Size(247, 38);
            this.txtLoginUsuario.TabIndex = 19;
            this.txtLoginUsuario.TextChanged += new System.EventHandler(this.txtLoginUsuario_TextChanged);
            // 
            // lblLoginSenha
            // 
            this.lblLoginSenha.AutoSize = true;
            this.lblLoginSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginSenha.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginSenha.Location = new System.Drawing.Point(274, 191);
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
            this.lblLoginUsuario.Location = new System.Drawing.Point(274, 100);
            this.lblLoginUsuario.Name = "lblLoginUsuario";
            this.lblLoginUsuario.Size = new System.Drawing.Size(81, 31);
            this.lblLoginUsuario.TabIndex = 17;
            this.lblLoginUsuario.Text = "Email";
            // 
            // resposta
            // 
            this.resposta.AutoSize = true;
            this.resposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resposta.ForeColor = System.Drawing.SystemColors.Highlight;
            this.resposta.Location = new System.Drawing.Point(43, 397);
            this.resposta.Name = "resposta";
            this.resposta.Size = new System.Drawing.Size(30, 20);
            this.resposta.TabIndex = 23;
            this.resposta.Text = "R=";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resposta);
            this.Controls.Add(this.lblLoginEsqueceuSuaSenha);
            this.Controls.Add(this.btnLoginEntrar);
            this.Controls.Add(this.txtLoginSenha);
            this.Controls.Add(this.txtLoginUsuario);
            this.Controls.Add(this.lblLoginSenha);
            this.Controls.Add(this.lblLoginUsuario);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
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
        private System.Windows.Forms.Label resposta;
    }
}

