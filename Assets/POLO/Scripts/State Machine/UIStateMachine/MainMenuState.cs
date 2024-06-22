namespace POLO.Scripts.State_Machine.UIStateMachine
{
    public class MainMenuState : BaseState
    {
        private MainMenuScreen m_Screen;
        public MainMenuState(MainUIStateMachine stateMachine) : base("MainMenuState", stateMachine) { }
        public override void Enter()
        {
            base.Enter();
            m_Screen = UIManager.Instance.Get<MainMenuScreen>();
            SubscribeToScreenButtons(m_Screen);
            UIManager.Instance.Show(m_Screen);
        }

        public override void Exit()
        {
            base.Exit();
            UnsubscribeToScreenButtons(m_Screen);
        }

        private void HandleOnMultiplayerPress()
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).MultiplayerState);
        }
    
        private void HandleOnFreeplayPress()
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).FreeplayState);
        }

        private void HandleOnExitPress(UIScreen obj)
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).ExitGameState);
        }

        private void SubscribeToScreenButtons(MainMenuScreen menuScreen)
        {
            menuScreen.OnMultiplayerButtonPressed += HandleOnMultiplayerPress;
            menuScreen.OnFreeplayButtonPressed += HandleOnFreeplayPress;
            menuScreen.OnReturnButtonPressed += HandleOnExitPress;
        }
    
        private void UnsubscribeToScreenButtons(MainMenuScreen menuScreen)
        {
            menuScreen.OnMultiplayerButtonPressed -= HandleOnMultiplayerPress;
            menuScreen.OnFreeplayButtonPressed -= HandleOnFreeplayPress;
            menuScreen.OnReturnButtonPressed -= HandleOnExitPress;
        }
    }
}
