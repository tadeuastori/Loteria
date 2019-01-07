using System;
using System.Linq;
using System.Collections.Generic;
using LoteriaMegaSena.ModelObj;

namespace LoteriaMegaSena.Negocio
{
    public abstract class BaseTipoApostaNeg
    {
        public TipoAposta TipoAposta;

        public void ValidarAposta(Aposta aposta)
        {
            if (aposta.Numeros == null)
            {
                throw new ApostaException($"Necessário informar {TipoAposta.QuantidadeNumeros} números");
            }
            if (aposta.Numeros.Count != TipoAposta.QuantidadeNumeros)
            {
                throw new ApostaException($"Quantidade de números inválida para o tipo de aposta {TipoAposta.Descricao}. Necessário informar {TipoAposta.QuantidadeNumeros} números.");
            }
            else if (!TipoAposta.PermiteNumerosRepetidos && aposta.Numeros.GroupBy(x => x).Select(x => new { Value = x.Key, Count = x.Count() }).Any(x => x.Count > 1))
            {
                throw new ApostaException("Aposta não deve possuir números repetidos");
            }
            else if (aposta.Numeros.Any(x => x > TipoAposta.ValorNumeroMaximo))
            {
                throw new ApostaException($"Aposta não deve possuir número maior que {TipoAposta.ValorNumeroMaximo}");
            }
        }

        public static BaseTipoApostaNeg Instanciar(char tipoAposta)
        {
            switch (tipoAposta)
            {
                case (char)ETipoAposta.MegaSena:
                    return new MegaSenaNeg();
            }
            throw new ApostaException("Tipo de aposta não encontrado");
        }

        private int RetornaNumeroAleatorio(Random random)
        {
            Random _random = random ?? new Random();

            return _random.Next(1, TipoAposta.ValorNumeroMaximo);
        }

        public IList<int> GerarNumerosAleatorios()
        {
            IList<int> retorno = new List<int>();

            Random random = new Random();
            while (retorno.Count < TipoAposta.QuantidadeNumeros)
            {
                int numero = RetornaNumeroAleatorio(random);

                if (!retorno.Contains(numero))
                {
                    retorno.Add(numero);
                }
            }
            return retorno.OrderBy(x => x).ToList();
        }
    }
}
