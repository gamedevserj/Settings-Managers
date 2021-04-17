using UnityEngine;
using Newtonsoft.Json;
using System.IO;
/*
 * This script should not be in scene
 * scripts that need accessing it should call StaticComponent<AudioSettingsManager>.Instance
 * */
namespace PlayerSettings
{
    public class AudioSettingsManager : MonoBehaviour
    {
        string savePath = "";

        [SerializeField] private AudioSettingsData audioData = new AudioSettingsData(0.5f, 0.5f);

        private void Awake()
        {
            savePath = Application.persistentDataPath + "/AudioSettings.json";
            Load();
        }

        //is called by sliders in menus
        public void SetVolume(float volume, SoundType soundType)
        {
            if (soundType == SoundType.Music)
            {
                audioData.musicVolume = volume;
            }
            else
            {
                audioData.soundsVolume = volume;
            }
            EventManager.Call_OnVolumeChange(); // notify audio sources about volume change
        }

        // audio sources get their volume from here
        public float GetVolume(SoundType type)
        {
            if (type == SoundType.Music)
            {
                return audioData.musicVolume;
            }
            else
            {
                return audioData.soundsVolume;
            }
        }
        //saves volume values to a file
        public void Save()
        {
            string audioSettings = JsonConvert.SerializeObject(audioData);
            File.WriteAllText(savePath, audioSettings);
        }
        //loads values from a file if the values were saved before
        public void Load()
        {
            if (File.Exists(savePath))
            {
                string audioSettings = File.ReadAllText(savePath);
                audioData = JsonConvert.DeserializeObject<AudioSettingsData>(audioSettings);
            }
        }

    }

    [System.Serializable]
    public class AudioSettingsData
    {
        public float musicVolume;
        public float soundsVolume;

        public AudioSettingsData(float musicVolume, float soundsVolume)
        {
            this.musicVolume = musicVolume;
            this.soundsVolume = soundsVolume;
        }
    }
}