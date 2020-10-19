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
    public class RegistroController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(RegistroModel model, [FromServices] UsuarioRepository usuarioRepository)
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

                    TempData["MensagemSucesso"] = $"Usuário {usuario.Nome}, cadastrado(a) com sucesso. ";

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
