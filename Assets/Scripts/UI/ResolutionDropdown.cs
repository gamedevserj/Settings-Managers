using System.Collections.Generic;
using UnityEngine;

namespace PlayerSettings
{
    public class ResolutionDropdown : MonoBehaviour
    {

        public TMPro.TMP_Dropdown dropdown;

        void Awake()
        {
            List<string> formattedResolutionNames = new List<string>();
            for (int i = 0; i < StaticComponent<VideoSettingsManager>.Instance.GetAllResolutions().Length; i++)
            {
                formattedResolutionNames.Add(FormatResolution(StaticComponent<VideoSettingsManager>.Instance.GetAllResolutions()[i].ToString()));
            }
            dropdown.AddOptions(formattedResolutionNames);
            dropdown.value = StaticComponent<VideoSettingsManager>.Instance.GetCurrentResolution();

        }

        void OnEnable()
        {
            dropdown.onValueChanged.AddListener(delegate { StaticComponent<VideoSettingsManager>.Instance.SetResolution(dropdown.value); });
        }
        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }

        string FormatResolution(string resolution)
        {
            string formatted = resolution.Substring(0, resolution.IndexOf(" @"));
            return formatted;
        }
    }
}
