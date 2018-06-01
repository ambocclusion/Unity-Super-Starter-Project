using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStarterProject.Extensions;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityStarterProject
{
    [ExecuteInEditMode]
    public class UiPanelSwitcher : MonoBehaviour
    {
        public List<GameObject> Panels = new List<GameObject>();
        public int StartScreen = 0;

        private int currentScreen = 0;

        private void Start()
        {
            currentScreen = StartScreen;
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.update += EditorUpdate;
        }

        private void OnDisable()
        {
            EditorApplication.update -= EditorUpdate;
        }

        private void OnDestroy()
        {
            EditorApplication.update -= EditorUpdate;
        }

        private void EditorUpdate()
        {
            if (Application.isPlaying)
            {
                return;
            }

            if (Selection.activeGameObject != null)
            {
                List<Transform> parents = Selection.activeGameObject.transform.GetAllParents();

                bool shouldContinue = false;

                foreach (Transform parent in parents)
                {
                    if (parent.GetComponent<UiPanelSwitcher>() == this)
                    {
                        shouldContinue = true;
                    }
                }

                if (!shouldContinue)
                {
                    return;
                }

                for (int i = 0; i < Panels.Count; i++)
                {
                    if (parents.Contains(Panels[i].transform))
                    {
                        currentScreen = i;
                    }
                }

                Update();
            }
        }

#endif
        private void Update()
        {
            for (int i = 0; i < Panels.Count; i++)
            {
                if (i == currentScreen)
                {
                    Panels[i].SetActive(true);
                }
                else
                {
                    Panels[i].SetActive(false);
                }
            }
        }

        public void SetScreen(int screen)
        {
            currentScreen = screen;
        }
    }
}