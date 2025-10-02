namespace MonG1WebApp.Repository
{
    public class Service : IService
    {
        public Service()
        {
            Id=Guid.NewGuid().ToString();//unique string
        }
        public string Id { get;}
    }
}
