
namespace LoteriaMegaSena.ModelObj
{
    public class TipoAposta
    {
        public virtual string Descricao { get; set; }

        public virtual char CodigoTipoAposta { get; set; }

        public virtual ETipoAposta ETipoAposta
        {
            get
            {
                return (ETipoAposta)CodigoTipoAposta;
            }
            set
            {
                CodigoTipoAposta = (char)value;
            }
        }

        public virtual int QuantidadeNumeros { get; set; }

        public virtual bool PermiteNumerosRepetidos { get; set; }

        /// <summary>
        /// Valor numerico maximo possivel para uma aposta
        /// </summary>
        public virtual int ValorNumeroMaximo { get; set; }
    }

    public enum ETipoAposta
    {
        MegaSena = 'M'
    }
}
