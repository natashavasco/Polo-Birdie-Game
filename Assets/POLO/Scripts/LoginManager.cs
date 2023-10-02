using System;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private UIManager m_UIManager;

    public event Action OnCreateRequested;
    public event Action OnJoinRequested;
    private void Start()
    {
        SubscribeToButtons();
        m_UIManager.HideAllScreens();
        UIScreen startScreen = m_UIManager.Get<MainScreen>();
        m_UIManager.Show(startScreen);
    }

    private void OnDestroy()
    {
        UnsubscribeToButtons();
    }
    
    private void SubscribeToButtons()
    {
        m_UIManager.Get<MainScreen>().OnMultiplayerButtonPressed += HandleOnMultiplayerPressed;
        m_UIManager.Get<MainScreen>().OnFreeplayButtonPressed += HandleOnFreeplayPressed;
        m_UIManager.Get<FreeplayScreen>().OnStartButtonPressed += HandleOnStartFreeplayPressed;
        m_UIManager.Get<MultiplayerScreen>().OnCreateRoomButtonPressed += HandleOnCreateRoomPressed;
        m_UIManager.Get<MultiplayerScreen>().OnJoinRoomButtonPressed += HandleOnJoinRoomPressed;
        m_UIManager.Get<CreateRoomScreen>().OnCreateButtonPressed += HandleOnCreatePressed;
        m_UIManager.Get<JoinRoomScreen>().OnJoinRoomButtonPressed += HandleOnJoinPressed;
        foreach (UIScreen screen in m_UIManager.Screens)
        {
            screen.OnReturnButtonPressed += HandleOnReturnPressed;
        }
    }

    private void HandleOnReturnPressed(UIScreen screen)
    {
        UIScreen previousScreen = screen.GetPreviousScreen();
        
        if (previousScreen != null)
        {
            m_UIManager.Show(previousScreen);
        }
    }

    private void UnsubscribeToButtons()
    {
        m_UIManager.Get<MainScreen>().OnMultiplayerButtonPressed -= HandleOnMultiplayerPressed;
        m_UIManager.Get<MainScreen>().OnFreeplayButtonPressed -= HandleOnFreeplayPressed;
        m_UIManager.Get<FreeplayScreen>().OnStartButtonPressed -= HandleOnStartFreeplayPressed;
        m_UIManager.Get<MultiplayerScreen>().OnCreateRoomButtonPressed -= HandleOnCreateRoomPressed;
        m_UIManager.Get<MultiplayerScreen>().OnJoinRoomButtonPressed -= HandleOnJoinRoomPressed;
        m_UIManager.Get<CreateRoomScreen>().OnCreateButtonPressed -= HandleOnCreatePressed;
        m_UIManager.Get<JoinRoomScreen>().OnJoinRoomButtonPressed -= HandleOnJoinPressed;
    }

    #region button handlers
    private void HandleOnMultiplayerPressed()
    {
        UIScreen nextScreen = m_UIManager.Get<MultiplayerScreen>();
        m_UIManager.Show(nextScreen);
    }

    private void HandleOnFreeplayPressed()
    {
        UIScreen nextScreen = m_UIManager.Get<FreeplayScreen>();
        m_UIManager.Show(nextScreen);
    }

    private void HandleOnCreateRoomPressed()
    {
        UIScreen nextScreen = m_UIManager.Get<CreateRoomScreen>();
        m_UIManager.Show(nextScreen);
    }

    private void HandleOnJoinRoomPressed()
    {
        UIScreen nextScreen = m_UIManager.Get<JoinRoomScreen>();
        m_UIManager.Show(nextScreen);
    }
    
    private void HandleOnStartFreeplayPressed()
    {
        m_UIManager.HideAll();
    }

    private void HandleOnCreatePressed()
    {
        OnCreateRequested?.Invoke();
        m_UIManager.HideAll();
    }

    private void HandleOnJoinPressed()
    {
        OnJoinRequested?.Invoke();
        m_UIManager.HideAll();
    }
    #endregion
}
