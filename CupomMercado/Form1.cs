namespace CupomMercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.Manual;
            Size = new Size(Screen.PrimaryScreen.Bounds.Width/2,
                Screen.PrimaryScreen.Bounds.Height*96/100);
            Location = new Point(Width/2, 0);

            txtSaida.Size = new Size(Size.Width*96/100, Size.Height*80/100);
        }

        private void btnEscolherArquivo_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] todoTexto = File.ReadAllLines(ofd.FileName);
                string texto = "";

                foreach (var item in todoTexto)
                {
                    texto += item + " ";
                }

                AtacadaoStaTerezinha atacadaoStaTerezinha = new AtacadaoStaTerezinha(texto);
                txtSaida.Text = atacadaoStaTerezinha.SeparaLinhas();
            }
        }
    }
}