using CCT.ClassesMuitosCampos.App.Domain;
using System.Globalization;

namespace CCT.ClassesMuitosCampos.App.Builders
{
    public class PedidoBuilder
    {
        private Pedido NovoPedido { get; set; }

        public PedidoBuilder() 
        {
            NovoPedido = new Pedido();
        }

        public PedidoBuilder Reset()
        {
            NovoPedido = new Pedido();
            return this;
        }

        public Pedido Build()
        {
            return NovoPedido;
        }

        public PedidoBuilder CriarNovo(int numero,
                                       string dataCriacao,
                                       string observacoes)
        {
            Reset();

            var data = DateTime.Parse(dataCriacao);
            NovoPedido.Numero = numero;
            NovoPedido.DataCriacao = data;
            NovoPedido.DataUltimaAtualizacao = data;
            NovoPedido.ObservacoesEntrega = observacoes;

            return this;
        }

        public PedidoBuilder AdicionarValores(string valorTotal,
                                              string valorIof,
                                              string valorJuros,
                                              string valorLiquido)
        {
            var ci = new CultureInfo("en-US");

            NovoPedido.ValorTotal = double.Parse(valorTotal.Replace(",", "."), ci);
            NovoPedido.ValorIof = double.Parse(valorIof.Replace(",", "."), ci);
            NovoPedido.ValorJuros = double.Parse(valorJuros.Replace(",", "."), ci);
            NovoPedido.ValorLiquido = double.Parse(valorLiquido.Replace(",", "."), ci);
            
            return this;
        }

        public PedidoBuilder AdicionarStatus(string siglaStatus)
        {
            NovoPedido.DefinirStatus(siglaStatus);
            return this;
        }

        public PedidoBuilder AdicionarCupom(string codigoCupom,
                                            string percentualDescontoCupom)
        {
            NovoPedido.CodigoCupomAplicado = codigoCupom;

            var ci = new CultureInfo("en-US");
            var percDesconto = double.Parse(percentualDescontoCupom.Replace(",", "."), ci);
            NovoPedido.DefinirValorDescontoCupom(percDesconto);
            
            return this;
        }

        public PedidoBuilder AdicionarCliente(Cliente cliente)
        {
            NovoPedido.Cliente = cliente;
            return this;
        }
    }
}
