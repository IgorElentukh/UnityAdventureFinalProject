using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System.Collections;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.Gameplay.Infrastructure
{
    public class GameplayBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            Debug.Log($"Loading resources for level {gameplayInputArgs.LevelNumber}");
            Debug.Log("Creating of character");
            Debug.Log("Scene is ready");

            yield return new WaitForSeconds(1f); 
        }

        private void ProcessRegistrations()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
        }
    }
}