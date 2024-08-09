
using ApiNotes.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace ApiNotes.Interfaces
{
    //Condição para falar que o T precisa ser uma classe
    //Lembre-se não salvar nenhuma classe por que o Unit Of Work já faz esse trabalho.
    //Na classe abstrata, não podemos fazer selects com Wheres especificos
    public  class Repository<T> : ICrud<T> where T : class
    {

        protected readonly AppDbContext _context;

        //Injeção de dependência:
        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public T Delete(T entidade)
        {
             _context.Set<T>().Remove(entidade);
            return entidade;
        }

        public IEnumerable<T> Get()
        {
            //o as AsNoTracking possibilita que não gerenciamos os estados da memória, mas oi por que usar ? obs: não posso usar para alteração
            // Esse Set<> serve para consultar o banco de dados
            return _context.Set<T>().AsNoTracking().ToList();
        }

        //Predicate é a expressão lambda!
        public T? GetId(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }


        public T Post(T entidade)
        {
             _context.Set<T>().Add(entidade);
            
            return entidade;
        }

        public T Put(T entidade)
        {
            _context.Set<T>().Update(entidade);
            
            return entidade;
        }
    }
}
