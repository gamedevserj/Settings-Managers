using UnityEngine;

/*
 * This script should not be in scene
 * scripts that need accessing it should call StaticComponent<VideoSettingsManager>.Instance
 * */
namespace PlayerSettings
{
    public class VideoSettingsManager : MonoBehaviour
    {

        int currentResolution = 0;
        Resolution[] resolutions;
        bool fullscreen;

        string[] qualityNames;

        private void Awake()
        {
            resolutions = Screen.resolutions;
            qualityNames = QualitySettings.names;
            foreach (Resolution res in resolutions)
            {
                if (res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
                {
                    break; // exit the loop without inscreasing the currentResolution
                }
                currentResolution++;
            }
        }

        public void SetResolution(int resolutionNum)
        {
            currentResolution = resolutionNum;
            Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullscreen);
        }
        // is called by dropdown to select current resolution in dropdown list on awake
        public int GetCurrentResolution()
        {
            return currentResolution;
        }

        public Resolution[] GetAllResolutions()
        {
            return resolutions;
        }
        // is called by fullscreen button
        public void SetFullscreen(bool full)
        {
            fullscreen = full;
            SetResolution(currentResolution);
        }

        public void SetQuality(int qualityNum)
        {
            QualitySettings.SetQualityLevel(qualityNum);
        }

        public int GetCurrentQualityLevel()
        {
            return QualitySettings.GetQualityLevel();
        }

        public string[] GetQualityNames()
        {
            return qualityNames;
        }
    }
}
