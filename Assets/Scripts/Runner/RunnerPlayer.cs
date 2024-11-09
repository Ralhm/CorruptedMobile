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
        if (Input.GetKeyDown(KeyCode.Space)) {
            IsShooting = true;


            if (CanFire) {
                StartCoroutine(ShootRoutine());
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
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
        Instantiate(Bullet, transform.position, transform.rotation);
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
        Debug.Log("Shooting!");

        Ray trace = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Physics.Raycast(trace, out Hit))
        {
            Debug.Log(Hit.collider.gameObject.name);
            if (Hit.collider != null)
            {


            }




        }


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
