using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    #region Public And Protected Members

    public static Vector2 Limits;


    #endregion

    // Use this for initialization
    void Awake()
    {
        SetScreenLimits();
    }

    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        SetScreenLimits();
    }
    #region Utils
    private void SetScreenLimits()
    {
        Vector3 cameraLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        float verticalLimit = Mathf.Abs(cameraLimit.y);
        float horizontalLimit = Mathf.Abs(cameraLimit.x);
        Limits = new Vector2(horizontalLimit, verticalLimit);
    }
    #endregion
}
