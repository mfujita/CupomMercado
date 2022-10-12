namespace CupomMercado
{
    public partial class Form1 : Form
    {
        string nomeArquivo;
        PagueMenos pagueMenos;

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

                if  (rbAtacadao.Checked)
                {
                    nomeArquivo = Path.GetFileNameWithoutExtension(ofd.FileName);
                    AtacadaoStaTerezinha atacadaoStaTerezinha = new AtacadaoStaTerezinha(texto, nomeArquivo);
                    string linha = atacadaoStaTerezinha.SeparaLinhas();
                    txtSaida.Text = linha;
                    List<Dados> lista = atacadaoStaTerezinha.RefinaTexto(linha);
                    atacadaoStaTerezinha.WriteTicket(lista);
                }
                else if (rbPagueMenos.Checked)
                {
                    nomeArquivo = Path.GetFileNameWithoutExtension(ofd.FileName);
                    pagueMenos = new PagueMenos(texto, nomeArquivo);
                    string linha = pagueMenos.SeparaLinhas();
                    linha = pagueMenos.RetiraCodigo(linha);

                    
                    txtSaida.Text = linha;
                }

                MessageBox.Show("Ok!");
            }
        }

        private void brnProcessar_Click(object sender, EventArgs e)
        {
            
            Relatorio relatorio = new Relatorio(txtSaida.Text, nomeArquivo);
            List<Dados> lista = relatorio.SeparaColunas();
            relatorio.WriteTicket();

        }
    }
}