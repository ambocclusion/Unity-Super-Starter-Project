using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public abstract class MenuOption : MonoBehaviour
    {
        public Dropdown dropdown;

        private IEnumerator Start()
        {
            yield return null;

            UpdateValues();
        }

        public abstract void UpdateValues();
        protected abstract void OptionChanged(int selection);
    }
}