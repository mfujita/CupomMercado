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

        public AtacadaoStaTerezinha(string todoTexto)
        {
            texto = todoTexto;
        }

        public string SeparaLinhas()
        {
            string filtrado = "";
            int i = 1;
            string[] campos = texto.ToString().Split(' ');

            foreach (string campo in campos)
            {
                if (campo == i.ToString().PadLeft(3, '0'))
                {
                    filtrado += campo.Replace(i.ToString().PadLeft(3, '0'), System.Environment.NewLine + i.ToString().PadLeft(3, '0') + " ");
                    i++;
                }
                else
                {
                    filtrado += campo + " ";
                }
            }

            filtrado = filtrado.Replace("Total bruto de Itens", System.Environment.NewLine + "Total bruto de Itens");
            filtrado = filtrado.Replace("Total de descontos/acrescidos sobre iten", Environment.NewLine + "Total de descontos/acrescidos sobre iten");
            filtrado = filtrado.Replace("TOTAL", Environment.NewLine + "TOTAL");
            filtrado = filtrado.Replace("Vale Alimentacao", Environment.NewLine + "Vale Alimentacao");
            filtrado = filtrado.Replace("Cartao de Credito", Environment.NewLine + "Cartao de Credito");
            filtrado = filtrado.Replace("Tributos", Environment.NewLine + "Tributos ");
            filtrado = filtrado.Replace("SAT NO.", Environment.NewLine + "SAT No.");

            return filtrado;
        }
    }
}
