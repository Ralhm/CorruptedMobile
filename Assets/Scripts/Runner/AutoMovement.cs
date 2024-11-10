using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public bool IsMovingForward = true;
    public float ForwardSpeed;
    public float SideSpeed;
    

 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsMovingForward)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed);
        }
        else
        {
            transform.position += new Vector3(SideSpeed, 0, 0);
        }
    }



}
