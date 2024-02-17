namespace SoftwareConcessionaria
{
    partial class Veiculo
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
            this.btnVeiculoVeiculo = new System.Windows.Forms.Button();
            this.btnVeiculoCliente = new System.Windows.Forms.Button();
            this.btnVeiculoVenda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVeiculoVeiculo
            // 
            this.btnVeiculoVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeiculoVeiculo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVeiculoVeiculo.Location = new System.Drawing.Point(27, 12);
            this.btnVeiculoVeiculo.Name = "btnVeiculoVeiculo";
            this.btnVeiculoVeiculo.Size = new System.Drawing.Size(247, 40);
            this.btnVeiculoVeiculo.TabIndex = 22;
            this.btnVeiculoVeiculo.Text = "Veiculo";
            this.btnVeiculoVeiculo.UseVisualStyleBackColor = true;
            this.btnVeiculoVeiculo.Click += new System.EventHandler(this.btnVeiculoVeiculo_Click);
            // 
            // btnVeiculoCliente
            // 
            this.btnVeiculoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeiculoCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVeiculoCliente.Location = new System.Drawing.Point(284, 12);
            this.btnVeiculoCliente.Name = "btnVeiculoCliente";
            this.btnVeiculoCliente.Size = new System.Drawing.Size(247, 40);
            this.btnVeiculoCliente.TabIndex = 23;
            this.btnVeiculoCliente.Text = "Cliente";
            this.btnVeiculoCliente.UseVisualStyleBackColor = true;
            this.btnVeiculoCliente.Click += new System.EventHandler(this.btnVeiculoCliente_Click);
            // 
            // btnVeiculoVenda
            // 
            this.btnVeiculoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeiculoVenda.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVeiculoVenda.Location = new System.Drawing.Point(541, 12);
            this.btnVeiculoVenda.Name = "btnVeiculoVenda";
            this.btnVeiculoVenda.Size = new System.Drawing.Size(247, 40);
            this.btnVeiculoVenda.TabIndex = 24;
            this.btnVeiculoVenda.Text = "Venda";
            this.btnVeiculoVenda.UseVisualStyleBackColor = true;
            this.btnVeiculoVenda.Click += new System.EventHandler(this.btnVeiculoVenda_Click);
            // 
            // Veiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVeiculoVenda);
            this.Controls.Add(this.btnVeiculoCliente);
            this.Controls.Add(this.btnVeiculoVeiculo);
            this.Name = "Veiculo";
            this.Text = "Veiculo";
            this.Load += new System.EventHandler(this.Veiculo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVeiculoVeiculo;
        private System.Windows.Forms.Button btnVeiculoCliente;
        private System.Windows.Forms.Button btnVeiculoVenda;
    }
}