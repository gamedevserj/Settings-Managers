using UnityEngine;
using UnityEngine.UI;

namespace PlayerSettings
{
    public class VolumeSlider : MonoBehaviour
    {
        public SoundType soundType;

        Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            SetSliderOnAwake();
        }
        private void OnEnable()
        {
            slider.onValueChanged.AddListener(delegate { SetVolume(); });
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveAllListeners();
        }

        //sets the volume of the sound type
        void SetVolume()
        {
            StaticComponent<AudioSettingsManager>.Instance.SetVolume(slider.value, soundType);
        }
        //sets slider value on awake corresponding to the saved volume
        void SetSliderOnAwake()
        {
            slider.value = StaticComponent<AudioSettingsManager>.Instance.GetVolume(soundType);
        }
    }
}
