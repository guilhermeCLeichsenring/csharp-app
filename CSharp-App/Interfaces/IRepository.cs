namespace CSharp_App.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);

        public void Delete(T entity);

        public void Update(T entity);

        public T GetById(int id);

        public IEnumerable<T> GetAll();


    }
}
