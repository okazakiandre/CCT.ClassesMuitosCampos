using MediatR;

namespace CCT.ClassesMuitosCampos.App.Domain
{
    public class Pedido
    {
        public int Numero { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public short Status { get; set; }
        public double ValorTotal { get; set; }
        public double ValorIof { get; set; }
        public double ValorJuros { get; set; }
        public double ValorLiquido { get; set; }
        public string CodigoCupomAplicado { get; set; }
        public double ValorDescontoCupom { get; set; }
        public string ObservacoesEntrega { get; set; }
        public Cliente Cliente { get; set; }

        public Pedido() { }

        public Pedido(int numero,
                      DateTime dataCriacao,
                      DateTime dataUltimaAtualizacao,
                      short status,
                      double valorTotal,
                      double valorIof,
                      double valorJuros,
                      double valorLiquido,
                      string codigoCupomAplicado,
                      double valorDescontoCupom,
                      string observacoesEntrega,
                      long cpfCliente,
                      string nomeCliente,
                      DateTime dataNasctoCliente,
                      string tipoLogradouroCliente,
                      string nomeLogradouroCliente,
                      string numeroLogradouroCliente,
                      string nomeBairroCliente,
                      string nomeCidadeCliente,
                      string siglaUfCliente,
                      int numeroCepCliente)
        {
            Numero = numero;
            DataCriacao = dataCriacao;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Status = status;
            ValorTotal = valorTotal;
            ValorIof = valorIof;
            ValorJuros = valorJuros;
            ValorLiquido = valorLiquido;
            CodigoCupomAplicado = codigoCupomAplicado;
            ValorDescontoCupom = valorDescontoCupom;
            ObservacoesEntrega = observacoesEntrega;

            var enderecoCliente = new Endereco
            {
                TipoLogradouro = tipoLogradouroCliente,
                NomeLogradouro = nomeLogradouroCliente,
                NumeroLogradouro = numeroLogradouroCliente,
                NomeBairro = nomeBairroCliente,
                NomeCidade = nomeCidadeCliente,
                SiglaUf = siglaUfCliente,
                NumeroCep = numeroCepCliente
            };

            Cliente = new Cliente
            {
                NumeroCpf = cpfCliente,
                Nome = nomeCliente,
                DataNascimento = dataNasctoCliente,
                Enderecos = new List<Endereco> { enderecoCliente }
            };
        }

        public void DefinirStatus(string siglaStatus)
        {
            if (siglaStatus == "A")
            {
                Status = 1; //aberto
            }
            else if (siglaStatus == "E")
            {
                Status = 3; //entregue
            }
            else
            {
                Status = 2; //em andamento
            }
        }

        public void DefinirValorDescontoCupom(double percentualDesconto)
        {
            var valorSemDesconto = ValorLiquido + ValorIof + ValorJuros;
            ValorDescontoCupom = valorSemDesconto * percentualDesconto / 100;
        }
    }
}