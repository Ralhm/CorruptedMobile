using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float OverheadAngle;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToOverheadAngle()
    {
        transform.rotation = new Quaternion(OverheadAngle, 0, 0, 0);
    }

    public void MoveToStraightAngle()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
