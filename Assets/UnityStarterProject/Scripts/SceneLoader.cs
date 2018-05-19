using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStarterProject
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        #region Modifiable Fields
        public GameObject LoadingScreen;
        #endregion

        #region Hooks
        private List<Action> onSceneStartLoad = new List<Action>();
        private List<Action> onSceneLoaded = new List<Action>();
        #endregion

        #region Scene Loading
        public void ChangeScene(int sceneIndex)
        {
            string sceneName = SceneManager.GetSceneByBuildIndex(sceneIndex).name;
            ChangeScene(sceneName);
        }

        public void ChangeScene(string sceneName)
        {
            ChangeScene(sceneName, LoadSceneMode.Single);
        }

        public void ChangeScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            TriggerOnSceneStartLoad();
            SceneManager.sceneLoaded += TriggerOnSceneLoaded;
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, mode);

            ShowLoadingScreen(loadSceneOperation);

            if(sceneName != "Main Menu")
            {
                GameStateManager.Instance.SceneIsPausable = true;
            }
            else
            {
                GameStateManager.Instance.SceneIsPausable = false;
            }

            GameStateManager.Instance.UnPauseGame();
        }
        #endregion

        #region Callback Methods
        public void RegisterOnSceneStartLoadCallback(Action callback)
        {
            onSceneStartLoad.Add(callback);
        }

        public void RegisterOnSceneLoadedCallback(Action callback)
        {
            onSceneLoaded.Add(callback);
        }

        private void TriggerOnSceneStartLoad()
        {
            onSceneStartLoad.ForEach(c => c.Invoke());
            onSceneStartLoad.Clear();
        }

        private void TriggerOnSceneLoaded(Scene s, LoadSceneMode m)
        {
            onSceneLoaded.ForEach(c => c.Invoke());
            onSceneLoaded.Clear();
            SceneManager.sceneLoaded -= TriggerOnSceneLoaded;
        }
        #endregion

        #region Loading Screen
        private void ShowLoadingScreen(AsyncOperation operation)
        {
            LoadingUi.Instance.InitializeLoad(operation);
        }

        private void HideLoadingScreen()
        {
            LoadingUi.Instance.ResetUi();
        }
        #endregion
    }
}