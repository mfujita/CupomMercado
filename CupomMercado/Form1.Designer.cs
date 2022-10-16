namespace CupomMercado
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEscolherArquivo = new System.Windows.Forms.Button();
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.rbAtacadao = new System.Windows.Forms.RadioButton();
            this.rbPagueMenos = new System.Windows.Forms.RadioButton();
            this.brnProcessar = new System.Windows.Forms.Button();
            this.btnEditarCumpom = new System.Windows.Forms.Button();
            this.rbTodoDia = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnEscolherArquivo
            // 
            this.btnEscolherArquivo.Location = new System.Drawing.Point(130, 21);
            this.btnEscolherArquivo.Name = "btnEscolherArquivo";
            this.btnEscolherArquivo.Size = new System.Drawing.Size(136, 37);
            this.btnEscolherArquivo.TabIndex = 0;
            this.btnEscolherArquivo.Text = "Escolher arquivo";
            this.btnEscolherArquivo.UseVisualStyleBackColor = true;
            this.btnEscolherArquivo.Click += new System.EventHandler(this.btnEscolherArquivo_Click);
            // 
            // txtSaida
            // 
            this.txtSaida.Location = new System.Drawing.Point(12, 83);
            this.txtSaida.Multiline = true;
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSaida.Size = new System.Drawing.Size(849, 378);
            this.txtSaida.TabIndex = 1;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // rbAtacadao
            // 
            this.rbAtacadao.AutoSize = true;
            this.rbAtacadao.Location = new System.Drawing.Point(307, 12);
            this.rbAtacadao.Name = "rbAtacadao";
            this.rbAtacadao.Size = new System.Drawing.Size(92, 25);
            this.rbAtacadao.TabIndex = 2;
            this.rbAtacadao.TabStop = true;
            this.rbAtacadao.Text = "Atacadão";
            this.rbAtacadao.UseVisualStyleBackColor = true;
            // 
            // rbPagueMenos
            // 
            this.rbPagueMenos.AutoSize = true;
            this.rbPagueMenos.Location = new System.Drawing.Point(427, 12);
            this.rbPagueMenos.Name = "rbPagueMenos";
            this.rbPagueMenos.Size = new System.Drawing.Size(121, 25);
            this.rbPagueMenos.TabIndex = 3;
            this.rbPagueMenos.TabStop = true;
            this.rbPagueMenos.Text = "Pague Menos";
            this.rbPagueMenos.UseVisualStyleBackColor = true;
            // 
            // brnProcessar
            // 
            this.brnProcessar.Location = new System.Drawing.Point(725, 21);
            this.brnProcessar.Name = "brnProcessar";
            this.brnProcessar.Size = new System.Drawing.Size(136, 37);
            this.brnProcessar.TabIndex = 4;
            this.brnProcessar.Text = "Processar";
            this.brnProcessar.UseVisualStyleBackColor = true;
            this.brnProcessar.Click += new System.EventHandler(this.brnProcessar_Click);
            // 
            // btnEditarCumpom
            // 
            this.btnEditarCumpom.Location = new System.Drawing.Point(12, 3);
            this.btnEditarCumpom.Name = "btnEditarCumpom";
            this.btnEditarCumpom.Size = new System.Drawing.Size(89, 74);
            this.btnEditarCumpom.TabIndex = 5;
            this.btnEditarCumpom.Text = "Editar imagem cupom";
            this.btnEditarCumpom.UseVisualStyleBackColor = true;
            this.btnEditarCumpom.Click += new System.EventHandler(this.btnEditarCumpom_Click);
            // 
            // rbTodoDia
            // 
            this.rbTodoDia.AutoSize = true;
            this.rbTodoDia.Location = new System.Drawing.Point(307, 33);
            this.rbTodoDia.Name = "rbTodoDia";
            this.rbTodoDia.Size = new System.Drawing.Size(88, 25);
            this.rbTodoDia.TabIndex = 6;
            this.rbTodoDia.TabStop = true;
            this.rbTodoDia.Text = "Todo Dia";
            this.rbTodoDia.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 487);
            this.Controls.Add(this.rbTodoDia);
            this.Controls.Add(this.btnEditarCumpom);
            this.Controls.Add(this.brnProcessar);
            this.Controls.Add(this.rbPagueMenos);
            this.Controls.Add(this.rbAtacadao);
            this.Controls.Add(this.txtSaida);
            this.Controls.Add(this.btnEscolherArquivo);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cupom de mercado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnEscolherArquivo;
        private TextBox txtSaida;
        private OpenFileDialog ofd;
        private RadioButton rbAtacadao;
        private RadioButton rbPagueMenos;
        private Button brnProcessar;
        private Button btnEditarCumpom;
        private RadioButton rbTodoDia;
    }
}