using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Entities
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public int IdUsuario { get; set; }
        
        public Usuario Usuario { get; set; }
    }
}
