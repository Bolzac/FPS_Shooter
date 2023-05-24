using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Player player;
    public List<State<Player>> states;
    private Dictionary<Type, State<Player>> _statesByTypes;
    public State<Player> currentState;

    private void Awake()
    {
        player = GetComponent<Player>();
        _statesByTypes = new Dictionary<Type, State<Player>>();
        foreach (var state in states)
        {
            _statesByTypes.Add(state.GetType(),state);
            state.Init(player);
        }
        SetState(states[0].GetType());
    }

    public void SetState(Type var)
    {
        if (currentState)
        {
            currentState.Exit();
        }
        currentState = _statesByTypes[var];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.CaptureInput();
        currentState.Update();
        currentState.ChangeState();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}
