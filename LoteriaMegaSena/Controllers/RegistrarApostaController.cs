using Microsoft.AspNetCore.Mvc;
using LoteriaMegaSena.Negocio;
using LoteriaMegaSena.ClassObj;

namespace LoteriaMegaSena.Controllers
{
    [Route("api/[controller]")]
    public class RegistrarApostaController : Controller
    {
        [HttpGet("[action]")]
        public ConfiguracaoApostaClass BuscarConfiguracao(char tipoAposta)
        {
            try
            {
                BaseTipoApostaNeg tipoApostaNeg = BaseTipoApostaNeg.Instanciar(tipoAposta);
                return new ConfiguracaoApostaClass()
                {
                    MaiorNumero       = tipoApostaNeg.TipoAposta.ValorNumeroMaximo,
                    QuantidadeNumeros = tipoApostaNeg.TipoAposta.QuantidadeNumeros,
                    Descricao         = tipoApostaNeg.TipoAposta.Descricao
                };
            }
            catch (ApostaException ex)
            {
                return new ConfiguracaoApostaClass()
                {
                    MensagemErro = ex.Mensagem
                };
            }
        }

        [HttpPost("[action]")]
        public RegistrarApostaClass RegistarAposta([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.RegistrarNovaAposta(aposta);
            }
            catch (ApostaException ex)
            {
                return new RegistrarApostaClass()
                {
                    MensagemErro = ex.Mensagem
                };
            }
        }

        [HttpPost("[action]")]
        public RegistrarApostaClass Surpresinha([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.Surpresinha(aposta.CodigoTipoAposta);
            }
            catch (ApostaException ex)
            {
                return new RegistrarApostaClass()
                {
                    MensagemErro = ex.Mensagem
                };
            }
        }


    }
}