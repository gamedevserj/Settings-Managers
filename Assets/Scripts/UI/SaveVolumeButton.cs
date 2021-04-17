using UnityEngine;

/*
 * an example button to save sound volume
 * */
namespace PlayerSettings
{
    public class SaveVolumeButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            UnityEngine.UI.Button btn = GetComponent<UnityEngine.UI.Button>();
            btn.onClick.AddListener(
                () => { StaticComponent<AudioSettingsManager>.Instance.Save(); });
        }

    }
}
