using GerenciadorDeContatos.API.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorDeContatos.API.Services
{
    public class TokenService
    {
        public const string PrivateKey = "LSHDJ@#*!¨&#%@&*#%¨*@%!#¨&*(SAED&*(SA¨D&**AS%DÄSD¨&(ASD*(&AS¨D*&ASD%ÄS¨&*DASDÄS*&D%¨SA*DASD*&AS¨%D*&AS%DAS*D%AS*&D%AS*D&ÄS%D*&AS¨D*&ASD%*&AS%DAS";

        public string ObterToken(Usuario usuario)
        {


            var chaveSimetrica = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PrivateKey));

            var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

            var claims = ObterPayload(usuario);
            var jwtToken = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private Claim[] ObterPayload(Usuario usuario)
        {
            return new Claim[]
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Cargo.ToString())
            };
        }
    }
}
