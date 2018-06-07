using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UiStarterGame
{
    public class UiDraggableSlot : MonoBehaviour
    {
        public Transform currentChild;
        public float StartSpeed = .3f;
        [HideInInspector] public float currentSpeed;
        private const float speedToAdd = .3f;

        private Transform lastCurrentChild;
        [HideInInspector] public bool animating = false;

        private void FixedUpdate()
        {
            if (currentChild != null)
            {
                if (currentChild != lastCurrentChild)
                {
                    currentSpeed = StartSpeed;
                    animating = true;
                }

                if (animating)
                {
                    currentChild.transform.position = Vector3.Lerp(currentChild.transform.position, this.transform.position, currentSpeed * Time.fixedDeltaTime);
                    currentSpeed += speedToAdd;

                    if (Vector3.Distance(currentChild.position, this.transform.position) < 1f)
                    {
                        currentChild.transform.SetParent(this.transform);
                        Destroy(currentChild.gameObject.GetComponent<LayoutElement>());
                        currentChild.transform.position = this.transform.position;
                        animating = false;
                    }
                }
            }

            lastCurrentChild = currentChild;
        }
    }
}
