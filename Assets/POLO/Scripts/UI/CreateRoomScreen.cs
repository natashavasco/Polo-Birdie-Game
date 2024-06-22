using System;
using TMPro;
using UnityEngine;

public class CreateRoomScreen : UIScreen
{
    public event Action<string, string> OnCreateButtonPressed;
    
    [SerializeField] private TMP_InputField m_RoomNameInput;
    [SerializeField] private TMP_InputField m_PlayerNameInput;
    
    public void OnCreatePress()
    {
        string roomName = m_RoomNameInput.text;
        string playerName = m_PlayerNameInput.text;
        OnCreateButtonPressed?.Invoke(roomName, playerName);
    }
    
    
}