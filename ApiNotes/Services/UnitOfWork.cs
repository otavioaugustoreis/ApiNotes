using ApiNotes.Context;
using ApiNotes.Interfaces;

namespace ApiNotes.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        //Entender o que da para fazer com as propriedades, tipo assim: public ILogin _loginRepo => throw new NotImplementedException();
        //Private por que quero que o acesso delas seja encapsulado somente nessa classe
        private ILogin? _loginRepo ;

        private  INote? _noteRepo;

        private IUser? _userRepo;

        private IPaths? _PathRepo;
        //Testar com private
        public AppDbContext _context;

        public ILogin LoginService 
        {
            //Operador de coalescência nula ??
            /*Toda vez quando você faz a instância ele verifica o operador com o coalescencia nula e caso não tenha cria uma
             * e fazemos por que quando uma aplicação é iniciada sempre instanciamos
             */
            get
            { 
                return _loginRepo = _loginRepo ?? new LoginService(_context);
                /*
                 * O código acima é a mesma coisa que esse debaixo
                    if (_loginRepo is null)
                {
                        _loginRepo =  new LoginService(_context)
                }
                    return _login reto
                 */
            }
        } 

        public INote NoteService
        {
            get
            {
                return _noteRepo = _noteRepo ?? new NoteService(_context);
            } 
        }

        public IUser UserService
        {
            get 
            {
                return _userRepo = _userRepo ?? new UserService(_context); 
            }
        }

        public IPaths PathsService
        {
            get
            {
                return _PathRepo = _PathRepo ?? new PathsService(_context); 
            }
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        //Esse método confirma todos as mudanças do banco de dados
        public void Commit()
        {
                _context.SaveChanges();
        }

        //Esse método é usado para liberar recursos associados ao _context
        public void Dispose() 
        {
            //_context faz diversas instancias e o Dispose() descarta instancias de um jeito apropriado
            _context.Dispose();
        }
    }
}
