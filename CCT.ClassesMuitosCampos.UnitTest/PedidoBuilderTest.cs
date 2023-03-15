using CCT.ClassesMuitosCampos.App.Builders;

namespace CCT.ClassesMuitosCampos.UnitTest
{
    [TestClass]
    [TestCategory("Teste com builder")]
    public class PedidoBuilderTest
    {
        [TestMethod]
        public void DeveriaCriarNovoPedido()
        {
            var res = new PedidoBuilder()
                .CriarNovo(111, "2023-01-03", "deixar na portaria")
                .Build();

            Assert.AreEqual(111, res.Numero);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataCriacao);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataUltimaAtualizacao);
            Assert.AreEqual("deixar na portaria", res.ObservacoesEntrega);
        }

        [TestMethod]
        public void DeveriaAdicionarValoresAoPedido()
        {
            var res = new PedidoBuilder()
                .AdicionarValores("300,11", "34,2", "15", "200,80")
                .Build();

            Assert.AreEqual(300.11, res.ValorTotal);
            Assert.AreEqual(34.2, res.ValorIof);
            Assert.AreEqual(15.0, res.ValorJuros);
            Assert.AreEqual(200.8, res.ValorLiquido);
        }

        [TestMethod]
        public void DeveriaAdicionarStatusAoPedido()
        {
            var res = new PedidoBuilder()
                .AdicionarStatus("A")
                .Build();

            //não precisa testar todos os status
            Assert.AreEqual(1, res.Status);
        }

        [TestMethod]
        public void DeveriaAdicionarCupomAoPedido()
        {
            var res = new PedidoBuilder()
                .AdicionarCupom("AABBCC", "10,00")
                .Build();

            //não precisa testar o cálculo do percentual
            Assert.AreEqual("AABBCC", res.CodigoCupomAplicado);
            Assert.AreEqual(0, res.ValorDescontoCupom);
        }
    }
}