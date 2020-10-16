using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Presentation.Mvc.Models;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginModel model, 
            [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = usuarioRepository.GetByNomeAndSenha(model.Nome, model.Senha);

                    if(usuario != null)
                    {

                    }
                    else
                    {
                        throw new Exception("Usuário inválido. Acesso negado. ");
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Registro(AccountRegistroModel model,
            [FromServices] UsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Permissao = model.Permissao;
                    usuario.Senha = model.Senha;

                    usuarioRepository.Insert(usuario);

                    TempData["MensagemSucesso"] = $"Usuário(a) {usuario.Nome}, cadastrado(a) com sucesso. ";

                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }
            return View();
        }
    }
}
