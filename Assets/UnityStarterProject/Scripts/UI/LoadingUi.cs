using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject
{
    public class LoadingUi : Singleton<LoadingUi>
    {
        #region Modifiable Fields
        public Slider LoadingBar;
        #endregion

        #region Initialization
        protected override void Awake()
        {
            base.Awake();

            this.gameObject.SetActive(false);
        }
        #endregion

        #region Control Methods
        public void InitializeLoad(AsyncOperation operation)
        {
            this.gameObject.SetActive(true);
            StartCoroutine(UpdateProgressBar(operation));
        }

        public void ResetUi()
        {
            LoadingBar.value = 0.0f;
            this.gameObject.SetActive(false);
        }
        #endregion

        #region Private Methods
        private IEnumerator UpdateProgressBar(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                LoadingBar.value = operation.progress / 0.9f;
                yield return null;
            }

            // Delay for a few frames so we can guarantee that the scene is finished initializing. 
            // 10 FixedUpdates is approx 1/5th a second if time step is 50.
            // This should be enough to combat pop in and startup lag
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            ResetUi();
        }
        #endregion
    }
}