using Assets.ProjectFolder.Develop.CommonServices.AssetsManagement;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System.Collections;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;

        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            yield return new WaitForSeconds(1f);
        }

        private void ProcessRegistrations()
        {
            RegisterMainMenuService(_container);

            _container.Resolve<MainMenuService>().Initialize(_container);
        }

        private void RegisterMainMenuService(DIContainer container)
        {
            container.RegisterAsSingle<MainMenuService>(c =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
                MainMenuService gameMenuServicePrefab = resourcesAssetsLoader.LoadResource<MainMenuService>(InfrastructureAssetsPath.MainMenuServicePath);
                return Instantiate(gameMenuServicePrefab);
            }).NonLazy();
        }

    }
}