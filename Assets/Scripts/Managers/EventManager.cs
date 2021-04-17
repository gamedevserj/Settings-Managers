using UnityEngine;

namespace PlayerSettings
{
    public static class EventManager
    {
        public delegate void VolumeChange();
        public static event VolumeChange OnVolumeChange;

        public static void Call_OnVolumeChange()
        {
            if (OnVolumeChange != null)
            {
                OnVolumeChange();
            }
        }

        public delegate void ButtonRebind(InputButton button, KeyCode code);
        public static event ButtonRebind OnButtonRebind;

        public static void Call_OnButtonRebind(InputButton button, KeyCode code)
        {
            if (OnButtonRebind != null)
            {
                OnButtonRebind(button, code);
            }
        }
    }
}