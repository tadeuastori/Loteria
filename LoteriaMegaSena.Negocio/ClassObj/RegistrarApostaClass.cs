using LoteriaMegaSena.ModelObj;
using System.Linq;

namespace LoteriaMegaSena.ClassObj
{
    public class RegistrarApostaClass
    {
        public RegistrarApostaClass() { }

        public RegistrarApostaClass(Aposta aposta)
        {
            Id                  = aposta.Id;
            Numeros             = aposta.Numeros.OrderBy(x => x).ToArray();
            CodigoTipoAposta    = aposta.TipoAposta.CodigoTipoAposta;
            DescricaoTipoAposta = aposta.TipoAposta.Descricao;
            Data                = aposta.Data.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            NumerosExib         = string.Join(" - ", aposta.Numeros.OrderBy(x => x));
        }

        public int Id { get; set; }

        public int[] Numeros { get; set; }

        public string NumerosExib { get; set; }

        public char CodigoTipoAposta { get; set; }

        public string DescricaoTipoAposta { get; set; }

        public string Data { get; set; }

        public string MensagemErro { get; set; }
    }
}
