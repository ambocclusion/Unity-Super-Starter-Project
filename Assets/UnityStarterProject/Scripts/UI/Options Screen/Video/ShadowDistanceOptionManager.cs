using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class ShadowDistanceOptionManager : MenuOption
    {
        public float min = 5.0f;
        public float max = 50.0f;

        private void Awake()
        {
            slider.minValue = min;
            slider.maxValue = max;
        }

        public override void UpdateValues()
        {
            slider.value = QualityManager.Instance.GetShadowDistance();

            if (valueText)
            {
                valueText.text = slider.value.ToString();
            }
        }

        protected override void SliderChanged(float sliderValue)
        {
            QualityManager.Instance.SetShadowDistance(sliderValue);

            if (valueText)
            {
                valueText.text = sliderValue.ToString();
            }
        }
    }
}