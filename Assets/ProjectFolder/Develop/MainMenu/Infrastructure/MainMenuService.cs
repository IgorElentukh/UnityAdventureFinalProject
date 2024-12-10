using Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders;
using Assets.ProjectFolder.Develop.CommonServices.GameModeService;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.MainMenu.Infrastructure
{
    public class MainMenuService : MonoBehaviour
    {
        private DIContainer _container;
        private SceneSwitcher _switcher;
        public void Initialize(DIContainer container)
        {
            _container = container;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _container.Resolve<PlayerDataProvider>().Save();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
                LoadGameplaySceneWith(GameModeType.Digits);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                LoadGameplaySceneWith(GameModeType.Letters);
        }

        private void LoadGameplaySceneWith(GameModeType type)
        {
            _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(type)));
        }
    }
}