using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.API.DTOs
{
    public class ListaMensagensSalvasResult : StatusResult
    {
        public List<GravaExibeMensagensDTO> Itens { get; set; }
    }
}
