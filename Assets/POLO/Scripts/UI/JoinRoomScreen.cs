using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinRoomScreen : UIScreen
{
   [SerializeField] private TMP_InputField m_RoomName;
   [SerializeField] private TMP_InputField m_PlayerName;
   public event Action<string, string> OnJoinRoomButtonPressed;

   public void OnJoinPress()
   {
      string roomName = m_RoomName.text;
      string playerName = m_PlayerName.text;
      OnJoinRoomButtonPressed?.Invoke(roomName, playerName);
   }
}
