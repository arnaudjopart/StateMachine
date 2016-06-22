using UnityEngine;
using System.Collections;

public class DuckState : IState {

    public StatePatternPlayer m_player;

    public DuckState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        if( Input.GetKeyUp( KeyCode.DownArrow ) )
        {
            ToWalkState();
        }
    }
    public void ToJumpState()
    {
        
    }
    public void ToWalkState()
    {
        m_player.m_currentState = m_player.m_walkingState;
        m_player.m_animator.SetBool( "IsDucking", false );
        Debug.Log( "To WalkState" );
    }
    public void ToDiveState()
    {

    }
    public void ToDuckState()
    {
        Debug.Log( "Do nothing" );
    }
    public void ToFallingState()
    {

    }
}
