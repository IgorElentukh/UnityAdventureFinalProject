using Assets.ProjectFolder.Develop.CommonServices.DataManagement;
using Assets.ProjectFolder.Develop.CommonServices.DataManagement.DataProviders;
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

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(2)));

            if (Input.GetKeyDown(KeyCode.S))
            {
                ISaveLoadService saveLoadService = _container.Resolve<ISaveLoadService>();

                if (saveLoadService.TryLoad(out PlayerData playerdata))
                {
                    playerdata.Money++;
                    playerdata.CompletedLevels.Add(playerdata.Money);

                    saveLoadService.Save(playerdata);
                }
                else
                {
                    PlayerData originPlayerData = new PlayerData()
                    {
                        Money = 0,
                        CompletedLevels = new()
                    };

                    saveLoadService.Save(originPlayerData);
                }
            }
        }
    }
}