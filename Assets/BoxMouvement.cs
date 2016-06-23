using UnityEngine;
using System.Collections;

public class BoxMouvement : MonoBehaviour {

    #region Public And Protected Members
    public float m_amplitude;
    #endregion
    // Use this for initialization
    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    void Start () {
	    startPosition = m_transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Mathf.Sin(Time.timeSinceLevelLoad);

        transform.position = startPosition + Vector3.right* m_amplitude * distance;
        
	}
    #region Private Members
    private Vector3 startPosition;
    private Transform m_transform;

    #endregion
}
