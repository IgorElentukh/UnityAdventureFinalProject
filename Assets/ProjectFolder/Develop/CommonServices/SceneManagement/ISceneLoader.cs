using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.ProjectFolder.Develop.CommonServices.SceneManagement
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(SceneID sceneID, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
    }
}
