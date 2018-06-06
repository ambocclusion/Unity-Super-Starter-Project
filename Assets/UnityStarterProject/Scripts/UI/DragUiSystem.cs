using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStarterProject.UiStarterGame
{
    public class DragUiSystem : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster raycaster = null;
        private Transform currentDrag;
        private Transform originalParent;
        private EventSystem eventSystem = null;
        private PointerEventData pointerEventData;

        public void SetCurrentDrag(Transform obj)
        {
            if (obj.parent.GetComponent<UiDraggableSlot>() == null)
            {
                return;
            }

            currentDrag = obj;
            originalParent = obj.parent;
            obj.transform.SetParent(this.transform.root);
            obj.transform.SetAsLastSibling();
            LayoutElement layout = obj.gameObject.AddComponent<LayoutElement>();
            layout.ignoreLayout = true;
        }

        public void EndCurrentDrag()
        {
            // Somehow the drag got ended despite none getting started. Darn you, Unity!
            if (currentDrag == null)
            {
                return;
            }

            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);

            List<RaycastResult> slotResult = results.FindAll(r => r.gameObject.GetComponent<UiDraggableSlot>() != null);
            UiDraggableSlot slot = null;

            if (slotResult.Count != 0)
            {
                slot = slotResult[0].gameObject.GetComponent<UiDraggableSlot>();

                originalParent.GetComponent<UiDraggableSlot>().currentChild = null;

                if (slot.currentChild)
                {
                    slot.currentChild.SetParent(this.transform.root);
                    originalParent.GetComponent<UiDraggableSlot>().currentChild = slot.currentChild;
                }

                slotResult[0].gameObject.GetComponent<UiDraggableSlot>().currentChild = currentDrag;
            }
            else
            {
                originalParent.GetComponent<UiDraggableSlot>().currentChild = currentDrag;
                originalParent.GetComponent<UiDraggableSlot>().currentSpeed = originalParent.GetComponent<UiDraggableSlot>().StartSpeed;
                originalParent.GetComponent<UiDraggableSlot>().animating = true;
            }

            currentDrag = null;
            originalParent = null;
        }

        private void Update()
        {
            if (currentDrag)
            {
                currentDrag.position = Input.mousePosition;
            }
        }
    }
}