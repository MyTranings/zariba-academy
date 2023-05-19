namespace Monopoly.Controller
{
    using States;
    using System.Collections.Generic;

    public static class StateMachine
    {
        public static State CurrentState;
        public static Dictionary<string, State> States = new Dictionary<string, State>();
        private static EndTurnState endTurnState;
        private static PlayerLandedState playerLandedState;
        private static PlayerMoveState playerMoveState;
        private static PlayerRollState playerRollState;
        private static PlayerTurnState playerTurnState;
        private static InitialState initialState;

        public static void Initialize()
        {
            endTurnState = new EndTurnState(playerTurnState);
            playerLandedState = new PlayerLandedState(endTurnState);
            playerMoveState = new PlayerMoveState(playerLandedState);
            playerRollState = new PlayerRollState(playerMoveState);
            playerTurnState = new PlayerTurnState(playerRollState);
            initialState = new InitialState(playerTurnState);
            endTurnState.NextState = playerTurnState;

            States.Add("InitialState", initialState);
            States.Add("PlayerTurnState", playerTurnState);
            States.Add("PlayerRollState", playerRollState);
            States.Add("PlayerMoveState", playerMoveState);
            States.Add("PlayerLandedState",playerLandedState);
            States.Add("EndTurnState",endTurnState);
        }
        public static void ChangeState()
        {
            CurrentState = CurrentState.NextState;
        }
    }
}
