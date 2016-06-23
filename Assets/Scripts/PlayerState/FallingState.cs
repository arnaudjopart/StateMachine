using UnityEngine;
using System.Collections;

public class FallingState : IState {

    public StatePatternPlayer m_player;

    public FallingState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        float xDirection = Input.GetAxis("Horizontal");
        if( Mathf.Abs( xDirection ) > 0.1f )
        {
            m_player.m_sr.flipX = xDirection < 0 ? true : false;
        }

        Vector3 jumpVelocity = new Vector3(xDirection*3,m_player.m_rb2D.velocity.y,0);
        m_player.m_rb2D.velocity = jumpVelocity;


        RaycastHit2D hit = Physics2D.Raycast(m_player.m_transform.position,Vector2.down,.1f,m_player.m_maskMe);

        if( hit.collider != null && m_player.m_rb2D.velocity.y < 0 )
        {
            if( m_player.gameObject.name == "Tim" )
            {
                Debug.Log( "On Ground" );

                m_player.m_transform.SetParent( hit.collider.transform.parent, false );
                Vector3 localPosition = m_player.m_transform.position-hit.collider.transform.parent.position;
                m_player.m_transform.position = localPosition;

            }
            

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
