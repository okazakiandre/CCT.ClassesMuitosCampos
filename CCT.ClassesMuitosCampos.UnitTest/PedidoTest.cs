using CCT.ClassesMuitosCampos.App.Domain;

namespace CCT.ClassesMuitosCampos.UnitTest
{
    [TestClass]
    [TestCategory("Teste com builder")]
    public class PedidoTest
    {
        [TestMethod]
        public void DeveriaDefinirStatusAberto()
        {
            var ped = new Pedido();
            ped.DefinirStatus("A");
            Assert.AreEqual(1, ped.Status);
        }

        [TestMethod]
        public void DeveriaDefinirStatusEntregue()
        {
            var ped = new Pedido();
            ped.DefinirStatus("E");
            Assert.AreEqual(3, ped.Status);
        }

        [TestMethod]
        public void DeveriaDefinirStatusEmAndamento()
        {
            var ped = new Pedido();
            ped.DefinirStatus("Z");
            Assert.AreEqual(2, ped.Status);
        }
    }
}