using CCT.ClassesMuitosCampos.App.Domain;

namespace CCT.ClassesMuitosCampos.App.Builders
{
    public class EnderecoBuilder
    {
        private Endereco NovoEndereco { get; set; }

        public EnderecoBuilder() 
        {
            NovoEndereco = new Endereco();
        }

        public EnderecoBuilder Reset()
        {
            NovoEndereco = new Endereco();
            return this;
        }

        public Endereco Build()
        {
            return NovoEndereco;
        }

        public EnderecoBuilder CriarNovo(string tipoLogradouro,
                                         string nomeLogradouro,
                                         string numeroLogradouro,
                                         string nomeBairro,
                                         string nomeCidade,
                                         string siglaUf,
                                         string numeroCep)
        {
            Reset();

            NovoEndereco.TipoLogradouro = tipoLogradouro;
            NovoEndereco.NomeLogradouro = nomeLogradouro;
            NovoEndereco.NumeroLogradouro = numeroLogradouro;
            NovoEndereco.NomeBairro = nomeBairro;
            NovoEndereco.NomeCidade = nomeCidade;
            NovoEndereco.SiglaUf = siglaUf;
            NovoEndereco.NumeroCep = int.Parse(numeroCep.Replace("-", ""));

            return this;
        }
    }
}
