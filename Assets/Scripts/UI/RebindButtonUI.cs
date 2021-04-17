using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

namespace PlayerSettings
{
    public class RebindButtonUI : MonoBehaviour
    {
        public InputButton buttonToChange;
        public ButtonBindingController controller;
        public TMPro.TextMeshProUGUI text;

        Button btn;

        void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(() => { controller.RebindButton(buttonToChange, FormatName(buttonToChange.ToString("g"))); });
            text.text = FormatName(StaticComponent<InputManager>.Instance.GetButtonKey(buttonToChange).ToString());
        }

        private void OnEnable()
        {
            EventManager.OnButtonRebind += OnButtonRebind;
        }

        private void OnDisable()
        {
            EventManager.OnButtonRebind -= OnButtonRebind;
        }

        //updates text to show which key is bound to the button
        void OnButtonRebind(InputButton inputButton, KeyCode code)
        {
            if (inputButton == buttonToChange)
            {
                text.text = FormatName(code.ToString("g"));
            }
        }

        string FormatName(string name)
        {
            return Regex.Replace(name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}