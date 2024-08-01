using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace ApiNotes.Interfaces.InterfacesController
{
    public interface IController<T>
    {
        public  ActionResult<IEnumerable<T>> Get();
        public ActionResult<T> Post(T entidade);
        public ActionResult<T> Put(int id, T entidade);
        public ActionResult<T> Delete(int id);
        public ActionResult<T> GetId(int id);
    }
}
