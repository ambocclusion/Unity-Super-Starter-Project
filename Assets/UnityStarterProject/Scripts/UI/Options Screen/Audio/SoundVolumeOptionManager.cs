using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class SoundVolumeOptionManager : MenuOption
    {
        public float min = 0;
        public float max = 1;

        private void Awake()
        {
            slider.minValue = min;
            slider.maxValue = max;
        }

        public override void UpdateValues()
        {
            slider.value = AudioManager.Instance.soundVolume;
            valueText.text = (AudioManager.Instance.soundVolume * 100f).ToString("F0");
        }

        protected override void SliderChanged(float sliderValue)
        {
            AudioManager.Instance.SetSoundVolume(sliderValue);
            valueText.text = (sliderValue * 100f).ToString("F0");
        }
    }
}