using System.Collections.Generic;
using UnityEngine;

namespace PlayerSettings
{
    public class QualityDropdown : MonoBehaviour
    {
        public TMPro.TMP_Dropdown dropdown;

        void Awake()
        {
            string[] qualityNames = StaticComponent<VideoSettingsManager>.Instance.GetQualityNames();
            List<string> namesForDropdown = new List<string>();
            for (int i = 0; i < qualityNames.Length; i++)
            {
                namesForDropdown.Add(qualityNames[i]);
            }
            dropdown.AddOptions(namesForDropdown);
            dropdown.value = StaticComponent<VideoSettingsManager>.Instance.GetCurrentQualityLevel();
        }

        void OnEnable()
        {
            dropdown.onValueChanged.AddListener(delegate { StaticComponent<VideoSettingsManager>.Instance.SetQuality(dropdown.value); });
        }
        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }

    }
}
