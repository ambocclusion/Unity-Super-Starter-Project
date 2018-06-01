using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject
{
    public class MainMenuManager : MonoBehaviour
    {
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