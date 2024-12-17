using Diablo;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateManager :MonoBehaviour
    {
        internal PlayerController Character;
        internal SO_State currentState;
        internal SO_State previousState;

        public List<SO_State> States = new List<SO_State>();
        
        public StateManager(PlayerController playerController)
        {
            Character = playerController;

            foreach (var state in GameManager.I.States)
            {
                var newState = Instantiate(state);
                newState.Init(this);
                States.Add(newState);
            }
        }

        public void ChangeState(SO_State newState)
        {
            if (newState == currentState) return;

            if (currentState != null)
            {
                previousState = currentState;
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();

            Debug.Log($"{Character.CharacterName} State: {currentState.GetType().Name}");
        }

        public void Process()
        {

        }
    }
}