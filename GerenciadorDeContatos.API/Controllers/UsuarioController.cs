using Microsoft.AspNetCore.Mvc;
using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Services;
using AutoMapper;
using GerenciadorDeContatos.API.Model.Erros;
using GerenciadorDeContatos.API.Model.DTOs.Usuario;

namespace GerenciadorDeContatos.API.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioService _usuarioService;
        private IMapper _autoMapper;
        public UsuarioController(UsuarioService usuarioService, IMapper autoMapper)
        {
            _usuarioService = usuarioService;
            _autoMapper = autoMapper;
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] NovoUsuarioInput usuarioDTO)
        {
            try
            {
                var usuario = _autoMapper.Map<Usuario>(usuarioDTO);
                _usuarioService.Criar(usuario);

                return Ok();
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(new JsonResult(SerializerService.ObterJsonDesserializado<List<RespostaDeErro>>(ex.Message)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUsuarioInput login)
        {
            try
            {
                var usuario = _autoMapper.Map<Usuario>(login);
                return Ok(_usuarioService.ObterLogin(usuario));
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
