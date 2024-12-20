using ClassWork.Interfaces.Repositories;

namespace ClassWork.Interfaces.Services
{
    public interface IService<T, T1> : IRepository<T> where T : class where T1 : IRepository<T>
    {
        T1 Repository { get; }
    }
}
