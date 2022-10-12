namespace CupomMercado
{
    partial class RefinamentoDigitalizacao
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
            this.pbEntrada = new System.Windows.Forms.PictureBox();
            this.txtSuperior = new System.Windows.Forms.TextBox();
            this.txtEsquerdo = new System.Windows.Forms.TextBox();
            this.txtDireito = new System.Windows.Forms.TextBox();
            this.txtInferior = new System.Windows.Forms.TextBox();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.pbSaida = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaida)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEntrada
            // 
            this.pbEntrada.Location = new System.Drawing.Point(17, 28);
            this.pbEntrada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbEntrada.Name = "pbEntrada";
            this.pbEntrada.Size = new System.Drawing.Size(404, 475);
            this.pbEntrada.TabIndex = 0;
            this.pbEntrada.TabStop = false;
            // 
            // txtSuperior
            // 
            this.txtSuperior.Location = new System.Drawing.Point(493, 163);
            this.txtSuperior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSuperior.Name = "txtSuperior";
            this.txtSuperior.Size = new System.Drawing.Size(78, 27);
            this.txtSuperior.TabIndex = 1;
            // 
            // txtEsquerdo
            // 
            this.txtEsquerdo.Location = new System.Drawing.Point(449, 198);
            this.txtEsquerdo.Margin = new System.Windows.Forms.Padding(4);
            this.txtEsquerdo.Name = "txtEsquerdo";
            this.txtEsquerdo.Size = new System.Drawing.Size(78, 27);
            this.txtEsquerdo.TabIndex = 2;
            // 
            // txtDireito
            // 
            this.txtDireito.Location = new System.Drawing.Point(535, 198);
            this.txtDireito.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireito.Name = "txtDireito";
            this.txtDireito.Size = new System.Drawing.Size(78, 27);
            this.txtDireito.TabIndex = 3;
            // 
            // txtInferior
            // 
            this.txtInferior.Location = new System.Drawing.Point(493, 233);
            this.txtInferior.Margin = new System.Windows.Forms.Padding(4);
            this.txtInferior.Name = "txtInferior";
            this.txtInferior.Size = new System.Drawing.Size(78, 27);
            this.txtInferior.TabIndex = 4;
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(535, 295);
            this.txtLargura.Margin = new System.Windows.Forms.Padding(4);
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.Size = new System.Drawing.Size(78, 27);
            this.txtLargura.TabIndex = 5;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(535, 330);
            this.txtAltura.Margin = new System.Windows.Forms.Padding(4);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(78, 27);
            this.txtAltura.TabIndex = 6;
            // 
            // pbSaida
            // 
            this.pbSaida.Location = new System.Drawing.Point(683, 28);
            this.pbSaida.Margin = new System.Windows.Forms.Padding(4);
            this.pbSaida.Name = "pbSaida";
            this.pbSaida.Size = new System.Drawing.Size(404, 475);
            this.pbSaida.TabIndex = 7;
            this.pbSaida.TabStop = false;
            // 
            // RefinamentoDigitalizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 540);
            this.Controls.Add(this.pbSaida);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtLargura);
            this.Controls.Add(this.txtInferior);
            this.Controls.Add(this.txtDireito);
            this.Controls.Add(this.txtEsquerdo);
            this.Controls.Add(this.txtSuperior);
            this.Controls.Add(this.pbEntrada);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RefinamentoDigitalizacao";
            this.Text = "RefinamentoDigitalizacao";
            this.Load += new System.EventHandler(this.RefinamentoDigitalizacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbEntrada;
        private TextBox txtSuperior;
        private TextBox txtEsquerdo;
        private TextBox txtDireito;
        private TextBox txtInferior;
        private TextBox txtLargura;
        private TextBox txtAltura;
        private PictureBox pbSaida;
    }
}