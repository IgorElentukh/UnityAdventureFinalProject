using UnityEngine;

namespace Assets.ProjectFolder.Develop.CommonServices.GameModeService
{
    public class GameModeService
    {
        public GameModeType SelectedMode { get; private set; }
        public void SetGameMode(GameModeType mode)
        {
            SelectedMode = mode;
            Debug.Log($"Режим игры: {mode}");
        }
    }
}