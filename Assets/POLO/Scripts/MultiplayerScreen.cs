using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
