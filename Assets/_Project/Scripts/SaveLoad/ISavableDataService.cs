namespace KingOfMountain
{
    public interface ISavableDataService
    {
        void Save<T>(string id, T data);

        T Load<T>(string id);
     
        void Delete(string id);
    }
}