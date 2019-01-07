using LoteriaMegaSena.ClassObj;
using LoteriaMegaSena.ModelObj;
using LoteriaMegaSena.Negocio;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void RegistrarNovaApostaTest()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] {1, 2, 3, 4, 5, 6 }
            };

            ApostaNeg.RegistrarNovaAposta(apost);

            Assert.Pass();
        }

        [Test]
        public void RegistrarNovaApostaSurpresinha()
        {
            ApostaNeg.Surpresinha((char)ETipoAposta.MegaSena);

            Assert.Pass();
        }

        [Test]
        public void SortearResultadoAposta()
        {
            IList<int> resultado = ApostaNeg.SortearResultado((char)ETipoAposta.MegaSena);

            if (resultado != null)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void RetornaApostas()
        {
            IList<RegistrarApostaClass> resultado = ApostaNeg.RetornaApostas((char)ETipoAposta.MegaSena);

            if (resultado != null)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void RetornaGanhadores()
        {
            ApostaNeg.NumerosSorteados = new List<int>();
            ApostaNeg.NumerosSorteados.Add(1);
            ApostaNeg.NumerosSorteados.Add(2);
            ApostaNeg.NumerosSorteados.Add(3);
            ApostaNeg.NumerosSorteados.Add(4);
            ApostaNeg.NumerosSorteados.Add(5);
            ApostaNeg.NumerosSorteados.Add(6);

            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            ApostaNeg.RegistrarNovaAposta(apost);

            IList<RegistrarApostaClass> resultado = ApostaNeg.RetornaGanhadores((char)ETipoAposta.MegaSena);

            if (resultado != null && resultado.Count > 0)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void RetornaGanhadoresQuina()
        {
            ApostaNeg.NumerosSorteados = new List<int>();
            ApostaNeg.NumerosSorteados.Add(1);
            ApostaNeg.NumerosSorteados.Add(2);
            ApostaNeg.NumerosSorteados.Add(3);
            ApostaNeg.NumerosSorteados.Add(4);
            ApostaNeg.NumerosSorteados.Add(5);
            ApostaNeg.NumerosSorteados.Add(6);

            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 2, 3, 4, 5, 60 }
            };

            ApostaNeg.RegistrarNovaAposta(apost);

            IList<RegistrarApostaClass> resultado = ApostaNeg.RetornaGanhadoresQuina((char)ETipoAposta.MegaSena);

            if (resultado != null && resultado.Count > 0)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void RetornaGanhadoresQuadra()
        {
            ApostaNeg.NumerosSorteados = new List<int>();
            ApostaNeg.NumerosSorteados.Add(1);
            ApostaNeg.NumerosSorteados.Add(2);
            ApostaNeg.NumerosSorteados.Add(3);
            ApostaNeg.NumerosSorteados.Add(4);
            ApostaNeg.NumerosSorteados.Add(5);
            ApostaNeg.NumerosSorteados.Add(6);

            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 2, 3, 4, 50, 60 }
            };

            ApostaNeg.RegistrarNovaAposta(apost);

            IList<RegistrarApostaClass> resultado = ApostaNeg.RetornaGanhadoresQuadra((char)ETipoAposta.MegaSena);

            if (resultado != null && resultado.Count > 0)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void ObterNumerosSorteados()
        {
            IList<int> resultado = ApostaNeg.ObterNumerosSorteados((char)ETipoAposta.MegaSena);

            if (resultado != null && resultado.Count > 0)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void RegistrarNovaApostaErroNumero()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 4, 5, 6 }
            };

            try
            {
                ApostaNeg.RegistrarNovaAposta(apost);
            }
            catch (ApostaException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RegistrarNovaApostaErroTipo()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = 'R',
                Numeros = new int[] { 1, 2, 3, 4, 5, 6 }
            };

            try
            {
                ApostaNeg.RegistrarNovaAposta(apost);
            }
            catch (ApostaException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RegistrarNovaApostaErroNumero2()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 2, 2, 3, 1, 6 }
            };

            try
            {
                ApostaNeg.RegistrarNovaAposta(apost);
            }
            catch (ApostaException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RegistrarNovaApostaErroNumero3()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = null
            };

            try
            {
                ApostaNeg.RegistrarNovaAposta(apost);
            }
            catch (ApostaException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RegistrarNovaApostaErroNumero4()
        {
            RegistrarApostaClass apost = new RegistrarApostaClass()
            {
                CodigoTipoAposta = (char)ETipoAposta.MegaSena,
                Numeros = new int[] { 1, 2, 3, 4, 5, 90 }
            };

            try
            {
                ApostaNeg.RegistrarNovaAposta(apost);
            }
            catch (ApostaException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}