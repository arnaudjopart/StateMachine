using UnityEngine;
using System.Collections;

public class DiveState : IState {

    public StatePatternPlayer m_player;

    public DiveState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_player.m_transform.position,Vector2.down,.1f,m_player.m_maskMe);

        if( hit.collider != null && m_player.m_rb2D.velocity.y < 0 )
        {
            Debug.Log( "On Ground" );
            ToWalkState();
        }
    }
    public void ToJumpState()
    {

    }
    public void ToWalkState()
    {
        m_player.m_currentState = m_player.m_walkingState;
    }
    public void ToDiveState()
    {
        Debug.Log( "Do nothing" );
    }
    public void ToDuckState()
    {
        Debug.Log( "Do nothing" );
    }
    public void ToFallingState()
    {

    }
}
