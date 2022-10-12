using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CupomMercado
{
    public partial class RefinamentoDigitalizacao : Form
    {
        public RefinamentoDigitalizacao()
        {
            InitializeComponent();
        }

        private void RefinamentoDigitalizacao_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pbEntrada.Location = new Point(10, 10);
            pbEntrada.Size = new Size(Width * 30 / 100, Height * 90 / 100);
            pbEntrada.BorderStyle = BorderStyle.FixedSingle;

            pbSaida.Location = new Point(1000, 10);
            pbSaida.Size = pbEntrada.Size;
            pbSaida.BorderStyle = pbEntrada.BorderStyle;

            txtSuperior.Location = new Point((pbSaida.Left - pbEntrada.Right - txtSuperior.Width / 2)/2 + pbEntrada.Right, Height*30/100);
            txtEsquerdo.Location = new Point(txtSuperior.Left - txtSuperior.Width / 2-2, txtSuperior.Bottom + 10);
            txtDireito.Location = new Point(txtEsquerdo.Right + 2, txtSuperior.Bottom + 10);
            txtInferior.Location = new Point(txtSuperior.Left, txtEsquerdo.Bottom + 10);

            txtLargura.Location = new Point(txtDireito.Left, txtInferior.Bottom+50);
            txtAltura.Location = new Point(txtDireito.Left, txtLargura.Bottom + 10);
        }
    }
}
