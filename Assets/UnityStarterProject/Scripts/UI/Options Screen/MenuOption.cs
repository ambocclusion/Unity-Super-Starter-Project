using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public abstract class MenuOption : MonoBehaviour
    {
        public Dropdown dropdown;

        private bool initialized = false;

        private void OnEnable()
        {
            if (initialized)
            {
                UpdateValues();
            }
        }

        private IEnumerator Start()
        {
            yield return new WaitForFixedUpdate();

            UpdateValues();

            if (dropdown)
            {
                dropdown.onValueChanged.AddListener(OptionChanged);
            }

            initialized = true;
        }

        public abstract void UpdateValues();
        protected abstract void OptionChanged(int selection);
    }
}