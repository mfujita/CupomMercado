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
                string nomeArquivo = Path.GetFileNameWithoutExtension(ofd.FileName);
                string texto = "";

                foreach (var item in todoTexto)
                {
                    texto += item + " ";
                }

                if  (rbAtacadao.Checked)
                {
                    AtacadaoStaTerezinha atacadaoStaTerezinha = new AtacadaoStaTerezinha(texto);
                    string linha = atacadaoStaTerezinha.SeparaLinhas();
                    txtSaida.Text = linha;
                    List<Dados> lista = atacadaoStaTerezinha.RefinaTexto(linha);
                    atacadaoStaTerezinha.WriteTicket(lista);
                }

                MessageBox.Show("Ok!");
            }
        }
    }
}