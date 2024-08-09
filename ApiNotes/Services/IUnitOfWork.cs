using ApiNotes.Interfaces;

namespace ApiNotes.Services
{

    //O UnitOfWork tem que atuar como um repositório de um  repositório
    public interface IUnitOfWork
    {

        //Através dessas propriedades eu vou poder ter as instâncias desses objetos
        /*ICrud<ILogin> LoginService { get; } eu não uso assim pq eu poderia perder alguma função especifica na interface, por exemplo, se eu tenho a função 
         GetLoginPorUsuario, usando desta forma com ICrud, eu não conseguiria usarf o SaveChanges()*/
        ILogin LoginService { get; }
        INote NoteService   { get; }
        IUser UserService   { get; }
        IPaths PathsService { get; }
        
        //Método que vai salvar
        void Commit();
    }
}
