using System;
using System.Collections.Generic;

namespace LoteriaMegaSena.Negocio
{
    public class ApostaException : Exception
    {
        public string Mensagem { get; set; }

        public ApostaException(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
