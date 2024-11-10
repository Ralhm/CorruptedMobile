using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float Speed;
    public int Lifespan;
    public Vector3 MoveDir;
    Rigidbody RB;

    public void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Destroy(this.gameObject, Lifespan);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //RB.AddForce(MoveDir * Speed);
    }

    public void SetMoveDir(Vector3 dir)
    {
        MoveDir = dir;
        RB.velocity = MoveDir * Speed;
    }

}
