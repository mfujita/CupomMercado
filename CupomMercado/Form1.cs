namespace CupomMercado
{
    public partial class Form1 : Form
    {
        string nomeArquivo;
        PagueMenos pagueMenos;
        TodoDia todoDia;
        NomeLoja loja;

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

            txtSaida.Text = "Carregue o arquivo de texto." + Environment.NewLine +
                "Ajeite o texto" + Environment.NewLine +
                "Bloco do cabeçalho (deixe uma linha em branco)" + Environment.NewLine +
                "Bloco dos produtos (deixe uma linha em branco)" + Environment.NewLine +
                "Bloco do rodapé";
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
                    //List<Dados> lista = atacadaoStaTerezinha.RefinaTexto(linha);
                    //atacadaoStaTerezinha.WriteTicket(lista);
                    loja = NomeLoja.Atacadão;
                }
                else if (rbPagueMenos.Checked)
                {
                    nomeArquivo = Path.GetFileNameWithoutExtension(ofd.FileName);
                    pagueMenos = new PagueMenos(texto, nomeArquivo);
                    string linha = pagueMenos.SeparaLinhas();
                    linha = pagueMenos.RetiraCodigo(linha);
                    
                    txtSaida.Text = linha;
                    loja = NomeLoja.PagueMenos;
                }
                else if (rbTodoDia.Checked)
                {
                    nomeArquivo = Path.GetFileNameWithoutExtension(ofd.FileName);
                    todoDia = new TodoDia(texto, nomeArquivo);
                    string linha = todoDia.SeparaLinhas();
                    linha = todoDia.RetiraCodigo(linha);

                    txtSaida.Text = linha;
                    loja = NomeLoja.TodoDia;
                }
            }
        }

        private void brnProcessar_Click(object sender, EventArgs e)
        {
            if (txtSaida.Text != "")
            {
                Relatorio relatorio = new Relatorio(txtSaida.Text, nomeArquivo, loja);
                relatorio.GetHeader();
                relatorio.GetFooter();
                List<Dados> lista = relatorio.SeparaColunas();
                relatorio.WriteTicket();
            }
        }

        private void btnEditarCumpom_Click(object sender, EventArgs e)
        {
            RefinamentoDigitalizacao refinamentoDigitalizacao = new RefinamentoDigitalizacao();
            refinamentoDigitalizacao.Show();
        }
    }
}