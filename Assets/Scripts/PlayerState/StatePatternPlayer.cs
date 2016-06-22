using UnityEngine;
using System.Collections;

public class StatePatternPlayer : MonoBehaviour {

    // Use this for initialization
    #region Public and Protected Members
    public WalkingState m_walkingState;
    public JumpingState m_jumpingState;
    public DiveState m_diveState;
    public DuckState m_duckState;
    public FallingState m_fallingState;

    public IState m_currentState;

    [HideInInspector]
    public Rigidbody2D m_rb2D;
    [HideInInspector]
    public Transform m_transform;
    [HideInInspector]
    public Animator m_animator;
    [HideInInspector]
    public SpriteRenderer m_sr;

    public LayerMask m_maskMe;
    public GameObject m_sprite;

    #endregion

    #region Main Methods

    void Start()
    {

        m_rb2D = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_animator = GetComponent<Animator>();
        m_sr = m_sprite.GetComponent<SpriteRenderer>();

        m_walkingState = new WalkingState( this );
        m_jumpingState = new JumpingState( this );
        m_duckState = new DuckState( this );
        m_diveState = new DiveState( this );
        m_fallingState = new FallingState( this );

        m_currentState = m_jumpingState;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentState.UpdateState();
        Debug.DrawLine(m_transform.position, m_transform.position+Vector3.down * 2 );
        CheckScreenLimits();
    }

    #endregion

    #region Utils

    private void CheckScreenLimits()
    {
        Vector2 sizeOfPlayer = m_sr.sprite.rect.size/m_sr.sprite.pixelsPerUnit;
        bool isPlayerOutOfScreen =  Mathf.Abs( m_transform.position.x ) + sizeOfPlayer.x*.5f > CameraManager.Limits.x;
        if( isPlayerOutOfScreen )
        {
            print( "Out of Screen" );
        }
    }

    #endregion

    #region Private Members


    #endregion
}
