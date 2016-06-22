using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GhostManagerV2 : MonoBehaviour {

    #region Public And Protected Members
    public Transform m_playerPrefab;
    public Transform m_player;
    public Vector3 m_positionOPlayerSpawn = new Vector3(0, 0, 0);
    #endregion

    #region Main Methods

    void Awake()
    {
        print(CameraManager.Limits);
        m_transform = GetComponent<Transform>();
        
        m_positionsOfGhosts.Add(new Vector3(-CameraManager.Limits.x * 2, CameraManager.Limits.y * 2, 0));
        m_positionsOfGhosts.Add(new Vector3(-CameraManager.Limits.x * 2, 0 , 0));
        m_positionsOfGhosts.Add(new Vector3(-CameraManager.Limits.x * 2, -CameraManager.Limits.y * 2, 0));

        m_positionsOfGhosts.Add(new Vector3(0, CameraManager.Limits.y * 2, 0));
        
        m_positionsOfGhosts.Add( new Vector3(0, -CameraManager.Limits.y * 2, 0));

        m_positionsOfGhosts.Add(new Vector3(CameraManager.Limits.x * 2, CameraManager.Limits.y * 2, 0));
        m_positionsOfGhosts.Add(new Vector3(CameraManager.Limits.x * 2, 0 * 2, 0));
        m_positionsOfGhosts.Add(new Vector3(CameraManager.Limits.x * 2, -CameraManager.Limits.y * 2, 0));

    }
    void Start()
    {
        CreateGhosts();
    }

    // Update is called once per frame
    void Update()
    {
      ManageInstancies();        
    }
    #endregion

    // Use this for initialization

    #region Utils
    private void CreateGhosts()
    {
        foreach(Vector3 position in m_positionsOfGhosts)
        {
            Transform playerInstance = Instantiate(m_playerPrefab, Vector3.zero, Quaternion.identity) as Transform;
            playerInstance.gameObject.GetComponent<Collider2D>().enabled = false;
            playerInstance.SetParent(m_transform, false);
        }
    }
    private void ManageInstancies()
    {
        for (int i = 0; i < m_positionsOfGhosts.Count; i++)
        {
            m_transform.GetChild(i).position = m_player.position + m_positionsOfGhosts[i];
            //m_transform.gameObject.GetComponent<StatePatternPlayer>().m_currentState = m_player.gameObject.GetComponent<StatePatternPlayer>().m_currentState;
        }


        foreach (Transform instance in m_transform)
        {
            bool isInstanceOnScreen = Mathf.Abs(instance.position.x) < CameraManager.Limits.x && Mathf.Abs(instance.position.y) < CameraManager.Limits.y;
            if (isInstanceOnScreen)
            {
                
                m_player.position = instance.position;
                break;
            }

        }

        

       
    }
    #endregion
    #region Private Members

    private Transform m_transform;
    private List<Vector3> m_positionsOfGhosts = new List<Vector3>();
    private Vector3 position;
    #endregion
}
