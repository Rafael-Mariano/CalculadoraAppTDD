using System;
using Xunit;
using CalculadoraApp;

namespace CalculadoraApp.Test
{
    public class TestCalculadora
    {
        public Calculadora classeCalculadora()
        {
            string data = "02/08/2024";
            Calculadora calculadora = new Calculadora(data);

            return calculadora;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 7, 12)]
        public void Somar(int numero1, int numero2, int resultado)
        {
            Calculadora calculadora = classeCalculadora();

            int resultadoSomar = calculadora.somar(numero1, numero2);

            Assert.Equal(resultado, resultadoSomar);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        public void Subtrair(int numero1, int numero2, int resultado)
        {
            Calculadora calculadora = classeCalculadora();

            int resultadoSubtrair = calculadora.subtrair(numero1, numero2);

            Assert.Equal(resultado, resultadoSubtrair);
        }

        [Theory]
        [InlineData(4, 3, 12)]
        public void Multiplicar(int numero1, int numero2, int resultado)
        {
            Calculadora calculadora = classeCalculadora();

            int resultadoMultiplicar = calculadora.multiplicar(numero1, numero2);

            Assert.Equal(resultado, resultadoMultiplicar);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        public void Dividir(int numero1, int numero2, int resultado)
        {
            Calculadora calculadora = classeCalculadora();

            int resultadoDividir = calculadora.dividir(numero1, numero2);

            Assert.Equal(resultado, resultadoDividir);
        }

        [Fact]
        public void DividirPor0()
        {
            Calculadora calculadora = classeCalculadora();

            Assert.Throws<DivideByZeroException>(
                () => calculadora.dividir(4, 0)
            );
        }

        [Fact]
        public void Historico()
        {
            Calculadora calculadora = classeCalculadora();

            calculadora.somar(1, 2);
            calculadora.subtrair(5, 3);
            calculadora.multiplicar(4, 3);
            calculadora.dividir(10, 2);

            var lista = calculadora.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
