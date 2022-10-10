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

        public PagueMenos(string todoTexto, string nomeArquivo)
        {
            texto = todoTexto;
            fileName = nomeArquivo;
        }

        public string SeparaLinhas()
        {
            string filtrado = "";
            int i = 1;
            string[] campos = texto.ToString().Split(' ');

            foreach (string campo in campos)
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

            return filtrado;
        }

        public string RetiraCodigo(string texto)
        {
            string[] campos = texto.Split(" \r\n");
            string semCodigo = "";
            for (int i = 0; i < campos.Length; i++)
            {
                string codigo = campos[i].Substring(3, 15);
                semCodigo += campos[i].Replace(codigo, " ") + Environment.NewLine;
            }

            return semCodigo;
        }
    }
}
