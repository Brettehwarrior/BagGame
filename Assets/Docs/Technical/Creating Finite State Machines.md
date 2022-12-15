The extendible state machine implementation has 3 main components:
- `StateMachine`, which keeps acts as the "machine" keeping track of the current active state and switching between states
- `State` which defines behaviour for a given state and keeps track of its transitions
- `StateTransition`s which define transitions for states

StateMachines are constructed provided only a starting state since states always have reference to their own transitions via StateTransitions. In practice, this means the states for the machine must be build and their transitions must be assigned before passing to the machine.

For example, the Player's state machine, which uses subclasses `PlayerStateMachine` and `PlayerState` makes use of the `PlayerStates` class to construct all states before passing to the machine:

```cs
// From Player.cs:
private void InitializeStateMachine()  
{  
    var states = new PlayerStates(this);  
    _stateMachine = new PlayerStateMachine(states.StartState);  
}
```

`PlayerStates` simply initializes the `PlayerState` subclass objects for each state, then creates and assigns the transitions to each respective state
```cs
// From PlayerStates.cs:
public PlayerStates(Player player)  
{  
    _player = player;  
    // States  
    _idle = new PlayerIdleState(_player);  
    _walk = new PlayerWalkState(_player);
    /*...*/  
    
    CreateTransitions();  
}  
  
private void CreateTransitions()  
{  
    // Idle  
    _idle.AddTransition(new StateTransition(_walk,   
() => _player.CurrentVelocity.x != 0f  
                && Mathf.Abs(_player.MovementInput.x) > 0f  
        ));  
    // Walk  
    _walk.AddTransition(new StateTransition(_idle,   
() => _player.CurrentVelocity.x == 0f  
        ));  
    /*...*/
}
```

With this setup, these classes should be extendible to use the finite state machine pattern in for other systems with finite states, such as enemy AI