using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FreeplayScreen : UIScreen
{
    public event Action OnStartButtonPressed;

    public void OnStartPress()
    {
        OnStartButtonPressed?.Invoke();
    }
}
