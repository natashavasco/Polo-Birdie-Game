using POLO.Scripts.UI;

namespace POLO.Scripts.State_Machine.UIStateMachine
{
    public class MultiplayerState : BaseState
    {
        private MultiplayerScreen m_Screen;
        public MultiplayerState(MainUIStateMachine stateMachine) : base("MultiplayerState", stateMachine) { }
    
        public override void Enter()
        {
            base.Enter();
            m_Screen = UIManager.Instance.Get<MultiplayerScreen>();
            SubscribeToScreenButtons(m_Screen);
            UIManager.Instance.Show(m_Screen);
        }

        public override void Exit()
        {
            base.Exit();
            UnsubscribeToScreenButtons(m_Screen);
        }

        private void SubscribeToScreenButtons(MultiplayerScreen screen)
        {
            screen.OnCreateRoomButtonPressed += HandleOnCreateRoomButtonPressed;
            screen.OnJoinRoomButtonPressed += HandleOnJoinRoomButtonPressed;
            screen.OnReturnButtonPressed += HandleOnReturnButtonPressed;
        }
    
        private void UnsubscribeToScreenButtons(MultiplayerScreen screen)
        {
            screen.OnCreateRoomButtonPressed -= HandleOnCreateRoomButtonPressed;
            screen.OnJoinRoomButtonPressed -= HandleOnJoinRoomButtonPressed;
            screen.OnReturnButtonPressed -= HandleOnReturnButtonPressed;
        }

        private void HandleOnCreateRoomButtonPressed()
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).CreateRoomState);
        }

        private void HandleOnJoinRoomButtonPressed()
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).JoinRoomState);
        }

        private void HandleOnReturnButtonPressed(UIScreen obj)
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).MainMenuState);
        }
    }
}
