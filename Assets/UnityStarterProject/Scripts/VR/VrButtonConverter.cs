using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

namespace UnityStarterProject.VR.UI
{
    public class VrButtonConverter : Singleton<VrButtonConverter>
    {
        private void Start()
        {
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject go in rootGameObjects)
            {
                foreach(Button button in go.GetComponentsInChildren<Button>(true))
                {
                    RectTransform buttonRect = button.transform as RectTransform;
                    BoxCollider box = button.gameObject.AddComponent<BoxCollider>();
                    box.size = new Vector3(buttonRect.rect.width, buttonRect.rect.height, 5f);
                    UIElement uiElement = button.gameObject.AddComponent<UIElement>();
                }
            }
        }
    }
}