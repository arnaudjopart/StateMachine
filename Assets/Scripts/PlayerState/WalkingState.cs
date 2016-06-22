using UnityEngine;
using System.Collections;

public class WalkingState : IState {

    

    public WalkingState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        float xDirection = Input.GetAxis("Horizontal");
        if( Mathf.Abs( xDirection )>0.1f )
        {
            m_player.m_sr.flipX = xDirection < 0 ? true:false;


        }
        m_player.m_animator.SetFloat( "IsRunning", Mathf.Abs( xDirection ) );
        Vector3 direction = new Vector3(xDirection,0,0);
        m_player.m_rb2D.velocity = direction * 6;

        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            ToJumpState();
        }
        if( Input.GetKeyDown( KeyCode.DownArrow ) )
        {
            ToDuckState();
        }
    }
    public void ToJumpState()
    {
        m_player.m_rb2D.AddForce( Vector2.up * 10, ForceMode2D.Impulse );
        m_player.m_currentState = m_player.m_jumpingState;
    }
    public void ToWalkState()
    {
        Debug.Log( "Do nothing" );
    }
    public void ToDiveState()
    {

    }
    public void ToDuckState()
    {
        Debug.Log( "Duck" );
        m_player.m_currentState = m_player.m_duckState;
        m_player.m_animator.SetBool( "IsDucking", true );
    }
    public void ToFallingState()
    {

    }

    #region Private Members
    private StatePatternPlayer m_player;
    #endregion
}
