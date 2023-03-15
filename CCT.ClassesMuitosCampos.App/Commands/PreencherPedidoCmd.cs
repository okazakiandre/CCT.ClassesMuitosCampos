using CCT.ClassesMuitosCampos.App.Domain;
using MediatR;

namespace CCT.ClassesMuitosCampos.App.Commands
{
    public class PreencherPedidoCmd : IRequest<Pedido>
    {
        public int NumeroPedido { get; set; }
        public string DataCriacao { get; set; }
        public string UltimaAtualizacao { get; set; }
        public string StatusPedido { get; set; }
        public string ValorTotal { get; set; }
        public string ValorIof { get; set; }
        public string ValorJuros { get; set; }
        public string ValorLiquido { get; set; }
        public string CodigoCupom { get; set; }
        public string PercentualDescontoCupom { get; set; }
        public string Observacoes { get; set; }
        public long CpfCliente { get; set; }
        public string NomeCliente { get; set; }
        public string DataNascimentoCliente { get; set; }
        public string TipoLogradouroCliente { get; set; }
        public string NomeLogradouroCliente { get; set; }
        public string NumeroLogradouroCliente { get; set; }
        public string NomeBairroCliente { get; set; }
        public string NomeCidadeCliente { get; set; }
        public string SiglaUfCliente { get; set; }
        public string NumeroCepCliente { get; set; }
    }
}
