using implementacao.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ValidacaoString validar = new ValidacaoString();
        ValidacaoLista validaLista = new ValidacaoLista();

        string texto = "Texto de teste do texto";
        string textoProcurado = "teste";
        string procuraTexto = "texto";

        int quantidadeCaracteres = validar.RetornarQuantidadeCaracteres(texto);
        bool contemCaractere = validar.ContemCaractere(texto, textoProcurado);
        bool terminaCom = validar.TextoTerminaCom(texto, procuraTexto);

        Console.WriteLine($"O texto possui {quantidadeCaracteres} caracteres.");

        if (contemCaractere)
        {
            Console.WriteLine($"O texto possui '{textoProcurado}'.");
        }
        else
        {
            Console.WriteLine($"O texto não possui '{textoProcurado}'.");
        }

        if (terminaCom)
        {
            Console.WriteLine($"O texto termina com '{procuraTexto}'.");
        }
        else
        {
            Console.WriteLine($"O texto não termina com '{textoProcurado}'.");
        }

        List<int> lista = new List<int> { -5, -1, 8, 9, 0, 7, -1 };
        Console.WriteLine("Lista original: " + string.Join(", ", lista));

        List<int> listaResultado = validaLista.RemoverNumerosNegativos(lista);
        Console.WriteLine("Lista sem os números negativos: " + string.Join(", ", listaResultado));

        int numeroProcura = 5;
        bool contemNumero = validaLista.ListaContemDeterminadoNumero(lista, numeroProcura);

        if (contemNumero)
        {
            Console.WriteLine($"A lista possui o número {numeroProcura}.");
        }
        else
        {
            Console.WriteLine($"A lista não possui o número {numeroProcura}.");
        }

        int multiplicaLista = 2;

        List<int> listaMultiplicada = validaLista.MultiplicarNumerosLista(lista, multiplicaLista);
        Console.WriteLine($"Lista com os elementos multiplicados por {multiplicaLista}: " + string.Join(", ", listaMultiplicada));

        int maiorNumero = validaLista.RetornarMaiorNumeroLista(lista);
        Console.WriteLine($"O maior número da lista é {maiorNumero}.");

        int menorNumero = validaLista.RetornarMenorNumeroLista(lista);
        Console.WriteLine($"O menor número da lista é {menorNumero}.");
    }
}