using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStarterProject.UI.OptionsMenu;

namespace UnityStarterProject
{
    public class MainMenuManager : MonoBehaviour
    {
        public void UpdateSettings()
        {
            MenuOption[] options = FindObjectsOfType<MenuOption>();

            foreach(MenuOption option in options)
            {
                option.UpdateValues();
            }
        }

        public void ResetSettings()
        {
            QualityManager.Instance.ResetSettings();
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