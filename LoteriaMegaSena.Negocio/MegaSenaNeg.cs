using LoteriaMegaSena.ModelObj;

namespace LoteriaMegaSena.Negocio
{
    class MegaSenaNeg : BaseTipoApostaNeg
    {

        /// <summary>
        /// Com o uso de banco de dados essa classe poderia mudar ou deixar de existir.
        /// </summary>
        public MegaSenaNeg()
        {
            TipoAposta = new TipoAposta()
            {
                ETipoAposta             = ETipoAposta.MegaSena,
                QuantidadeNumeros       = 6,
                Descricao               = "Mega Sena",
                PermiteNumerosRepetidos = false,
                ValorNumeroMaximo       = 60
            };
        }
    }
}
