using System;
using PrimeiroSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroSite.Controllers
{
    public class UsuarioLoginController
    {
        public static Response Select(string email, UsuarioLogin user)
        {
            if (!string.IsNullOrEmpty(user.Email) && user.Email.Length < 51)
            {
                if (!string.IsNullOrEmpty(user.Senha) && user.Senha.Length < 51)
                {
                    return UsuarioLoginBD.Select(user);
                }
                else
                {
                    return new Response
                    {
                        Executed = false,
                        ErrorMessage = "Senha num padrão incorreto"
                    };
                }
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "Usuario num padrão incorreto"
                };
            }

        }

        public static Response Select(string userName, out UsuarioCadastro user)
        {
            user = new UsuarioCadastro();
            if (!string.IsNullOrEmpty(userName) && userName.Length < 51)
            {
                return UsuarioLoginBD.Select(userName, out user);
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "Username invalido"
                };
            }
        }
    }
}
