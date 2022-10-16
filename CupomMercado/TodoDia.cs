using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupomMercado
{
    public class TodoDia
    {
        string texto = "";
        string fileName = "";
        string data = "";

        public TodoDia(string todoTexto, string nomeArquivo)
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
                    if (campo == i.ToString().PadLeft(3, '0'))
                    {
                        filtrado += campo.Replace(i.ToString().PadLeft(3, '0'), System.Environment.NewLine + i.ToString().PadLeft(3, '0') + " ");
                        i++;
                    }
                    else if (campo.Equals(Environment.NewLine))
                        i++;
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
    }
}
