using CCT.ClassesMuitosCampos.App.Builders;
using CCT.ClassesMuitosCampos.App.Domain;
using MediatR;

namespace CCT.ClassesMuitosCampos.App.Commands
{
    public class PreencherPedidoCmdHandlerBuilder : IRequestHandler<PreencherPedidoCmd, Pedido>
    {
        public Task<Pedido> Handle(PreencherPedidoCmd request,
                                   CancellationToken cancellationToken)
        {
            var pedidoBld = new PedidoBuilder()
                .CriarNovo(request.NumeroPedido,
                           request.DataCriacao,
                           request.Observacoes)
                .AdicionarStatus(request.StatusPedido)
                .AdicionarValores(request.ValorTotal,
                                    request.ValorIof,
                                    request.ValorJuros,
                                    request.ValorLiquido)
                .AdicionarCupom(request.CodigoCupom,
                                request.PercentualDescontoCupom);

            var enderecoBld = new EnderecoBuilder()
                .CriarNovo(request.TipoLogradouroCliente,
                           request.NomeLogradouroCliente,
                           request.NumeroLogradouroCliente,
                           request.NomeBairroCliente,
                           request.NomeCidadeCliente,
                           request.SiglaUfCliente,
                           request.NumeroCepCliente);

            var clienteBld = new ClienteBuilder()
                .CriarNovo(request.CpfCliente,
                           request.NomeCliente,
                           request.DataNascimentoCliente)
                .AdicionarEndereco(enderecoBld.Build());

            pedidoBld.AdicionarCliente(clienteBld.Build());

            return Task.FromResult(pedidoBld.Build());
        }
    }
}
