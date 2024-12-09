using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.ProjectFolder.Develop.CommonServices.SceneManagement2
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract IEnumerator Run(DIContainer container, IInputSceneArgs inputArgs = null);
    }

    public class GameplayBootstrap : SceneBootstrap
    {
        public override IEnumerator Run(DIContainer container, IInputSceneArgs inputArgs = null)
        {
            if(inputArgs == null)
                throw new ArgumentException(nameof(inputArgs));
            
            GameplayInputArgs gameplayInputArgs = (GameplayInputArgs)inputArgs;

            yield return new WaitForSeconds(1f);
        }
    }

    public class MainMenuBootstrap : SceneBootstrap
    {
        public override IEnumerator Run(DIContainer container, IInputSceneArgs inputArgs = null)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
