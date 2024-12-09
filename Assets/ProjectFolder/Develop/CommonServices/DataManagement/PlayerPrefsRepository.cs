using UnityEngine;

namespace Assets.ProjectFolder.Develop.CommonServices.DataManagement
{
    public class PlayerPrefsRepository : IDataRepository
    {
        public bool Exists(string key) => PlayerPrefs.HasKey(key);

        public string Read(string key) => PlayerPrefs.GetString(key);

        public void Remove(string key) => PlayerPrefs.DeleteKey(key);

        public void Write(string key, string serializedData) => PlayerPrefs.SetString(key, serializedData);
    }
}
