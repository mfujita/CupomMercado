using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CupomMercado
{
    public class PagueMenos
    {
        string texto = "";
        string fileName = "";
        string data = "";

        public PagueMenos(string todoTexto, string nomeArquivo)
        {
            texto = todoTexto;
            fileName = nomeArquivo + ".html";
        }

        public string SeparaLinhas()
        {
            string filtrado = "";
            int i = 1;
            string[] campos = texto.ToString().Split(' ');

            foreach (string campo in campos)
            {
                if (i == 1)
                {
                    filtrado += campo + " ";
                    i++;
                }
                else
                {
                    if (campo == i.ToString().PadLeft(2, '0'))
                    {
                        filtrado += campo.Replace(i.ToString().PadLeft(2, '0'), System.Environment.NewLine + i.ToString().PadLeft(2, '0') + " ");
                        i++;
                    }
                    else if (campo.Equals("Total") || campo.Equals("TOTAL"))
                        break;
                    else
                    {
                        filtrado += campo + " ";
                    }
                }
            }

            return filtrado;
        }

        public string RetiraCodigo(string texto)
        {
            string[] campos = texto.Split(" \r\n");
            string semCodigo = "";
            for (int i = 0; i < campos.Length; i++)
            {
                string codigo = campos[i].Substring(3, 15);
                semCodigo += campos[i].Replace(codigo, " ").Trim() + Environment.NewLine;
            }

            return semCodigo;
        }

        public List<Dados> SeparaColunas(string linhas)
        {
            string[] campos = linhas.Split("\r\n");
            string indice = "";
            string codigo = "";
            string descricao = "";
            string preco = "";
            List<Dados> listaDetalhada = new List<Dados>();
            string erro = "";

            for (int i = 0; i < campos.Length; i++)
            {
                if (campos[i] != "")
                {
                    //    try
                    //    {
                    indice = campos[i].Substring(0, 3);
                        codigo = "";
                        //string[] cadaLinha = campos[i].Split(' ');
                        int ultimoEspaco = campos[i].LastIndexOf(' ');
                        
                        preco = campos[i].Substring(ultimoEspaco+1, campos[i].Length-ultimoEspaco-1);
                    descricao = campos[i].Substring(4, campos[i].Length - preco.Length - 4);
                    Dados var = new Dados(indice, codigo, descricao, preco);
                        listaDetalhada.Add(var);
                    //}
                    //catch
                    //{
                    //    erro += indice + "\t" + codigo + "\t" + descricao + "\t" + preco;
                    //    //MessageBox.Show(erro);
                    //}
                }
            }

            return listaDetalhada;
        }

        public void WriteTicket(List<Dados> lista)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<html lang=\"pt-br\">" + Environment.NewLine);
            builder.Append("  <head>" + Environment.NewLine);
            builder.Append("    <meta charset=\"UTF-8\">" + Environment.NewLine);
            builder.Append("    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" + Environment.NewLine);
            builder.Append("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" + Environment.NewLine);
            builder.Append("    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css\"" + Environment.NewLine);
            builder.Append("    <title>Pague Menos</title>" + Environment.NewLine);
            builder.Append("    </head>" + Environment.NewLine);
            builder.Append("  <body>" + Environment.NewLine);
            builder.Append("  <table class=\"table table-sm\">" + Environment.NewLine);
            builder.Append("    <thead>" + Environment.NewLine);
            builder.Append("      <tr>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">No</th>" + Environment.NewLine);
            //builder.Append("        <th scope=\"col\">Código</th>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">Descrição</th>" + Environment.NewLine);
            builder.Append("        <th scope=\"col\">Preço</th>" + Environment.NewLine);
            builder.Append("      </tr>" + Environment.NewLine);
            builder.Append("    </thead>" + Environment.NewLine);
            builder.Append("    <tbody>" + Environment.NewLine);

            foreach (Dados item in lista)
            {
                builder.Append("      <tr>" + Environment.NewLine);
                builder.Append("        <td>" + item.indice + "</td>" + Environment.NewLine);
                //builder.Append("        <td>" + item.codProduto + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.descricao + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.preco + "</td>" + Environment.NewLine);
                builder.Append("      </tr>" + Environment.NewLine);
            }

            builder.Append("    </tbody>" + Environment.NewLine);
            builder.Append("  </table>" + Environment.NewLine);

            //builder.Append("  <pre>");

            //foreach (var item in rodape)
            //{
            //    builder.Append("<p>" + item + "</p>");
            //}
            //builder.Append("  </pre>");

            builder.Append(" </body>" + Environment.NewLine);
            builder.Append("</html>" + Environment.NewLine);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(builder.ToString());
                }
            }
        }
    }
}
