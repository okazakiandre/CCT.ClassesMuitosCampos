using CCT.ClassesMuitosCampos.App.Commands;

namespace CCT.ClassesMuitosCampos.UnitTest
{
    [TestClass]
    [TestCategory("Teste com muitos setups")]
    public class PreencherPedidoCmdHandlerMuitosSetupsTest
    {
        [TestMethod]
        public async Task DeveriaPreencherPedidoComNumeroEDatas()
        {
            var req = new PreencherPedidoCmd
            {
                NumeroPedido = 111,
                DataCriacao = "2023-01-03",
                //sem esses campos dá erro
                ValorTotal = "0",
                ValorIof = "0",
                ValorJuros = "0",
                ValorLiquido = "0",
                PercentualDescontoCupom = "0",
                DataNascimentoCliente = "1990-10-15",
                NumeroCepCliente = "0"
            };
            var hdl = new PreencherPedidoCmdHandler();

            var res = await hdl.Handle(req, CancellationToken.None);

            Assert.AreEqual(111, res.Numero);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataCriacao);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataUltimaAtualizacao);
        }

        [TestMethod]
        public async Task DeveriaPreencherPedidoComValores()
        {
            var req = new PreencherPedidoCmd
            {
                ValorTotal = "300,11",
                ValorIof = "34,2",
                ValorJuros = "15",
                ValorLiquido = "200,80",
                //sem esses campos dá erro
                DataCriacao = "2023-01-03",
                PercentualDescontoCupom = "0",
                DataNascimentoCliente = "1990-10-15",
                NumeroCepCliente = "0"
            };
            var hdl = new PreencherPedidoCmdHandler();

            var res = await hdl.Handle(req, CancellationToken.None);

            Assert.AreEqual(300.11, res.ValorTotal);
            Assert.AreEqual(34.2, res.ValorIof);
            Assert.AreEqual(15.0, res.ValorJuros);
            Assert.AreEqual(200.8, res.ValorLiquido);
        }
    }
}