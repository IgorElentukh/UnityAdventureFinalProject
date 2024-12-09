using Assets.ProjectFolder.Develop.CommonServices.GameModeService;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.ProjectFolder.Develop.Gameplay.Infrastructure
{
    public class GameplayService : MonoBehaviour
    {
        private DIContainer _container;
        private GameModeService _gameModeService;
        private SceneSwitcher _sceneSwitcher;

        private string _sequence;
        private int _currentInputIndex;

        public void Initialize(DIContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _gameModeService = _container.Resolve<GameModeService>();
            _sceneSwitcher = _container.Resolve<SceneSwitcher>();

            StartGame();
        }

        private void StartGame()
        {
            _sequence = GenerateSequence(_gameModeService.SelectedMode);
            _currentInputIndex = 0;

            Debug.Log($"Последовательность: {_sequence}");
        }


        private string GenerateSequence(GameModeType mode)
        {
            string sequence = "";

            switch(mode)
            {
                case GameModeType.Letters:
                    sequence = GenerateRandomLetters();
                    break;

                //case GameModeType.Figures:
                //    sequence = GenerateRandomFigures();
                //    break;
            }

            return sequence;
        }

        private string GenerateRandomLetters()
        {
            string result = "";
            string availableLetters = "ABCDEFG";

            for (int i = 0; i < 5; i++)
            {
                char randomLetter = availableLetters[Random.Range(0, availableLetters.Length)];
                result += randomLetter;
            }

            return result;
        }
    }
}