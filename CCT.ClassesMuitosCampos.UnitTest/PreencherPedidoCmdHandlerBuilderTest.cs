using CCT.ClassesMuitosCampos.App.Commands;

namespace CCT.ClassesMuitosCampos.UnitTest
{
    [TestClass]
    [TestCategory("Teste com builder (fluxo)")]
    public class PreencherPedidoCmdHandlerBuilderTest
    {
        [TestMethod]
        public async Task DeveriaPreencherPedido()
        {
            var req = new PreencherPedidoCmd
            {
                NumeroPedido = 111,
                DataCriacao = "2023-01-03",
                StatusPedido = "A",
                ValorTotal = "300,11",
                ValorIof = "34,2",
                ValorJuros = "15",
                ValorLiquido = "200,80",
                CodigoCupom = "AABBCC",
                PercentualDescontoCupom = "10,00",
                Observacoes = "deixar na portaria",
                CpfCliente = 11122233344,
                NomeCliente = "cliente teste",
                DataNascimentoCliente = "1990-10-15",
                TipoLogradouroCliente = "rua",
                NomeLogradouroCliente = "boa vista",
                NumeroLogradouroCliente = "123",
                NomeBairroCliente = "vila 1",
                NomeCidadeCliente = "cidade 2",
                SiglaUfCliente = "SP",
                NumeroCepCliente = "12345-010"
            };
            var hdl = new PreencherPedidoCmdHandlerBuilder();

            var res = await hdl.Handle(req, CancellationToken.None);

            Assert.AreEqual(111, res.Numero);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataCriacao);
            Assert.AreEqual(new DateTime(2023, 1, 3), res.DataUltimaAtualizacao);
            Assert.AreEqual(1, res.Status);
            Assert.AreEqual(300.11, res.ValorTotal);
            Assert.AreEqual(34.2, res.ValorIof);
            Assert.AreEqual(15.0, res.ValorJuros);
            Assert.AreEqual(200.8, res.ValorLiquido);
            Assert.AreEqual("AABBCC", res.CodigoCupomAplicado);
            Assert.AreEqual(25.0, res.ValorDescontoCupom);
            Assert.AreEqual("deixar na portaria", res.ObservacoesEntrega);
            Assert.AreEqual(11122233344, res.Cliente.NumeroCpf);
            Assert.AreEqual("cliente teste", res.Cliente.Nome);
            Assert.AreEqual(new DateTime(1990, 10, 15), res.Cliente.DataNascimento);
            Assert.AreEqual("rua", res.Cliente.Enderecos[0].TipoLogradouro);
            Assert.AreEqual("boa vista", res.Cliente.Enderecos[0].NomeLogradouro);
            Assert.AreEqual("123", res.Cliente.Enderecos[0].NumeroLogradouro);
            Assert.AreEqual("vila 1", res.Cliente.Enderecos[0].NomeBairro);
            Assert.AreEqual("cidade 2", res.Cliente.Enderecos[0].NomeCidade);
            Assert.AreEqual("SP", res.Cliente.Enderecos[0].SiglaUf);
            Assert.AreEqual(12345010, res.Cliente.Enderecos[0].NumeroCep);
        }
    }
}