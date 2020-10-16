using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetByNome(string nome);
        Usuario GetByNomeAndSenha(string nome, string senha);

    }
}
