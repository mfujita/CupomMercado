using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupomMercado
{
    class AtacadaoStaTerezinha
    {
        string texto = "";
        List<string> rodape = null;

        public AtacadaoStaTerezinha(string todoTexto)
        {
            texto = todoTexto;
        }

        public string SeparaLinhas()
        {
            string filtrado = "";
            int i = 1;
            string[] campos = texto.ToString().Split(' ');
            rodape = new List<string>();

            foreach (string campo in campos)
            {
                if (campo == i.ToString().PadLeft(3, '0'))
                {
                    filtrado += campo.Replace(i.ToString().PadLeft(3, '0'), System.Environment.NewLine + i.ToString().PadLeft(3, '0') + " ");
                    i++;
                }
                else if (campo.ToString().Contains("Total"))
                {
                    rodape.Add(filtrado.Replace("Total", System.Environment.NewLine + "Total"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("TOTAL"))
                {
                    rodape.Add(filtrado.Replace("TOTAL", Environment.NewLine + "TOTAL"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Vale"))
                {
                    rodape.Add(filtrado.Replace("Vale", Environment.NewLine + "Vale"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Cartao"))
                {
                    rodape.Add(filtrado.Replace("Cartao", Environment.NewLine + "Cartao"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Tributos"))
                {
                    rodape.Add(filtrado.Replace("Tributos", Environment.NewLine + "Tributos "));
                    filtrado = "";
                }
                else if (campos[i].ToString().Contains("SAT"))
                {
                    rodape.Add(filtrado.Replace("SAT", Environment.NewLine + "SAT"));
                    filtrado = "";
                }
                else
                {
                    filtrado += campo + " ";
                }
            }

            //filtrado = filtrado.Replace("Total bruto de Itens", System.Environment.NewLine + "Total bruto de Itens");
            //filtrado = filtrado.Replace("Total de descontos/acrescidos sobre iten", Environment.NewLine + "Total de descontos/acrescidos sobre iten");
            //filtrado = filtrado.Replace("TOTAL", Environment.NewLine + "TOTAL");
            //filtrado = filtrado.Replace("Vale Alimentacao", Environment.NewLine + "Vale Alimentacao");
            //filtrado = filtrado.Replace("Cartao de Credito", Environment.NewLine + "Cartao de Credito");
            //filtrado = filtrado.Replace("Tributos", Environment.NewLine + "Tributos ");
            //filtrado = filtrado.Replace("SAT NO.", Environment.NewLine + "SAT No.");

            
            //rodape.Add(filtrado.Replace("Total de descontos/acrescidos sobre iten", Environment.NewLine + "Total de descontos/acrescidos sobre iten"));
            //rodape.Add(filtrado.Replace("TOTAL", Environment.NewLine + "TOTAL"));
            //rodape.Add(filtrado.Replace("Vale Alimentacao", Environment.NewLine + "Vale Alimentacao"));
            //rodape.Add(filtrado.Replace("Cartao de Credito", Environment.NewLine + "Cartao de Credito"));
            //rodape.Add(filtrado.Replace("Tributos", Environment.NewLine + "Tributos "));
            //rodape.Add(filtrado.Replace("SAT NO.", Environment.NewLine + "SAT No."));

            return filtrado;
        }

        public List<AtacadaoStaTerezinhaVar> RefinaTexto(string linhas)
        {
            string[] campos = linhas.Split("\r\n");
            string indice="";
            string codigo = "";
            string descricao = "";
            string preco = "";
            List<AtacadaoStaTerezinhaVar> listaDetalhada = new List<AtacadaoStaTerezinhaVar>();
            string erro = "";

            for (int i = 0; i < campos.Length; i++)
            {
                if (campos[i] != "")
                {
                    try
                    {
                        indice = campos[i].Substring(0, 3);
                        codigo = campos[i].Substring(4, 8);
                        int xEspaco = campos[i].IndexOf("X ");
                        descricao = campos[i].Substring(13, xEspaco - 14);
                        int fechaParenteses = campos[i].IndexOf(')');
                        preco = campos[i].Substring(fechaParenteses + 1, campos[i].Length - fechaParenteses - 1).Trim();
                        AtacadaoStaTerezinhaVar var = new AtacadaoStaTerezinhaVar(indice, codigo, descricao, preco);
                        listaDetalhada.Add(var);
                    }
                    catch
                    {
                        erro += indice + "\t" + codigo + "\t" + descricao + "\t" + preco;
                    }
                }
            }

            MessageBox.Show(erro);

            return listaDetalhada;
        }

        public void WriteTicket(List<AtacadaoStaTerezinhaVar> lista)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<html lang=\"pt-br\">" + Environment.NewLine);
            builder.Append("  <head>" + Environment.NewLine);
            builder.Append("    <meta charset=\"UTF-8\">" + Environment.NewLine);
            builder.Append("    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" + Environment.NewLine);
            builder.Append("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" + Environment.NewLine);
            builder.Append("    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css\"" + Environment.NewLine);
            builder.Append("    <title>Atacadão</title>" + Environment.NewLine);
            builder.Append("    </head>" + Environment.NewLine);
            builder.Append("  <body>" + Environment.NewLine);
            builder.Append("  <table class=\"table table-sm\">" + Environment.NewLine);
            builder.Append("    <thead>" + Environment.NewLine);
            builder.Append("      <tr>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">No</th>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">Código</th>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">Descrição</th>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">Preço</th>" + Environment.NewLine);
            builder.Append("      </tr>" + Environment.NewLine);
            builder.Append("    </thead>" + Environment.NewLine);
            builder.Append("    <tbody>" + Environment.NewLine);
            

            foreach (AtacadaoStaTerezinhaVar item in lista)
            {
                builder.Append("      <tr>" + Environment.NewLine);
                builder.Append("        <td>" + item.indice + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.codProduto + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.descricao + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.preco + "</td>" + Environment.NewLine);
                builder.Append("      </tr>" + Environment.NewLine);
            }
            
            builder.Append("    </tbody>" + Environment.NewLine);
            builder.Append("  </table>" + Environment.NewLine);

            builder.Append("  <pre>");

            foreach (var item in rodape)
            {
                builder.Append("<p>"+item+"</p>");
            }
            builder.Append("  </pre>");

            builder.Append(" </body>" + Environment.NewLine);
            builder.Append("</html>" + Environment.NewLine);

            using (FileStream fs = new FileStream("cupom.html", FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(builder.ToString());
                }
            }
        }
    }
}
