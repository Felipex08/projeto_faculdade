using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.API.DTOs
{
    public class GravaMensagensResult : StatusResult
    {
        public GravaExibeMensagensDTO Item { get; set; }
    }
}
