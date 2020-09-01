using contrato_prestacao_models.Prestacao;
using contrato_prestacao_service.Prestacao;
using System;
using System.Collections.Generic;
using Xunit;

namespace contrato_prestacao_test.Prestacao
{
    public class PrestacaoServiceTest
    {
        public PrestacaoService PrestacaoService { get; set; }

        [Fact]
        public void Teste_CalculaStatus_Sucesso()
        {
            var _prestacao = new List<PrestacaoModel>();

            _prestacao.Add(new PrestacaoModel()
            {
                DataVencimento = new DateTime(2020, 09, 05),
                Valor = 100,
            });

            _prestacao.Add(new PrestacaoModel()
            {
                DataVencimento = new DateTime(2020, 08, 30),
                Valor = 100,
            });

            _prestacao.Add(new PrestacaoModel()
            {
                DataVencimento = new DateTime(2020, 09, 05),
                DataPagamento = new DateTime(2020, 09, 01),
                Valor = 100,
            });

            PrestacaoService = new PrestacaoService(_prestacao);
            var _prestacaoValid = PrestacaoService.CalculaStatus(_prestacao);

            Assert.True(_prestacaoValid[0].Status == contrato_prestacao_models.Enum.StatusPrestacaoEnum.Aberta);
            Assert.True(_prestacaoValid[1].Status == contrato_prestacao_models.Enum.StatusPrestacaoEnum.Atrasada);
            Assert.True(_prestacaoValid[2].Status == contrato_prestacao_models.Enum.StatusPrestacaoEnum.Baixada);
        }

        [Fact]
        public void Teste_CalculaStatus_ValidaValor_Falha()
        {
            var _prestacao = new List<PrestacaoModel>();

            _prestacao.Add(new PrestacaoModel()
            {
                DataVencimento = new DateTime(2020, 09, 05),
                DataPagamento = new DateTime(2020, 09, 01),
            });

            try
            {
                PrestacaoService = new PrestacaoService(_prestacao);
                var _prestacaoValid = PrestacaoService.CalculaStatus(_prestacao);
            }
            catch (Exception ex)
            {
                Assert.Equal("Valor inválido!", ex.Message);
            }         
        }

        [Fact]
        public void Teste_CalculaStatus_ValidaDataVencimento_Falha()
        {
            var _prestacao = new List<PrestacaoModel>();

            _prestacao.Add(new PrestacaoModel()
            {
                DataPagamento = new DateTime(2020, 09, 01),
                Valor = 100
            });

            try
            {
                PrestacaoService = new PrestacaoService(_prestacao);
                var _prestacaoValid = PrestacaoService.CalculaStatus(_prestacao);
            }
            catch (Exception ex)
            {
                Assert.Equal("Data Vencimento inválida!", ex.Message);
            }
        }
    }
}
