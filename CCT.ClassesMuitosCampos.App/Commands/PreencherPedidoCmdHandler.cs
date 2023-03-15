using CCT.ClassesMuitosCampos.App.Domain;
using MediatR;
using System.Globalization;

namespace CCT.ClassesMuitosCampos.App.Commands
{
    public class PreencherPedidoCmdHandler : IRequestHandler<PreencherPedidoCmd, Pedido>
    {
        public Task<Pedido> Handle(PreencherPedidoCmd request,
                                   CancellationToken cancellationToken)
        {
            var pedido = new Pedido();

            pedido.Numero = request.NumeroPedido;
            pedido.DataCriacao = DateTime.Parse(request.DataCriacao);
            pedido.DataUltimaAtualizacao = DateTime.Parse(request.DataCriacao);

            if (request.StatusPedido == "A")
            {
                pedido.Status = 1; //aberto
            }
            else if (request.StatusPedido == "E")
            {
                pedido.Status = 3; //entregue
            }
            else
            {
                pedido.Status = 2; //em andamento
            }

            var ci = new CultureInfo("en-US");

            pedido.ValorTotal = double.Parse(request.ValorTotal.Replace(",", "."), ci);
            pedido.ValorIof = double.Parse(request.ValorIof.Replace(",", "."), ci);
            pedido.ValorJuros = double.Parse(request.ValorJuros.Replace(",", "."), ci);
            pedido.ValorLiquido = double.Parse(request.ValorLiquido.Replace(",", "."), ci);

            pedido.CodigoCupomAplicado = request.CodigoCupom;
            var valorSemDesconto = pedido.ValorLiquido + pedido.ValorIof + pedido.ValorJuros;
            var percDesconto = double.Parse(request.PercentualDescontoCupom.Replace(",", "."), ci);
            pedido.ValorDescontoCupom = valorSemDesconto * percDesconto / 100;

            pedido.ObservacoesEntrega = request.Observacoes;

            var enderecoEntrega = new Endereco();
            enderecoEntrega.TipoLogradouro = request.TipoLogradouroCliente;
            enderecoEntrega.NomeLogradouro = request.NomeLogradouroCliente;
            enderecoEntrega.NumeroLogradouro = request.NumeroLogradouroCliente;
            enderecoEntrega.NomeBairro = request.NomeBairroCliente;
            enderecoEntrega.NomeCidade = request.NomeCidadeCliente;
            enderecoEntrega.SiglaUf = request.SiglaUfCliente;
            enderecoEntrega.NumeroCep = int.Parse(request.NumeroCepCliente.Replace("-", ""));

            var cliente = new Cliente();
            cliente.NumeroCpf = request.CpfCliente;
            cliente.Nome = request.NomeCliente;
            cliente.DataNascimento = DateTime.Parse(request.DataNascimentoCliente);
            cliente.Enderecos = new List<Endereco> { enderecoEntrega };

            pedido.Cliente = cliente;

            return Task.FromResult(pedido);
        }
    }
}
