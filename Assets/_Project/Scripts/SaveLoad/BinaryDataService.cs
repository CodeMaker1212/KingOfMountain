using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KingOfMountain.SaveLoad
{
    public class BinaryDataService : SavableDataService
    { 
        private BinaryFormatter _formatter = new BinaryFormatter();
       
        public BinaryDataService() : base()
        {
            fileExtension = ".save";
        }

        public override void Save<T>(string id, T data)
        {
            FileStream fileStream = File.Create(GetFullFilePath(id));
            _formatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public override T Load<T>(string id)
        {
            var filePath = GetFullFilePath(id);

            T data = default;

            if (File.Exists(filePath))
            {
                FileStream fileStream = File.Open(filePath, FileMode.Open);
                data = (T)_formatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return data;
        }      
    }
}