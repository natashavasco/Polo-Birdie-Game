using System;
using UnityEngine;

public class MainMenuScreen : UIScreen
{
    public event Action OnMultiplayerButtonPressed;
    public event Action OnFreeplayButtonPressed;

    public void OnMultiplayerPress()
    {
        OnMultiplayerButtonPressed?.Invoke();
    }

    public void OnFreeplayPress()
    {
        OnFreeplayButtonPressed?.Invoke(); 
    }
}
