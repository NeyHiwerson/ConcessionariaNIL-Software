namespace SoftwareConcessionaria
{
    partial class EsqueceuSenha
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
            this.txtDefinaSeuEmail = new System.Windows.Forms.TextBox();
            this.btnEsqueceuSenhaEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(253, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Defina Seu E-mail";
            // 
            // txtDefinaSeuEmail
            // 
            this.txtDefinaSeuEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefinaSeuEmail.Location = new System.Drawing.Point(259, 152);
            this.txtDefinaSeuEmail.Name = "txtDefinaSeuEmail";
            this.txtDefinaSeuEmail.Size = new System.Drawing.Size(278, 30);
            this.txtDefinaSeuEmail.TabIndex = 1;
            // 
            // btnEsqueceuSenhaEnviar
            // 
            this.btnEsqueceuSenhaEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsqueceuSenhaEnviar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEsqueceuSenhaEnviar.Location = new System.Drawing.Point(354, 188);
            this.btnEsqueceuSenhaEnviar.Name = "btnEsqueceuSenhaEnviar";
            this.btnEsqueceuSenhaEnviar.Size = new System.Drawing.Size(84, 31);
            this.btnEsqueceuSenhaEnviar.TabIndex = 2;
            this.btnEsqueceuSenhaEnviar.Text = "Enviar";
            this.btnEsqueceuSenhaEnviar.UseVisualStyleBackColor = true;
            // 
            // EsqueceuSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEsqueceuSenhaEnviar);
            this.Controls.Add(this.txtDefinaSeuEmail);
            this.Controls.Add(this.label1);
            this.Name = "EsqueceuSenha";
            this.Text = "EsqueceuSenha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDefinaSeuEmail;
        private System.Windows.Forms.Button btnEsqueceuSenhaEnviar;
    }
}