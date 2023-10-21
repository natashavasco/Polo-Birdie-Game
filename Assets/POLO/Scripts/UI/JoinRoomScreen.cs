using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoomScreen : UIScreen
{
   public event Action OnJoinRoomButtonPressed;

   public void OnJoinPress()
   {
      OnJoinRoomButtonPressed?.Invoke();
   }
}
