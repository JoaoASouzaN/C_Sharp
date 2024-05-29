using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementacao.Services
{
    public class ValidacaoLista
    {
        public List<int> RemoverNumerosNegativos(List<int> lista)
        {
            var listaSemNegativos = lista.Where(x => x > 0);
            return listaSemNegativos.ToList();
        }

        public bool ListaContemDeterminadoNumero(List<int> lista, int numero)
        {
            var contem = lista.Contains(numero);
            return contem;
        }

        public List<int> MultiplicarNumerosLista(List<int> lista, int multiplicador)
        {
            return lista.Select(x => x * multiplicador).ToList();
        }

        public int RetornarMaiorNumeroLista(List<int> lista)
        {
            return lista.Max();
        }

        public int RetornarMenorNumeroLista(List<int> lista)
        {
            return lista.Min();
        } 
    }
}