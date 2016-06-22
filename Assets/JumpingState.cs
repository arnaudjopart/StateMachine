﻿using UnityEngine;
using System.Collections;

public class JumpingState : IState {

    public StatePatternPlayer m_player;
    

    public JumpingState(StatePatternPlayer _player)
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_player.m_transform.position,Vector2.down,.1f,m_player.m_maskMe);
        
        if( hit.collider != null && m_player.m_rb2D.velocity.y<0 )
        {
            Debug.Log( "On Ground" );
            ToWalkState();
        }
        if( Input.GetKeyDown( KeyCode.DownArrow ) )
        {
            ToDiveState();
        }
    }
    public void ToJumpState()
    {
        Debug.Log( "Do nothing" );
    }
    public void ToWalkState()
    {
        m_player.m_currentState = m_player.m_walkingState;
    }
    public void ToDiveState()
    {
        Debug.Log( "Dive" );
        m_player.m_rb2D.AddForce( Vector2.down * 10, ForceMode2D.Impulse );
        m_player.m_currentState = m_player.m_diveState;
    }
    public void ToDuckState()
    {
        
    }
    #region Private Members
    
    #endregion  

}
