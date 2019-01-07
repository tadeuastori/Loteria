using System.Linq;
using System.Collections.Generic;
using System;
using LoteriaMegaSena.ModelObj;
using LoteriaMegaSena.ClassObj;

namespace LoteriaMegaSena.Negocio
{
    public static class ApostaNeg
    {
        public static IList<Aposta> ApostasList;

        public static IList<int> NumerosSorteados;

        public static RegistrarApostaClass RegistrarNovaAposta(RegistrarApostaClass _aposta, BaseTipoApostaNeg _tipoApostaNeg = null)
        {
            BaseTipoApostaNeg tipoApostaNeg = _tipoApostaNeg ?? BaseTipoApostaNeg.Instanciar(_aposta.CodigoTipoAposta);

            if (ApostasList == null)
            {
                ApostasList = new List<Aposta>();
            }

            Aposta aposta = new Aposta()
            {
                Id = ApostasList.Count + 1,
                Data = DateTime.Now,
                Numeros = _aposta.Numeros?.OrderBy(x => x).ToList(),
                TipoAposta = tipoApostaNeg.TipoAposta
            };

            tipoApostaNeg.ValidarAposta(aposta);

            ApostasList.Add(aposta);

            return new RegistrarApostaClass(aposta);
        }

        public static IList<int> ObterNumerosSorteados(char codigoTipoAposta)
        {
            BaseTipoApostaNeg tipoApostaNeg = BaseTipoApostaNeg.Instanciar(codigoTipoAposta);
            if (NumerosSorteados == null)
            {
                NumerosSorteados = new List<int>();

                for (int i = 0; i < tipoApostaNeg.TipoAposta.QuantidadeNumeros; i++)
                {
                    NumerosSorteados.Add(0);
                }
            }
            return NumerosSorteados;
        }

        public static RegistrarApostaClass Surpresinha(char codigoTipoAposta)
        {
            BaseTipoApostaNeg tipoApostaNeg = BaseTipoApostaNeg.Instanciar(codigoTipoAposta);
            RegistrarApostaClass aposta = new RegistrarApostaClass()
            {
                CodigoTipoAposta = codigoTipoAposta,
                Numeros = tipoApostaNeg.GerarNumerosAleatorios().ToArray()

            };

            return RegistrarNovaAposta(aposta, tipoApostaNeg);
        }

        public static IList<int> SortearResultado(char codigoTipoAposta)
        {
            if (NumerosSorteados == null)
            {
                NumerosSorteados = new List<int>();
            }

            BaseTipoApostaNeg tipoApostaNeg = BaseTipoApostaNeg.Instanciar(codigoTipoAposta);
            NumerosSorteados = tipoApostaNeg.GerarNumerosAleatorios();

            return NumerosSorteados;
        }

        public static IList<RegistrarApostaClass> RetornaGanhadores(char codigoTipoAposta)
        {
            IList<Aposta> ganhadores = ApostasList.Where(x => x.TipoAposta.CodigoTipoAposta == codigoTipoAposta &&
                                                              x.Numeros.All(NumerosSorteados.Contains))
                                                  .ToList();

            return ganhadores.Select(x => new RegistrarApostaClass(x)).ToList();
        }

        public static IList<RegistrarApostaClass> RetornaGanhadoresQuina(char codigoTipoAposta)
        {
            IList<Aposta> ganhadoresQuina = new List<Aposta>();

            if (NumerosSorteados.Count > 5)
            {
                ganhadoresQuina = ApostasList.Where(x => x.TipoAposta.CodigoTipoAposta == codigoTipoAposta &&
                                                         x.Numeros.Concat(NumerosSorteados)
                                                         .GroupBy(y => y)
                                                         .Select(y => new { Value = y.Key, Count = y.Count() })
                                                         .Where(y => y.Count > 1)
                                                         .Count() == 5
                ).ToList();
            }

            return ganhadoresQuina.Select(x => new RegistrarApostaClass(x)).ToList();
        }

        public static IList<RegistrarApostaClass> RetornaGanhadoresQuadra(char codigoTipoAposta)
        {
            IList<Aposta> ganhadoresQuadra = new List<Aposta>();

            if (NumerosSorteados.Count > 4)
            {
                ganhadoresQuadra = ApostasList.Where(x => x.TipoAposta.CodigoTipoAposta == codigoTipoAposta &&
                                                          x.Numeros.Concat(NumerosSorteados)
                                                          .GroupBy(y => y)
                                                          .Select(y => new
                                                          {
                                                              Value = y.Key,
                                                              Count = y.Count()
                                                          })
                                                          .Where(y => y.Count > 1)
                                                          .Count() == 4
                ).ToList();
            }
            return ganhadoresQuadra.Select(x => new RegistrarApostaClass(x)).ToList();
        }

        public static IList<RegistrarApostaClass> RetornaApostas(char tipoAposta)
        {
            return ApostasList.Where(x => x.TipoAposta.CodigoTipoAposta == tipoAposta).Select(x => new RegistrarApostaClass(x)).ToList();
        }
    }
}
