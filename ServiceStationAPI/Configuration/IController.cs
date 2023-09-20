namespace ServiceStationAPI.Configuration
{
    public interface IController<T> where T : class
    {
        public Task<List<T>> Create(T t);
        public Task<List<T>> Edit(int id, string name);
        public Task<List<T>> Delete(int id);
        public Task<List<T>> Select();
    }
}
