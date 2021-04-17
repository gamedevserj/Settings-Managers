using UnityEngine;

namespace PlayerSettings
{
    public class SaveBindingsButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            UnityEngine.UI.Button btn = GetComponent<UnityEngine.UI.Button>();
            btn.onClick.AddListener(
                () => { StaticComponent<InputManager>.Instance.Save(); });
        }

    }
}
