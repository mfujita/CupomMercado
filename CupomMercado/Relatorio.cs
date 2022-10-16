﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupomMercado
{
    public class Relatorio
    {
        string linhas;
        string fileName = "";
        string data = "";
        List<string> header;
        List<string> footer;
        List<Dados> listaDetalhada;
        int indexHeader;
        int indexFooter;

        public Relatorio(string textoOrganizado, string nomeArquivoTxt)
        {
            linhas = textoOrganizado;
            fileName = nomeArquivoTxt + ".html";
        }

        public void GetHeader()
        {
            string[] campos = linhas.Split("\r\n");
            indexHeader = 0;
            header = new List<string>();

            for (int i = 0; i < campos.Length; i++)
                if (campos[i] == "")
                {
                    indexHeader = i;
                    break;
                }

            for (int i = 0; i < indexHeader; i++)
                header.Add(campos[i]);
        }

        public void GetFooter()
        {
            string[] campos = linhas.Split("\r\n");
            footer = new List<string>();

            for (int i = indexHeader+1; i < campos.Length; i++)
                if (campos[i] == "")
                    indexFooter = i;

            for (int i = indexFooter; i < campos.Length; i++)
                footer.Add(campos[i]);
        }

        public List<Dados> SeparaColunas()
        {
            string[] campos = linhas.Split("\r\n");
            string indice = "";
            string codigo = "";
            string descricao = "";
            string preco = "";
            listaDetalhada = new List<Dados>();

            for (int i = indexHeader+1; i < indexFooter; i++)
            {
                if (campos[i] != "")
                {
                    indice = campos[i].Substring(0, 3);
                    codigo = "";
                    int ultimoEspaco = campos[i].LastIndexOf(' ');

                    preco = campos[i].Substring(ultimoEspaco + 1, campos[i].Length - ultimoEspaco - 1);
                    descricao = campos[i].Substring(4, campos[i].Length - preco.Length - 4);
                    Dados var = new Dados(indice, "", descricao, preco);
                    listaDetalhada.Add(var);
                }
            }

            return listaDetalhada;
        }

        public void WriteTicket()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<html lang=\"pt-br\">" + Environment.NewLine);
            builder.Append("  <head>" + Environment.NewLine);
            builder.Append("    <meta charset=\"UTF-8\">" + Environment.NewLine);
            builder.Append("    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" + Environment.NewLine);
            builder.Append("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" + Environment.NewLine);
            builder.Append("    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css\"" + Environment.NewLine);
            //builder.Append("    <title>Todo Dia</title>" + Environment.NewLine);
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

            foreach (var item in header)
            {
                builder.Append("      <h5 align=center>" + item + "</h5>");
            }

            builder.Append("");

            foreach (Dados item in listaDetalhada)
            {
                builder.Append("      <tr>" + Environment.NewLine);
                builder.Append("        <td>" + item.indice.Trim() + "</td>" + Environment.NewLine);
                //builder.Append("        <td>" + item.codProduto.Trim() + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.descricao.Trim() + "</td>" + Environment.NewLine);
                builder.Append("        <td>" + item.preco.Trim() + "</td>" + Environment.NewLine);
                builder.Append("      </tr>" + Environment.NewLine);
            }

            builder.Append("    </tbody>" + Environment.NewLine);
            builder.Append("  </table>" + Environment.NewLine);

            builder.Append("  <pre>");

            foreach (var item in footer)
            {
                builder.Append("<br>" + item);
            }
            builder.Append("  </pre>");

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
