namespace ClassWork.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T? FindById(int id);
        public bool Delete(T entity);
        public bool Update(T entity);
    }
}
