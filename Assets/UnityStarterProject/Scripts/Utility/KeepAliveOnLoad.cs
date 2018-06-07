using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAliveOnLoad : MonoBehaviour
{
    public bool SeparateFromParent = false;

    private void Awake()
    {
        if (SeparateFromParent)
        {
            this.transform.SetParent(null);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
