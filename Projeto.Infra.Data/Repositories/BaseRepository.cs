using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Insert(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dataContext.Entry(entity).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dataContext.Set<T>().Find(id);
        }

        public Usuario GetByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByNomeAndSenha(string nome, string senha)
        {
            throw new NotImplementedException();
        }
                
    }
}
