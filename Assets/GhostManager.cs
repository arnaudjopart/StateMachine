using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostManager : MonoBehaviour {

    #region Public And Protected Members
    public Transform m_playerPrefab;
    //public m_current


    #endregion
    // Use this for initialization

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        InitialisePlayerPool();
    }

    void Start () {
        

        m_currentLeaderPlayer = m_ghostsList[ 0 ];
        m_currentLeaderPlayer.gameObject.name = "leader";
        m_currentLeaderPlayer.gameObject.SetActive( true );
        m_currentLeaderPlayer.position = new Vector3( 0, 2, 0 );

     
	}
	
	// Update is called once per frame
	void Update () {

        m_playerSize = m_currentLeaderPlayer.gameObject.GetComponent<StatePatternPlayer>().m_sizeOfPlayer;
        isLeadingPlayerLeavingScreenOnLeftSide = m_currentLeaderPlayer.position.x - m_playerSize.x*.5f < -CameraManager.Limits.x;
        isLeadingPlayerLeavingScreenOnRightSide = m_currentLeaderPlayer.position.x + m_playerSize.x*.5f > CameraManager.Limits.x;
        isLeadingPlayerLeavingScreenOnBottom = m_currentLeaderPlayer.position.y - m_playerSize.y * .5f < -CameraManager.Limits.y;
        if( isLeadingPlayerLeavingScreenOnLeftSide )
        {
            print( "leaving On Left" );
            if( !isAlreadyManagingLeftExit )
            {
                InitiateGhost( "Right" );
                isAlreadyManagingLeftExit = true;
                
            }
        }

        if( isLeadingPlayerLeavingScreenOnRightSide )
        {
            print( "leaving On Left" );
            if( !isAlreadyManagingRightExit )
            {
                InitiateGhost( "Left" );
                isAlreadyManagingRightExit = true;

            }
        }
        if( isLeadingPlayerLeavingScreenOnBottom )
        {
            print( "leaving On Left" );
            if( !isAlreadyManagingBottomExit )
            {
                InitiateGhost( "Up" );
                isAlreadyManagingBottomExit = true;

            }
        }


        else
        {
            
        }

        ManageGhosts();
	}

    #region Utils

    private void ManageGhosts()
    {
        foreach(Transform ghost in m_ghostsList )
        {
            if( ghost.gameObject.activeSelf )
            {
                if( Mathf.Abs( ghost.position.x ) > CameraManager.Limits.x+ m_playerSize.x*.6f /*|| Mathf.Abs( ghost.position.y ) > CameraManager.Limits.y */)
                {
                    
                    ghost.gameObject.SetActive( false );
                    
                    if( ghost.gameObject.name == "leader" )
                    {
                        FindNewLeader();
                        isAlreadyManagingLeftExit = false;
                        isLeadingPlayerLeavingScreenOnLeftSide = false;
                        isLeadingPlayerLeavingScreenOnRightSide= false;
                        isAlreadyManagingRightExit = false;

                        isAlreadyManagingLeftExit = false;
                        isLeadingPlayerLeavingScreenOnLeftSide = false;
                    }
                    if( ghost.gameObject.name == "Right" )
                    {
                        isAlreadyManagingLeftExit = false;
                        isLeadingPlayerLeavingScreenOnLeftSide = false;
                    }
                    if( ghost.gameObject.name == "Up" )
                    {
                        isAlreadyManagingLeftExit = false;
                        isLeadingPlayerLeavingScreenOnLeftSide = false;
                    }


                }
                
            }
            
        }
    }
    private void FindNewLeader()
    {
        foreach( Transform ghost in m_ghostsList )
        {
            if( ghost.gameObject.activeSelf )
            {
                m_currentLeaderPlayer = ghost;
                m_currentLeaderPlayer.gameObject.name = "leader";
            }

        }
    }

    private void InitiateGhost(string _sideOfTheScreen)
    {
        for(int i = 0; i < m_ghostsList.Count; i++ )
        {
            Transform ghost = m_ghostsList[ i ];
            if( ghost.gameObject.activeSelf == false )
            {
                print( "found Ghost" );
                if(_sideOfTheScreen == "Right" )
                {
                    ghost.position = m_currentLeaderPlayer.position + new Vector3( CameraManager.Limits.x * 2, 0, 0 );
                }
                if( _sideOfTheScreen == "Left" )
                {
                    ghost.position = m_currentLeaderPlayer.position + new Vector3( -CameraManager.Limits.x * 2, 0, 0 );
                }

                if( _sideOfTheScreen == "UP" )
                {
                    ghost.position = m_currentLeaderPlayer.position + new Vector3( 0, CameraManager.Limits.y * 2, 0 );
                }

                ghost.gameObject.SetActive( true );
                ghost.gameObject.name = _sideOfTheScreen;
                break;
            }
        }
    }

    private void InitialisePlayerPool()
    {
        for(int i = 0; i < 4; i++ )
        {
            Transform ghost = Instantiate(m_playerPrefab, Vector3.zero,Quaternion.identity) as Transform;
            
            ghost.SetParent( m_transform, false );
            ghost.gameObject.SetActive( false );
            m_ghostsList.Add( ghost );
        }
    }
    #endregion
    #region Private Members
    private bool isLeadingPlayerLeavingScreenOnLeftSide;
    private bool isLeadingPlayerLeavingScreenOnRightSide;
    private bool isLeadingPlayerLeavingScreenOnBottom;

    bool isAlreadyManagingLeftExit;
    bool isAlreadyManagingRightExit;
    bool isAlreadyManagingBottomExit;

    private Transform m_currentLeaderPlayer;
    private List<Transform> m_ghostsList = new List<Transform>();
    private List<Transform> m_currentListOfPlayerInstances = new List<Transform>();

    private Transform m_transform;
    private Vector2 m_playerSize;
    #endregion
}
