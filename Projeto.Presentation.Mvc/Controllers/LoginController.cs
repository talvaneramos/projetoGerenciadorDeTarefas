using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                    
                    var retornoUserName = usuarioRepository.GetByNomeAndSenha(usuario);
                    
                    ModelState.Clear();

                    if (retornoUserName != null)
                    {
                        return Redirect("/Gerenciador/Index");
                    }
                    else
                    {
                        throw new Exception("Usuário inválido. Acesso negado! ");
                    }

                }catch(Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
    }
    
}
