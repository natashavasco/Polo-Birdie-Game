namespace POLO.Scripts.State_Machine.UIStateMachine
{
    public class MainUIStateMachine : StateMachine
    {
        public MainMenuState MainMenuState;
        public MultiplayerState MultiplayerState;
        public FreeplayState FreeplayState;
        public CreateRoomState CreateRoomState;
        public JoinRoomState JoinRoomState;
        public ExitGameState ExitGameState;
    
        private void Awake()
        {
            MainMenuState = new MainMenuState(this);
            MultiplayerState = new MultiplayerState(this);
            FreeplayState = new FreeplayState(this);
            CreateRoomState = new CreateRoomState(this);
            JoinRoomState = new JoinRoomState(this);
            ExitGameState = new ExitGameState(this);
        }

        protected override BaseState GetInitialState()
        {
            return MainMenuState;
        }
    
    }
}
