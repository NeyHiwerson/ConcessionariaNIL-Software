namespace SoftwareConcessionaria
{
    partial class Venda
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
            this.btnVendaVenda = new System.Windows.Forms.Button();
            this.btnVendaCliente = new System.Windows.Forms.Button();
            this.btnVendaVeiculo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVendaVenda
            // 
            this.btnVendaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendaVenda.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVendaVenda.Location = new System.Drawing.Point(530, 12);
            this.btnVendaVenda.Name = "btnVendaVenda";
            this.btnVendaVenda.Size = new System.Drawing.Size(247, 40);
            this.btnVendaVenda.TabIndex = 27;
            this.btnVendaVenda.Text = "Venda";
            this.btnVendaVenda.UseVisualStyleBackColor = true;
            this.btnVendaVenda.Click += new System.EventHandler(this.btnVendaVenda_Click);
            // 
            // btnVendaCliente
            // 
            this.btnVendaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendaCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVendaCliente.Location = new System.Drawing.Point(273, 12);
            this.btnVendaCliente.Name = "btnVendaCliente";
            this.btnVendaCliente.Size = new System.Drawing.Size(247, 40);
            this.btnVendaCliente.TabIndex = 26;
            this.btnVendaCliente.Text = "Cliente";
            this.btnVendaCliente.UseVisualStyleBackColor = true;
            this.btnVendaCliente.Click += new System.EventHandler(this.btnVendaCliente_Click);
            // 
            // btnVendaVeiculo
            // 
            this.btnVendaVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendaVeiculo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVendaVeiculo.Location = new System.Drawing.Point(16, 12);
            this.btnVendaVeiculo.Name = "btnVendaVeiculo";
            this.btnVendaVeiculo.Size = new System.Drawing.Size(247, 40);
            this.btnVendaVeiculo.TabIndex = 25;
            this.btnVendaVeiculo.Text = "Veiculo";
            this.btnVendaVeiculo.UseVisualStyleBackColor = true;
            this.btnVendaVeiculo.Click += new System.EventHandler(this.btnVendaVeiculo_Click);
            // 
            // Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVendaVenda);
            this.Controls.Add(this.btnVendaCliente);
            this.Controls.Add(this.btnVendaVeiculo);
            this.Name = "Venda";
            this.Text = "Venda";
            this.Load += new System.EventHandler(this.Venda_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVendaVenda;
        private System.Windows.Forms.Button btnVendaCliente;
        private System.Windows.Forms.Button btnVendaVeiculo;
    }
}