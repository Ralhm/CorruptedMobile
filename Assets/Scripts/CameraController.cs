using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float OverheadAngle;
    public Vector3 OverheadPos;
    public Vector3 StraightPos;

    public bool isOverhead = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapAngle()
    {
        
        if (isOverhead)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localPosition = StraightPos;
            isOverhead = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(OverheadAngle, 0, 0);
            transform.localPosition = OverheadPos;
            isOverhead = true;
        }
        
    }


}
