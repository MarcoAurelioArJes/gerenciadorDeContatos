using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GerenciadorDeContatos.API.Model;
using Microsoft.AspNetCore.Authorization;
using GerenciadorDeContatos.API.Services;
using GerenciadorDeContatos.API.Model.Erros;
using GerenciadorDeContatos.API.Model.DTOs.Contato;
using GerenciadorDeContatos.API.Model.DTOs.Telefone;

namespace GerenciadorDeContatos.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ContatoController : Controller
    {
        private ContatoService _contatoService;
        private IMapper _mapper;

        public ContatoController(ContatoService contatoService, IMapper mapper)
        {
            _contatoService = contatoService;
            _mapper = mapper;
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] NovoContatoInput contatoDTO)
        {
            try
            {
                var contato = _mapper.Map<Contato>(contatoDTO);
                _contatoService.Criar(contato);
                return NoContent();
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(new JsonResult(ex.Message.ObterJsonDesserializado<List<RespostaDeErro>>()));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpPatch("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromBody] AtualizarContatoInput contatoDTO)
        {
            try
            {
                var contato = _mapper.Map<Contato>(contatoDTO);
                _contatoService.Atualizar(id, contato);
                return NoContent();
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(new JsonResult(ex.Message.ObterJsonDesserializado<List<RespostaDeErro>>()));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var contatos = _mapper.Map<List<ParcialContatoView>>(_contatoService.ObterTodos());
                return Ok(contatos);
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode, new JsonResult(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpGet("obterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var contatoDetalhado = _mapper.Map<DetalhesContatoView>(_contatoService.ObterPorId(id));
                return Ok(contatoDetalhado);
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode, new JsonResult(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [Authorize(Roles = "ADM")]
        [HttpDelete("remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _contatoService.Remover(id);
                return NoContent();
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode, new JsonResult(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }

        [HttpPatch("atualizartelefone/{idContato}/{idTelefone}")]
        public IActionResult AtualizarTelefone(int idContato, int idTelefone, [FromBody] NovoTelefoneInput telefoneInput)
        {
            try
            {
                _contatoService.AtualizarTelefone(idContato, idTelefone, telefoneInput);
                return NoContent();
            }
            catch (BadHttpRequestException ex)
            {
                return StatusCode(ex.StatusCode, new JsonResult(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
        }
    }
}
