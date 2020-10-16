using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Permissao { get; set; }
        public string Senha { get; set; }
        
        public List<Tarefa> Tarefas { get; set; }
               
    }
}
