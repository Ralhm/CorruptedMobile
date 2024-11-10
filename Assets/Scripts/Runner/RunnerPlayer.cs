using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{

    public float MoveSpeed;
    public float ForwardSpeed;
    public bool IsShooting;
     
    public GameObject Bullet;
    public float FireRate;
    public int NumShots = 1;

    bool CanFire = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsShooting = true;


            if (CanFire) {
                StartCoroutine(ShootRoutine());
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsShooting = false;
        }

        FindLookRotation();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Dir = Input.GetAxis("Horizontal");

        transform.position += new Vector3(Dir * MoveSpeed, 0, 0);
        transform.position += new Vector3(0, 0, ForwardSpeed);

    }

    public void Shoot()
    {
        Bullet NewBullet = Instantiate(Bullet, transform.position, transform.rotation).GetComponent<Bullet>();
        NewBullet.SetMoveDir(transform.forward);

    }

    IEnumerator ShootRoutine()
    {
        while (IsShooting) { 
            CanFire = false;
            Shoot();

            yield return new WaitForSeconds(FireRate);
            CanFire = true;

        }




    }

    public void FindLookRotation()
    {
        //Debug.Log("Looking!");

        Ray trace = Camera.main.ScreenPointToRay(Input.mousePosition);


        Vector3 LookPos = Camera.main.transform.position + (trace.direction * (Camera.main.transform.position - transform.position).magnitude);

        LookPos = new Vector3(LookPos.x, transform.position.y, LookPos.z);

        transform.LookAt(LookPos);

        //transform.rotation = Quaternion.Euler(transform.rotation.x, Dir.y, transform.rotation.z);
    }

    public void AdjustFireRate(float val)
    {
        FireRate += val;

        if (FireRate <= 0)
        {
            FireRate = 0.1f;

        }
    }

    public void AdjustMoveSpeed(float val)
    {
        MoveSpeed += val;

        if (MoveSpeed <= 0) {
            MoveSpeed = 0.1f;
        
        }
    }

    public void AdjustSpreadShot(int val)
    {
        NumShots += val;

        if (NumShots <= 0)
        {
            NumShots = 1;

        }
    }
}
