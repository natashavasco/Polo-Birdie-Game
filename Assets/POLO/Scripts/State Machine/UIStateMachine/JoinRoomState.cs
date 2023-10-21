using UnityEngine;

namespace POLO.Scripts.State_Machine.UIStateMachine
{
    public class JoinRoomState : BaseState
    {
        private JoinRoomScreen m_Screen;
        public JoinRoomState(MainUIStateMachine stateMachine) : base("JoinRoomState", stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            m_Screen = UIManager.Instance.Get<JoinRoomScreen>();
            SubscribeToScreenButtons(m_Screen);
            UIManager.Instance.Show(m_Screen);
        }

        public override void Exit()
        {
            base.Enter();
            UnsubscribeToScreenButtons(m_Screen);
        }
    
        private void SubscribeToScreenButtons(JoinRoomScreen screen)
        {
            screen.OnJoinRoomButtonPressed += HandleOnJoinRoomButtonPressed;
            screen.OnReturnButtonPressed += HandleOnReturnButtonPressed;
        }
    
        private void UnsubscribeToScreenButtons(JoinRoomScreen screen)
        {
            screen.OnJoinRoomButtonPressed -= HandleOnJoinRoomButtonPressed;
            screen.OnReturnButtonPressed -= HandleOnReturnButtonPressed;
        }

        private void HandleOnJoinRoomButtonPressed()
        {
            Debug.Log("Joining Room...");
        }

        private void HandleOnReturnButtonPressed(UIScreen obj)
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).MultiplayerState);
        }
    }
}
