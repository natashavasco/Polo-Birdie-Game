using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WelcomePlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text m_WelcomeText;

    private void Start()
    {
        string playername = PlayerPrefs.GetString("PlayerName");
        m_WelcomeText.text = $"Welcome {playername}!";
    }
}
