using UnityEngine;
using System.IO;

namespace KingOfMountain.SaveLoad
{
    public class JsonDataService : SavableDataService
    {
        private string _jsonText = string.Empty;

        public JsonDataService() : base()
        {
            fileExtension = ".json";
        }

        public override void Save<T>(string id, T data)
        {
            _jsonText = JsonUtility.ToJson(data);
            File.WriteAllText(GetFullFilePath(id), _jsonText);
        }

        public override T Load<T>(string id)
        {
            var filePath = GetFullFilePath(id);

            T data = default;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                data = JsonUtility.FromJson<T>(json);
            }

            return data;
        }      
    }
}