using UnityEngine;
using System.IO;

namespace KingOfMountain.SaveLoad
{
    public abstract class SavableDataService
    {
        protected string fileExtension;

        protected string directoryPath =>
            $"{Application.persistentDataPath}/Saves";
      
        public SavableDataService()
        {
            if (!Directory.Exists(directoryPath))
                 Directory.CreateDirectory(directoryPath);
        }

        public abstract void Save<T>(string id, T data);

        public abstract T Load<T>(string id);

        public void Delete(string id)
        {
            var filePath = GetFullFilePath(id);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        protected string GetFullFilePath(string fileName)
        {
           return $"{directoryPath}/{fileName}{fileExtension}";
        }         
    }
}