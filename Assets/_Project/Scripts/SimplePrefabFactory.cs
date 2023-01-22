using UnityEngine;

namespace KingOfMountain
{
    public class SimplePrefabFactory : MonoBehaviour
    {     
        public T CreatePrefabInstance<T>(T prefab) where T : Object
        {
            return Instantiate(prefab);
        }
    }
}