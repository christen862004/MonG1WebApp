namespace MonG1WebApp.Repository
{
    public interface IRepository<T> 
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
