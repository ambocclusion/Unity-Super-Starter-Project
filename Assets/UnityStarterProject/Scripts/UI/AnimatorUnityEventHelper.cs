using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject.UI
{
    public class AnimatorUnityEventHelper : MonoBehaviour
    {
        public Animator animator;

        public void SetBoolTrue(string boolName)
        {
            animator.SetBool(boolName, true);
        }

        public void SetBoolFalse(string boolName)
        {
            animator.SetBool(boolName, false);
        }
    }
}