using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject
{
    public class MainMenuManager : MonoBehaviour
    {
        public List<GameObject> Screens = new List<GameObject>();
        public int StartScreen = 0;

        private void Awake()
        {
            SetScreen(StartScreen);
        }

        public void SetScreen(int screen)
        {
            for (int i = 0; i < Screens.Count; i++)
            {
                if (i == screen)
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }

        public void ChangeScene(string name)
        {
            SceneLoader.Instance.ChangeScene(name);
        }

        public void ExitGame()
        {
            Debug.Log("Exiting the game!");
            Application.Quit();
        }
    }
}