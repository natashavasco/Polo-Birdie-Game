using System;

namespace POLO.Scripts.UI
{
    public class MultiplayerScreen : UIScreen
    {
        public event Action OnCreateRoomButtonPressed;
        public event Action OnJoinRoomButtonPressed;

        public void OnCreateRoomPress()
        {
            OnCreateRoomButtonPressed?.Invoke();
        }

        public void OnJoinRoomPress()
        {
            OnJoinRoomButtonPressed?.Invoke();
        }
    }
}
