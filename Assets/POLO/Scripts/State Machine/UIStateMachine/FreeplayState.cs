using System.Collections;
using System.Collections.Generic;
using POLO.Scripts.State_Machine.UIStateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeplayState : BaseState
{
    public FreeplayState(MainUIStateMachine stateMachine) : base("FreeplayState", stateMachine) { }

    private FreeplayScreen m_Screen;
    public override void Enter()
    {
        base.Enter();
        m_Screen = UIManager.Instance.Get<FreeplayScreen>();
        SubscribeToScreenButtons(m_Screen);
        UIManager.Instance.Show(m_Screen);
    }
    
    public override void Exit()
    {
        base.Exit();
        UnsubscribeToScreenButtons(m_Screen);
    }

    private void SubscribeToScreenButtons(FreeplayScreen freeplayScreen)
    {
        freeplayScreen.OnStartButtonPressed += HandleOnStartButtonPress;
        freeplayScreen.OnReturnButtonPressed += HandleOnReturnButtonPress;
    }
    
    private void UnsubscribeToScreenButtons(FreeplayScreen freeplayScreen)
    {
        freeplayScreen.OnStartButtonPressed -= HandleOnStartButtonPress;
        freeplayScreen.OnReturnButtonPressed -= HandleOnReturnButtonPress;
    }

    private void HandleOnStartButtonPress()
    {
        // move to game state machine
        //load game scene
        string playerName = m_Screen.GetPlayerName();
        if (string.IsNullOrWhiteSpace(playerName))
        {
            Debug.Log("Name is empty!");
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", playerName);
            SceneManager.LoadScene("Assets/POLO/Scenes/FreeplayScene.unity");
        }
    }

    private void HandleOnReturnButtonPress(UIScreen obj)
    {
        StateMachine.ChangeState(((MainUIStateMachine)StateMachine).MainMenuState);
    }
}
