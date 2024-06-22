using UnityEngine;

namespace POLO.Scripts.State_Machine.UIStateMachine
{
    public class CreateRoomState : BaseState
    {
        private CreateRoomScreen m_Screen;
        public CreateRoomState(MainUIStateMachine stateMachine) : base("CreateRoomState", stateMachine) { }
    
        public override void Enter()
        {
            base.Enter();
            m_Screen = UIManager.Instance.Get<CreateRoomScreen>();
            SubscribeToScreenButtons(m_Screen);
            UIManager.Instance.Show(m_Screen);
        }

        public override void Exit()
        {
            base.Enter();
            UnsubscribeToScreenButtons(m_Screen);
        }
    
        private void SubscribeToScreenButtons(CreateRoomScreen screen)
        {
            screen.OnCreateButtonPressed += HandleOnCreateButtonPressed;
            screen.OnReturnButtonPressed += HandleOnReturnButtonPressed;
        }
    
        private void UnsubscribeToScreenButtons(CreateRoomScreen screen)
        {
            screen.OnCreateButtonPressed -= HandleOnCreateButtonPressed;
            screen.OnReturnButtonPressed -= HandleOnReturnButtonPressed;
        }

        private void HandleOnCreateButtonPressed(string roomName, string playerName)
        {
            GameLauncher.Instance.SetCreateLobby();
            GameLauncher.Instance.CreateSession(roomName);
            //StateMachine.ChangeState(((GameStateMachine)StateMachine).InitState);
        }

        private void HandleOnReturnButtonPressed(UIScreen obj)
        {
            StateMachine.ChangeState(((MainUIStateMachine)StateMachine).MultiplayerState);
        }

        public void RequestChangeStateToGame()
        {
            
        }
    }
}
