using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.API
{
    public class StatusResult
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; }
        public List<string> Erros { get; set; }
    }
}
