using System;
using System.Collections.Generic;

namespace LoteriaMegaSena.ModelObj
{
    public class Aposta
    {
        public virtual int Id { get; set; }

        public virtual DateTime Data { get; set; }

        public virtual IList<int> Numeros { get; set; }

        public virtual TipoAposta TipoAposta { get; set; }
    }
}
