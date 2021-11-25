using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFaculdade.API;
using ProjetoFaculdade.API.Database;
using ProjetoFaculdade.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GravaValoresController : ControllerBase
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public GravaValoresController(ApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }

        [HttpPost("ArmazenaMensagens")]
        public ActionResult<GravaMensagensResult> ArmazenaMensagens(string mensagem)
        {
            var ret = new GravaMensagensResult();
            try
            {
                if (mensagem != null)
                {
                    var row = new tb_dados();
                    row.mensagem = mensagem;

                    _applicationDBContext.tb_dados.Add(row);
                    _applicationDBContext.SaveChanges();
                    ret.Item = new GravaExibeMensagensDTO 
                    {
                        Id = row.id
                    };
                }
                else
                {
                    throw new Exception("É necessário incluir uma mensagem!");
                }
                ret.Item.Mensagens = mensagem;

                return Ok(ret);
            }
            catch (Exception e)
            {
                ret.Sucesso = false;
                ret.Mensagem = e.Message;
                return StatusCode(500, ret);
            }
        }

        [HttpGet("ListaMensagens")]
        public ActionResult<ListaMensagensSalvasResult> ListaMensagens(string busca, int cursor, int limite)
        {
            var ret = new ListaMensagensSalvasResult();
            ret.Itens = new List<GravaExibeMensagensDTO>();
            try
            {
                if(String.IsNullOrEmpty(busca))
                {
                    var aux = _applicationDBContext.tb_dados.OrderBy(x => x.id).Skip(cursor).Take(limite).ToList();

                    foreach (var row in aux)
                    {
                        ret.Itens.Add(new GravaExibeMensagensDTO
                        {
                            Id = row.id,
                            Mensagens = row.mensagem
                        });
                    }
                }
                else
                {
                    var result = _applicationDBContext.tb_dados.Where(x => EF.Functions.Like(x.mensagem, "%" + busca + "%")).OrderBy(x => x.id).Skip(cursor).Take(limite).ToList();

                    foreach(var row in result)
                    {
                        ret.Itens.Add(new GravaExibeMensagensDTO
                        {
                            Id = row.id,
                            Mensagens = row.mensagem
                        });
                    }
                }

                return Ok(ret);
            }
            catch (Exception e)
            {
                ret.Sucesso = false;
                ret.Mensagem = e.Message;
                return StatusCode(500, ret);
            }
        }

        [HttpDelete("RemoverMensagens")]
        public ActionResult<StatusResult> RemoverMensagens(int id)
        {
            var ret = new StatusResult();
            try
            {
                var row = _applicationDBContext.tb_dados.Find(id);
                _applicationDBContext.tb_dados.Remove(row);
                _applicationDBContext.SaveChanges();

                return Ok(ret);
            }
            catch (Exception e)
            {
                ret.Sucesso = false;
                ret.Mensagem = e.Message;
                return StatusCode(500, ret);
            }
        }
    }
}
