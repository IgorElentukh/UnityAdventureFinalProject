using Assets.ProjectFolder.Develop.CommonServices.GameModeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ProjectFolder.Develop.CommonServices.SceneManagement
{
    public interface IInputSceneArgs
    {

    }

    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(GameModeType type)
        {
            GameModeType = type;
        }
        public GameModeType GameModeType {get;}
    }

    public class MainMenuInputArgs : IInputSceneArgs
    {

    }
}
