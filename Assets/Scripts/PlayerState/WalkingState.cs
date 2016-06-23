using UnityEngine;
using System.Collections;

public class WalkingState : IState {

    

    public WalkingState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_player.m_transform.position,Vector2.down,.1f,m_player.m_maskMe);

        if( hit.collider == null )
        {
            
            ToFallingState();
        }

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
        if( m_player.gameObject.name == "Tim" )
        {

            m_player.m_rb2D.AddForce( Vector2.up * 10, ForceMode2D.Impulse );
            Vector3 Worldposition = m_player.m_transform.position;
            //Debug.Log( m_player.m_transform.position );

            m_player.m_transform.SetParent( m_player.m_transform.parent.parent, false );
            m_player.m_transform.position = Worldposition;
        }

        
        
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
        if( m_player.gameObject.name == "Tim" )
        {
            m_player.m_rb2D.AddForce( Vector2.up * 10, ForceMode2D.Impulse );
            Vector3 Worldposition = m_player.m_transform.position;
            //Debug.Log( m_player.m_transform.position );

            m_player.m_transform.SetParent( m_player.m_transform.parent.parent, false );
            m_player.m_transform.position = Worldposition;
        }
        


        m_player.m_currentState = m_player.m_fallingState;

    }

    #region Private Members
    private StatePatternPlayer m_player;
    #endregion
}
