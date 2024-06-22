using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerSpawner m_PlayerSpawner;
    [SerializeField] private LoginManager m_LoginManager;

    private void Start()
    {
        m_LoginManager.OnJoinRequested += HandleOnJoinRoomRequested;
        m_LoginManager.OnCreateRequested += HandleOnCreateRoomRequested;
    }
    
    private void OnDestroy()
    {
        m_LoginManager.OnJoinRequested += HandleOnJoinRoomRequested;
        m_LoginManager.OnCreateRequested += HandleOnCreateRoomRequested;
    }

    private void HandleOnJoinRoomRequested()
    {
        m_PlayerSpawner.JoinGame();
    }

    private void HandleOnCreateRoomRequested()
    {
        m_PlayerSpawner.CreateGame();
    }
}
