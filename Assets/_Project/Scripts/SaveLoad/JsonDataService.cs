using UnityEngine;
using System.IO;

namespace KingOfMountain
{
    public class JsonDataService : ISavableDataService
    {
        public void Save<T>(string id, T data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(GetFullFilePath(id), json);
        }

        public T Load<T>(string id)
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

        public void Delete(string id)
        {
            var filePath = GetFullFilePath(id);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        private string GetFullFilePath(string fileName) =>
            $"{Application.persistentDataPath}/{fileName}.json";
    }
}