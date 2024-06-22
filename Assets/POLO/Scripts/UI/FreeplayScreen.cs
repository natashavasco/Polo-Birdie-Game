using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class FreeplayScreen : UIScreen
{
    [SerializeField] private TMP_InputField m_NameInput;
    public event Action OnStartButtonPressed;

    public void OnStartPress()
    {
        OnStartButtonPressed?.Invoke();
    }

    public string GetPlayerName()
    {
        return m_NameInput.text;
    }
}
