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
        private const string AvailableLetters = "ABCDEFG";
        private const string AvailableDigits = "1234567890";
        private const int SequenceLength = 5;

        private DIContainer _container;
        private GameModeType _gameModeType;

        private string _sequence;
        private string _userInput = "";
        private bool isGameOver = false;


        public void Initialize(DIContainer container, GameModeType type)
        {
            _container = container;
            _gameModeType = type;

        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            if(isGameOver)
                if (Input.GetKeyDown(KeyCode.Space))
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGamePlayArgs(new MainMenuInputArgs()));

            if (Input.anyKeyDown && string.IsNullOrEmpty(Input.inputString) == false)
            {
                char key = Input.inputString[0];

                _userInput += key;
                Debug.Log($"Игрок ввёл: {_userInput}");

                if (_userInput.Length == _sequence.Length)
                {
                   CheckInput();
                   isGameOver = true;
                }    
            }
        }
        private void StartGame()
        {
            _sequence = GenerateSequence(_gameModeType);

            Debug.Log($"Последовательность: {_sequence}");
        }

        private string GenerateSequence(GameModeType mode)
        {
            string sequence = "";

            string source = mode == GameModeType.Letters ? AvailableLetters : AvailableDigits;

            for (int i = 0; i < SequenceLength; i++)
            {
                char randomLetter = source[Random.Range(0, source.Length)];
                sequence += randomLetter;
            }

            return sequence;
        }
        private void CheckInput()
        {
            if (_userInput.ToUpper() == _sequence)
                Debug.Log("Победа! Нажмите пробел, чтобы вернуться в меню.");
            else
                Debug.Log("Проигрыш! Нажмите пробел, чтобы начать заново.");
        }
    }
}