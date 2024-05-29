using System.Globalization;

namespace DesafioTdd
{
    public class Calculadora
    {
        int num1;
        int num2;

        int resultado;

        private List<string> historico;

        public Calculadora()
        {
            historico = new List<string>();
        }

        public int CalculaSoma(int num1, int num2)
        {
            resultado = num1 + num2;
            historico.Insert(0, "Res: " + resultado);

            return resultado;
        }

        public int CalculaSubt(int num1, int num2)
        {
            resultado = num1 - num2;
            historico.Insert(0, "Res: " + resultado);

            return resultado;
        }

        public int CalculaMult(int num1, int num2)
        {
            resultado = num1 * num2;
            historico.Insert(0, "Res: " + resultado);

            return resultado;
        }

        public int CalculaDiv(int num1, int num2)
        {
            resultado = num1 / num2;
            historico.Insert(0, "Res: " + resultado);

            return resultado;
        }

        public List<string> Historico()
        {
            historico.RemoveRange(3, historico.Count - 3);
            return historico;
        }

    }
}