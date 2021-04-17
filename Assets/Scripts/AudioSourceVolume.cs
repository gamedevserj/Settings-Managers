using UnityEngine;

namespace PlayerSettings
{
    public class AudioSourceVolume : MonoBehaviour
    {
        public SoundType soundType;
        AudioSource audSource;

        private void Start()
        {
            audSource = GetComponent<AudioSource>();
            SetVolume();
        }

        private void OnEnable()
        {
            EventManager.OnVolumeChange += SetVolume;
        }

        private void OnDisable()
        {
            EventManager.OnVolumeChange -= SetVolume;
        }
        //sets audio source volume
        void SetVolume()
        {
            audSource.volume = StaticComponent<AudioSettingsManager>.Instance.GetVolume(soundType);
        }

    }
}