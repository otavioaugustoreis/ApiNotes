namespace ApiNotes.Interfaces
{
    public interface ICrud<T>
    {
        public IEnumerable<T> Get();
        public T GetId(int id);
        public T Post(T entidade);
        public T Put(int id, T entidade);
        public T Delete(int id);
    }
}
