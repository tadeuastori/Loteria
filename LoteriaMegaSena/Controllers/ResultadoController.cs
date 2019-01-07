using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoteriaMegaSena.ClassObj;
using LoteriaMegaSena.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace LoteriaMegaSena.Controllers
{
    [Route("api/[controller]")]
    public class ResultadoController : Controller
    {
        [HttpGet("[action]")]
        public NumResultadoClass SortearNumeros(char tipoAposta)
        {
            try
            {
                return new NumResultadoClass() { Numeros = string.Join(" - ", ApostaNeg.SortearResultado(tipoAposta)) };
            }
            catch
            {
                return new NumResultadoClass();
            }
        }

        [HttpGet("[action]")]
        public NumResultadoClass ObterNumerosSorteados(char tipoAposta)
        {
            try
            {
                return new NumResultadoClass() { Numeros = string.Join(" - ", ApostaNeg.ObterNumerosSorteados(tipoAposta)) };
            }
            catch
            {
                return new NumResultadoClass();
            }
        }

        [HttpPost("[action]")]
        public IEnumerable<RegistrarApostaClass> CarregarGanhadores([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.RetornaGanhadores(aposta.CodigoTipoAposta);
            }
            catch
            {
                return new List<RegistrarApostaClass>();
            }
        }

        [HttpPost("[action]")]
        public IEnumerable<RegistrarApostaClass> CarregarGanhadoresQuina([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.RetornaGanhadoresQuina(aposta.CodigoTipoAposta);
            }
            catch
            {
                return new List<RegistrarApostaClass>();
            }
        }

        [HttpPost("[action]")]
        public IEnumerable<RegistrarApostaClass> CarregarGanhadoresQuadra([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.RetornaGanhadoresQuadra(aposta.CodigoTipoAposta);
            }
            catch
            {
                return new List<RegistrarApostaClass>();
            }
        }

        [HttpPost("[action]")]
        public IEnumerable<RegistrarApostaClass> RetornaApostas([FromBody]RegistrarApostaClass aposta)
        {
            try
            {
                return ApostaNeg.RetornaApostas(aposta.CodigoTipoAposta);
            }
            catch
            {
                return new List<RegistrarApostaClass>();
            }
        }
    }
}
