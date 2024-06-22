using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState m_CurrentState;

    private void Start()
    {
        m_CurrentState = GetInitialState();
        if (m_CurrentState != null)
        {
            m_CurrentState.Enter();
        }
    }

    private void Update()
    {
        if (m_CurrentState != null)
        {
            m_CurrentState.UpdateLogic();
        }
    }

    private void LateUpdate()
    {
        if (m_CurrentState != null)
        {
            m_CurrentState.UpdatePhysicsLogic();
        }
    }

    public void ChangeState(BaseState newState)
    {
        m_CurrentState.Exit();
        m_CurrentState = newState;
        m_CurrentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = m_CurrentState != null ? m_CurrentState.name : "(No Current State)";
        GUILayout.Label($"<color='black'><size=40>Current State: {content}</size></color>");
    }
}


