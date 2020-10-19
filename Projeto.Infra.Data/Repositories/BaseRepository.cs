using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Insert(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return dataContext.Set<T>().Find(id);
        }
        public virtual Usuario GetByNomeAndSenha(Usuario usuario)
        {
                return dataContext.Set<Usuario>().FirstOrDefault<Usuario>(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);

        
        }

    }
}
