using System.ComponentModel;
using DesafioTdd;

namespace TesteDesafioTdd;

public class TesteDesafioTdd
{
    Calculadora calc = new Calculadora();

    [Theory]
    [InlineData (1, 3, 4)]
    [InlineData (10, 20, 30)]
    [InlineData (0, 1, 1)]
    public void CalculaSomas( int numA, int numB, int resultado)
    {
        int resultadoCalculado;

        resultadoCalculado = calc.CalculaSoma(numA, numB);

        Assert.Equal(resultado, resultadoCalculado);
        
    }

    [Theory]
    [InlineData (4, 3, 1)]
    [InlineData (3, 4, -1)]
    [InlineData (2, 2, 0)]
    public void CalculaSubtra( int numA, int numB, int resultado)
    {
        int resultadoCalculado;

        resultadoCalculado = calc.CalculaSubt(numA, numB);

        Assert.Equal(resultado, resultadoCalculado);
        
    }

    [Theory]
    [InlineData (4, 3, 12)]
    [InlineData (3, -4, -12)]
    [InlineData (2, 2, 4)]
    public void CalculaMultiplicacao( int numA, int numB, int resultado)
    {
        int resultadoCalculado;

        resultadoCalculado = calc.CalculaMult(numA, numB);

        Assert.Equal(resultado, resultadoCalculado);
        
    }

    [Theory]
    [InlineData (4, 2, 2)]
    [InlineData (30, 10, 3)]
    [InlineData (2, 2, 1)]
    public void CalculaDivicao( int numA, int numB, int resultado)
    {
        int resultadoCalculado;

        resultadoCalculado = calc.CalculaDiv(numA, numB);

        Assert.Equal(resultado, resultadoCalculado);
        
    }

    [Fact]
    public void CalculaDivicaoZero()
    {

        Assert.Throws<DivideByZeroException>(
            () => calc.CalculaDiv(3, 0)
        );
        
    }

    [Fact]
    public void TesteHistorico()
    {

        calc.CalculaSoma(1, 2);
        calc.CalculaSoma(1, 3);
        calc.CalculaSoma(1, 4);
        calc.CalculaSoma(1, 5);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
        
    }


}