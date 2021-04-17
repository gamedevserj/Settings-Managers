using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace PlayerSettings
{
    public class InputManager : MonoBehaviour
    {

        public Dictionary<InputButton, KeyCode> buttons = new Dictionary<InputButton, KeyCode>
        {
            { InputButton.Crouch, KeyCode.LeftControl },
            { InputButton.Jump, KeyCode.Space },
            { InputButton.MoveDown, KeyCode.S },
            { InputButton.MoveLeft, KeyCode.A },
            { InputButton.MoveRight, KeyCode.D },
            { InputButton.MoveUp, KeyCode.W },
            { InputButton.Run, KeyCode.LeftShift },
            { InputButton.Shoot, KeyCode.E }
        };

        string savePath = "";

        private void Awake()
        {
            savePath = Application.persistentDataPath + "/InputSettings.json";
            Load();
        }

        //for the ui button to display its keycode correctly on start
        public KeyCode GetButtonKey(InputButton button)
        {
            return buttons[button];
        }
        //is called by button binding controler to change button's keycode
        public void SetButtonKey(InputButton button, KeyCode code)
        {
            buttons[button] = code;
        }

        public void Save()
        {
            string inputData = JsonConvert.SerializeObject(buttons);
            File.WriteAllText(savePath, inputData);
        }

        public void Load()
        {
            if (File.Exists(savePath))
            {
                string inputData = File.ReadAllText(savePath);
                buttons = JsonConvert.DeserializeObject<Dictionary<InputButton, KeyCode>>(inputData); ;
            }
        }
    }
}
