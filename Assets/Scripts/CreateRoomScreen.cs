using System;
using UnityEngine;

public class CreateRoomScreen : UIScreen
{
    public event Action OnCreateButtonPressed;

    public void OnCreatePress()
    {
        OnCreateButtonPressed?.Invoke();
    }
}