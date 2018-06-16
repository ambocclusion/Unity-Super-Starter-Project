using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public abstract class MenuOption : MonoBehaviour
    {
        public Dropdown dropdown;

        // These two are for slider based options
        public Slider slider;
        public Text valueText;

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

            if (slider)
            {
                slider.onValueChanged.AddListener(SliderChanged);
            }

            initialized = true;
        }

        public abstract void UpdateValues();
        protected virtual void OptionChanged(int selection) { }
        protected virtual void SliderChanged(float sliderValue) { }
    }
}