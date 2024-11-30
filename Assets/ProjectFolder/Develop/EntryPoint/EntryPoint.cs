using Assets.ProjectFolder.Develop.CommonServices.AssetsManagement;
using Assets.ProjectFolder.Develop.CommonServices.CoroutinePerformer;
using Assets.ProjectFolder.Develop.CommonServices.LoadingScreen;
using Assets.ProjectFolder.Develop.DI;
using System;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.EntryPoint
{
    internal class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bootstrap _gameBootstrap;
        
        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new DIContainer();

            RegisterResourcesAssetsLoader(projectContainer);
            RegisterCoroutinePerformer(projectContainer);
            RegisterSceneLoader(projectContainer);

            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(_gameBootstrap.Run(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }

        private void RegisterResourcesAssetsLoader(DIContainer projectContainer)
    => projectContainer.RegisterAsSingle(c => new ResourcesAssetsLoader());

        private void RegisterCoroutinePerformer(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinePerformer>(c =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
                CoroutinePerformer coroutinePerformerPrefab = resourcesAssetsLoader.LoadResource<CoroutinePerformer>(InfrastructureAssetsPath.CoroutinePerformerPath);
                return Instantiate(coroutinePerformerPrefab);
            });
        }

        private void RegisterSceneLoader(DIContainer container)
        {
            container.RegisterAsSingle<ILoadingCurtain>(c =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
                StandardLoadingCurtain standardLoadingCurtainPrefab = resourcesAssetsLoader.LoadResource<StandardLoadingCurtain>(InfrastructureAssetsPath.LoadingCurtainPath);
                return Instantiate(standardLoadingCurtainPrefab);
            });
        }
    }
}
