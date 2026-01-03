using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraApp
{
    public class Calculadora
    {
        private List<string> valoreshistorico;
        private string data;

        public Calculadora(string data)
        {
            valoreshistorico = new List<string>();
            this.data = data;
        }

        public int somar(int numero1, int numero2)
        {
            int resultado = numero1 + numero2;

            valoreshistorico.Insert(0, "Resultado: " + resultado + " - data: " + data);

            return resultado;
        }

        public int subtrair(int numero1, int numero2)
        {
            int resultado = numero1 - numero2;

            valoreshistorico.Insert(0, "Resultado: " + resultado + " - data: " + data);

            return resultado;
        }

        public int multiplicar(int numero1, int numero2)
        {
            int resultado = numero1 * numero2;

            valoreshistorico.Insert(0, "Resultado: " + resultado + " - data: " + data);

            return resultado;
        }

        public int dividir(int numero1, int numero2)
        {
            int resultado = numero1 / numero2;

            valoreshistorico.Insert(0, "Resultado: " + resultado + " - data: " + data);

            return resultado;
        }

        public List<string> historico()
        {
            if (valoreshistorico.Count > 3)
            {
                valoreshistorico.RemoveRange(3, valoreshistorico.Count - 3);
            }

            return new List<string>(valoreshistorico);
        }
    }
}
