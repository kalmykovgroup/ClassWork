using ClassWork.Interfaces.Repositories;
using ClassWork.Interfaces.Services;

namespace ClassWork.Services
{
    public abstract class Service<T, T1> : IService<T, T1> where T : class where T1 : IRepository<T>
    {
        public T1 Repository { get; }

        public Service(T1 repository)
        {
            Repository = repository;
        }

        public virtual bool Delete(T entity) => Repository.Delete(entity);

        public virtual T? FindById(int id) => Repository.FindById(id);

        public virtual List<T> GetAll() => Repository.GetAll();

        public virtual bool Update(T entity) => Repository.Update(entity);

 
    }
}
