using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CupomMercado
{
    public partial class RefinamentoDigitalizacao : Form
    {
        string pathFile = "";

        public RefinamentoDigitalizacao()
        {
            InitializeComponent();
        }

        private void RefinamentoDigitalizacao_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pbEntrada.Location = new Point(10, 10);
            pbEntrada.Size = new Size(Width * 40 / 100, Height * 90 / 100);
            pbEntrada.BorderStyle = BorderStyle.FixedSingle;

            pbSaida.Size = pbEntrada.Size;
            pbSaida.Location = new Point(Width - pbEntrada.Width - 30, 10);            
            pbSaida.BorderStyle = pbEntrada.BorderStyle;

            txtSuperior.Location = new Point((pbSaida.Left - pbEntrada.Right - txtSuperior.Width / 2)/2 + pbEntrada.Right, Height*30/100);
            txtEsquerdo.Location = new Point(txtSuperior.Left - txtSuperior.Width / 2-2, txtSuperior.Bottom + 10);

            txtDireito.Visible = false;
            txtInferior.Visible=false;
            txtDireito.Location = new Point(txtEsquerdo.Right + 2, txtSuperior.Bottom + 10);
            txtInferior.Location = new Point(txtSuperior.Left, txtEsquerdo.Bottom + 10);

            txtLargura.Location = new Point(txtDireito.Left, txtInferior.Bottom+50);
            txtAltura.Location = new Point(txtDireito.Left, txtLargura.Bottom + 10);

            btnProcessar.Location = new Point(txtEsquerdo.Left, txtAltura.Bottom + 50);

            //pathFile = @"..\digitalizados\superbarato20220903.jpg";
            pathFile = @"..\digitalizados\20221023PagueMenos.jpg";
            pbEntrada.Load(pathFile);
            pbEntrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;

            //Pague Menos
            txtSuperior.Text = "598";
            txtEsquerdo.Text = "441";
            txtLargura.Text = "367";
            txtAltura.Text = "40";

            //Super Barato
            //txtSuperior.Text = "502";
            //txtEsquerdo.Text = "0";
            //txtLargura.Text = "1006";
            //txtAltura.Text = "34";
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            Image image = Image.FromFile(pathFile);
            Bitmap map = new Bitmap(image.Width*2, image.Height, Graphics.FromImage(image));

            int esquerdo = Convert.ToInt16(txtEsquerdo.Text);
            int superior = Convert.ToInt16(txtSuperior.Text);
            int largura = Convert.ToInt16(txtLargura.Text);
            int altura = Convert.ToInt16(txtAltura.Text);
            
            string newFile = Path.GetFileNameWithoutExtension((Path.GetFileName(pathFile)));
            

            using (Graphics g = Graphics.FromImage(map))
            {
                g.DrawImage(image,0,0);

                for (int i = 10; i < 39; i++)
                {
                    Rectangle copiar = new Rectangle(esquerdo, 72*i+superior, largura, altura);
                    Rectangle colar = new Rectangle(esquerdo + largura, 72*i+superior - 35, largura, altura);

                    g.DrawImage(image, colar, copiar, GraphicsUnit.Pixel);
                    Brush brush = new SolidBrush(Color.White);
                    g.FillRectangle(brush, copiar);
                }

                map.Save(@"..\digitalizados\" + newFile + "NOVO.jpg", ImageFormat.Jpeg);
            }
        }
    }
}
