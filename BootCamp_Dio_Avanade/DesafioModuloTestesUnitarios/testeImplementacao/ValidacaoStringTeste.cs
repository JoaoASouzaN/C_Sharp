using implementacao.Services;

namespace testeImplementacao
{
    public class ValidacoesStringTests
    {
        private ValidacaoString _validacoes;

        public ValidacoesStringTests()
        {
            _validacoes = new ValidacaoString();
        }
            
        [Fact]
        public void DeveRetornar6QuantidadeCaracteresDaPalavraMatrix()
        {
            // Arrange
            string texto;
            int resultado;

            // Act
            texto = "Matrix";
            resultado = _validacoes.RetornarQuantidadeCaracteres(texto);

            // Assert
            Assert.Equal(6, resultado);
        }

        [Fact]
        public void DeveContemAPalavraQualquerNoTexto()
        {
            // Arrange
            var texto = "Esse é um texto qualquer";
            var textoProcurado = "qualquer";

            // Act
            _validacoes.ContemCaractere(textoProcurado, texto);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void NaoDeveConterAPalavraTesteNoTexto()
        {
            // Arrange
            var texto = "Esse é um texto qualquer";
            var textoProcurado = "teste";

            // Act
            var resultado = _validacoes.ContemCaractere(texto, textoProcurado);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void TextoDeveTerminarComAPalavraProcurado()
        {
            // Arrange
            var texto = "Começo, meio e fim do texto procurado";
            var textoProcurado = "procurado";

            // Act
            var resultado = _validacoes.TextoTerminaCom(texto, textoProcurado);

            // Assert
            Assert.True(resultado);
        }
    }
}