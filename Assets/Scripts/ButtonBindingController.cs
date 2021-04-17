using UnityEngine;

namespace PlayerSettings
{
    public class ButtonBindingController : MonoBehaviour
    {
        public GameObject blockingNewInputObject;
        public TMPro.TextMeshProUGUI notificationText;

        InputButton buttonToChange;

        bool change;

        // Update is called once per frame
        void Update()
        {
            if (change && Input.anyKeyDown)
            {
                //we have to loop through all possible keycodes because there are no built in methods to get keycode of the pressed button
                foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(code))
                    {
                        change = false;
                        StaticComponent<InputManager>.Instance.SetButtonKey(buttonToChange, code);
                        EventManager.Call_OnButtonRebind(buttonToChange, code);
                        blockingNewInputObject.SetActive(false);
                    }
                }
            }
        }

        //is called when user selects a button to be changed
        public void RebindButton(InputButton button, string name)
        {
            buttonToChange = button;
            change = true;
            notificationText.text = "Press new key for " + name + " button";
            blockingNewInputObject.SetActive(true);
        }
    }
}
