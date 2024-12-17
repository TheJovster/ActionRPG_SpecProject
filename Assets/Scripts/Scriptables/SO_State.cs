using StateMachine;
using UnityEngine;

[CreateAssetMenu(menuName = "Diablo/State", fileName = "State")]
public class SO_State : ScriptableObject, IState
{
    public string StateName;

    private StateManager StateManager;

    public void Init(StateManager stateManager)
    {
        StateManager = stateManager;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Process()
    {

    }
}
