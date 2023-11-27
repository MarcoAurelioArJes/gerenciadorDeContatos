using GerenciadorDeContatos.API.Model;
using GerenciadorDeContatos.API.Repositorio;
using GerenciadorDeContatos.API.Services.ValidacoesService;

namespace GerenciadorDeContatos.API.Services
{
    public class UsuarioService
    {
        private UsuarioRepositorio _usuarioRepositorio;
        private TokenService _tokenService;
        private ValidarUsuarioService _validarUsuarioService;
        public UsuarioService(UsuarioRepositorio usuarioRepositorio, 
                              TokenService tokenService,
                              ValidarUsuarioService validarUsuarioService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _tokenService = tokenService;
            _validarUsuarioService = validarUsuarioService;
        }

        public void Criar(Usuario usuario)
        {
            usuario.VerificarSeObjetoEhNulo();
            _validarUsuarioService.Validar(usuario);

            usuario.Senha = SenhaHashService.ObterSenhaHash(usuario.Senha);
            _usuarioRepositorio.Criar(usuario);
        }

        public string ObterLogin(Usuario usuario)
        {
            usuario.VerificarSeObjetoEhNulo();

            var usuarioDoBanco = _usuarioRepositorio.ObterPorEmail(usuario.Email);
            if (usuarioDoBanco != null
                && SenhaHashService.ObterSeSenhaEhValida(usuarioDoBanco.Senha, usuario.Senha))
                return _tokenService.ObterToken(usuarioDoBanco);

            throw new BadHttpRequestException("A senha ou o email do usuário estão incorretas", StatusCodes.Status401Unauthorized);
        }
    }
}
