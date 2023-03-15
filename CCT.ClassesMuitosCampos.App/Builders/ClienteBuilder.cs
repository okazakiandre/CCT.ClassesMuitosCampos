using CCT.ClassesMuitosCampos.App.Domain;

namespace CCT.ClassesMuitosCampos.App.Builders
{
    public class ClienteBuilder
    {
        private Cliente NovoCliente { get; set; }

        public ClienteBuilder() 
        {
            NovoCliente = new Cliente();
        }

        public ClienteBuilder Reset()
        {
            NovoCliente = new Cliente();
            return this;
        }

        public Cliente Build()
        {
            return NovoCliente;
        }

        public ClienteBuilder CriarNovo(long cpf,
                                        string nome,
                                        string dataNascimento)
        {
            Reset();

            NovoCliente.NumeroCpf = cpf;
            NovoCliente.Nome = nome;
            NovoCliente.DataNascimento = DateTime.Parse(dataNascimento);
            NovoCliente.Enderecos = new List<Endereco>();

            return this;
        }

        public ClienteBuilder AdicionarEndereco(Endereco endereco)
        {
            NovoCliente.Enderecos.Add(endereco);
            return this;
        }
    }
}
