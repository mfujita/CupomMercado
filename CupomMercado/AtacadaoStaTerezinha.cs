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
            List<string> rodape = new List<string>();

            foreach (string campo in campos)
            {
                if (campo == i.ToString().PadLeft(3, '0'))
                {
                    filtrado += campo.Replace(i.ToString().PadLeft(3, '0'), System.Environment.NewLine + i.ToString().PadLeft(3, '0') + " ");
                    i++;
                }
                else if (campo.ToString().Contains("Total bruto de Itens"))
                {
                    rodape.Add(filtrado.Replace("Total bruto de Itens", System.Environment.NewLine + "Total bruto de Itens"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Total de descontos/acrescidos sobre iten"))
                {
                    rodape.Add(filtrado.Replace("TOTAL", Environment.NewLine + "TOTAL"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Vale Alimentacao"))
                {
                    rodape.Add(filtrado.Replace("Vale Alimentacao", Environment.NewLine + "Vale Alimentacao"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Cartao de Credito"))
                {
                    rodape.Add(filtrado.Replace("Cartao de Credito", Environment.NewLine + "Cartao de Credito"));
                    filtrado = "";
                }
                else if (campo.ToString().Contains("Tributos"))
                {
                    rodape.Add(filtrado.Replace("Tributos", Environment.NewLine + "Tributos "));
                    filtrado = "";
                }
                else if (campos[i].ToString().Contains("SAT NO."))
                {
                    rodape.Add(filtrado.Replace("SAT NO.", Environment.NewLine + "SAT No."));
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
            string indice;
            string codigo;
            string descricao;
            string preco;
            List<AtacadaoStaTerezinhaVar> listaDetalhada = new List<AtacadaoStaTerezinhaVar>();

            for (int i = 0; i < campos.Length; i++)
            {
                if (campos[i] != "")
                {
                    indice = campos[i].Substring(0, 3);
                    codigo = campos[i].Substring(4, 8);
                    int xEspaco = campos[i].IndexOf("X ");
                    descricao = campos[i].Substring(13, xEspaco - 14);
                    int fechaParenteses = campos[i].IndexOf(')');
                    preco = campos[i].Substring(fechaParenteses+1, campos[i].Length-fechaParenteses-1).Trim();

                    AtacadaoStaTerezinhaVar var = new AtacadaoStaTerezinhaVar(indice, codigo, descricao, preco);
                    listaDetalhada.Add(var);
                }
            }

            return listaDetalhada;
        }
    }
}
