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
            while (operation.progress != 1.0f)
            {
                LoadingBar.value = operation.progress / 0.9f;
                yield return null;
            }

            ResetUi();
        }
        #endregion
    }
}