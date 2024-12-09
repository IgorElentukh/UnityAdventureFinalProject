using Assets.ProjectFolder.Develop.CommonServices.AssetsManagement;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System;
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
            RegisterGameplayService(_container);

            _container.Resolve<GameplayService>().Initialize(_container);
        }

        private void RegisterGameplayService(DIContainer container)
        {
            container.RegisterAsSingle<GameplayService>(c =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
                GameplayService gameplayServicePrefab = resourcesAssetsLoader.LoadResource<GameplayService>(InfrastructureAssetsPath.GameplayServicePath);
                return Instantiate(gameplayServicePrefab);
            }).NonLazy();
        }
    }
}