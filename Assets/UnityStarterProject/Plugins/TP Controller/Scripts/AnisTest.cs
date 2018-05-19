using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStarterProject;

public class AnisTest : MonoBehaviour
{
    public Text myText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int current = QualityManager.Instance.GetAnisotropicFiltering();
            QualityManager.Instance.SetAnisotropicTextures(current - 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int current = QualityManager.Instance.GetAnisotropicFiltering();
            QualityManager.Instance.SetAnisotropicTextures(current + 1);
        }

        myText.text = ((int)QualityManager.Instance.GetAnisotropicFiltering()).ToString();
    }
}
