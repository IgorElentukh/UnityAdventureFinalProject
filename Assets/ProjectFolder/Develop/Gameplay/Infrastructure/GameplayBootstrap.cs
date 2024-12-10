using Assets.ProjectFolder.Develop.CommonServices.AssetsManagement;
using Assets.ProjectFolder.Develop.CommonServices.GameModeService;
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
        private GameModeType _gameModeType;

        public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
        {
            _container = container;
            _gameModeType = gameplayInputArgs.GameModeType;

            ProcessRegistrations();

            Debug.Log($"Game Mode Type: {gameplayInputArgs.GameModeType}");

            yield return new WaitForSeconds(1f); 
        }

        private void ProcessRegistrations()
        {
            RegisterGameplayService(_container);

            _container.Resolve<GameplayService>().Initialize(_container, _gameModeType);
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