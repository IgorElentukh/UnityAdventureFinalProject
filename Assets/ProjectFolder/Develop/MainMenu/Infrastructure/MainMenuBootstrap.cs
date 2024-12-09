using Assets.ProjectFolder.Develop.CommonServices.DataManagement;
using Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders;
using Assets.ProjectFolder.Develop.CommonServices.GameModeService;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.MainMenu.Infrastructure
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        private DIContainer _container;
        private GameModeService _gameModeService;

        public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
        {
            _container = container;

            ProcessRegistrations();

            yield return new WaitForSeconds(1f);
        }

        private void ProcessRegistrations()
        {
            RegisterGameModeTypeService(_container);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _container.Resolve<PlayerDataProvider>().Save();
            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
                LoadGameplaySceneWith(GameModeType.Figures);
            else if(Input.GetKeyDown(KeyCode.Alpha2))
                LoadGameplaySceneWith(GameModeType.Letters);
        }

        private void RegisterGameModeTypeService(DIContainer container)
            => container.RegisterAsSingle<GameModeService>(c => new GameModeService());

        private void LoadGameplaySceneWith(GameModeType type)
        {
            _gameModeService = _container.Resolve<GameModeService>();
            _gameModeService.SetGameMode(type);
            _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(1)));
        }
    }
}