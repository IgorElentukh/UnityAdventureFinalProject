using Assets.ProjectFolder.Develop.CommonServices.CoroutinePerformer;
using Assets.ProjectFolder.Develop.CommonServices.LoadingScreen;
using Assets.ProjectFolder.Develop.CommonServices.SceneManagement;
using Assets.ProjectFolder.Develop.DI;
using Assets.ProjectFolder.Develop.Gameplay.Infrastructure;
using Assets.ProjectFolder.Develop.MainMenu.Infrastructure;
using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace Assets.ProjectFolder.Develop.CommonServices.SceneManagement2
{
    public class SceneSwitcher
    {
        private const string ErrorSceneTransitionMessage = "This transition is not possible";

        private DIContainer _projectContainer;
        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;

        private DIContainer _currentSceneContainer;

        public SceneSwitcher(ICoroutinePerformer coroutinePerformer, ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, DIContainer projectContainer)
        {
            _coroutinePerformer = coroutinePerformer;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _projectContainer = projectContainer;
        }

        public void SwitchSceneTo(SceneID sceneID, IInputSceneArgs nextSceneArgs = null) 
            => _coroutinePerformer.StartPerform(ProcessSwitchSceneTo(sceneID, nextSceneArgs));

        private IEnumerator ProcessSwitchSceneTo(SceneID sceneID, IInputSceneArgs nextSceneArgs = null)
        {
            if(sceneID == SceneID.Bootstrap || sceneID == SceneID.Empty)
                throw new ArgumentException(nameof(sceneID));
            
            _loadingCurtain.Show();

            yield return _sceneLoader.LoadAsync(SceneID.Empty);
            yield return _sceneLoader.LoadAsync(sceneID);

            SceneBootstrap sceneBootstrap = Object.FindAnyObjectByType<SceneBootstrap>();

            if (sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap));

            _currentSceneContainer = new DIContainer(_projectContainer);

            yield return sceneBootstrap.Run(_currentSceneContainer, nextSceneArgs);

            _loadingCurtain.Hide();
        }
    }


}
