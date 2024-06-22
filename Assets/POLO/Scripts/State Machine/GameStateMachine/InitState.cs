
    public class InitState : BaseState
    {
        public InitState(GameStateMachine stateMachine) : base("InitState", stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            // instantiate player prefab
        }

        private void SpawnPlayerPrefab()
        {
            
        }
    }

