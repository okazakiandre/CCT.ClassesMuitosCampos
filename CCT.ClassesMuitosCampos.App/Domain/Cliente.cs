namespace CCT.ClassesMuitosCampos.App.Domain
{
    public class Cliente
    {
        public long NumeroCpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public Cliente() 
        {
            Enderecos = new List<Endereco>();
        }

        public Cliente(long cpf,
                       string nome,
                       DateTime dataNascto,
                       List<Endereco> enderecos) 
        {
            if (cpf < 1)
            {
                throw new ArgumentException("O campo NumeroCpf é obrigatório.");
            }
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O campo Nome é obrigatório.");
            }
            if (nome.Split(' ').Length < 2)
            {
                throw new ArgumentException("O campo Nome deve conter ao menos um sobrenome.");
            }
            if (dataNascto <= DateTime.MinValue)
            {
                throw new ArgumentException("O campo DataNascimento é obrigatório.");
            }
            if (enderecos is null)
            {
                throw new ArgumentException("O campo Enderecos é obrigatório.");
            }
            if (!enderecos.Any())
            {
                throw new ArgumentException("O campo Enderecos não pode ser vazio.");
            }

            NumeroCpf = cpf;
            Nome = nome;
            DataNascimento = dataNascto;
            Enderecos = enderecos;
        }
    }
}
