using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{

    public static RunnerPlayer instance = null;

    public float MoveSpeed;

    public bool IsShooting;

    public Rigidbody RB;

    public GameObject NumPlayer;

    public GameObject Bullet;
    public float FireRate;
    public int NumShots = 1;
    public int MaxShots = 3;

    bool CanFire = true;


    public bool IsLead;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void Update()
    {

        if (IsLead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsShooting = true;


                if (CanFire)
                {
                    StartCoroutine(ShootRoutine());
                }

            }

            if (Input.GetMouseButtonUp(0))
            {
                IsShooting = false;
            }

            FindLookRotation();
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (IsLead)
        {
            float Dir = Input.GetAxis("Horizontal");

            transform.position += new Vector3(Dir * MoveSpeed, 0, 0);

            if (NumPlayer)
            {
                NumPlayer.transform.position += new Vector3(Dir * MoveSpeed, 0, 0);
            }


        }


        

    }

    public void Shoot(Vector3 Dir)
    {
        Bullet NewBullet = Instantiate(Bullet, transform.position, transform.rotation).GetComponent<Bullet>();
        NewBullet.SetMoveDir(Dir);




    }

    IEnumerator ShootRoutine()
    {
        while (IsShooting) { 
            CanFire = false;
            Shoot(transform.forward);

            if (NumShots >= 2)
            {
                Shoot((transform.forward + (transform.right * 0.5f)).normalized);
            }

            if (NumShots >= 3)
            {
                Shoot((transform.forward - (transform.right * 0.5f)).normalized);
            }


            yield return new WaitForSeconds(FireRate);
            CanFire = true;

        }




    }

    public void FindLookRotation()
    {

        Ray trace = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 LookPos = Camera.main.transform.position + (trace.direction * (Camera.main.transform.position - transform.position).magnitude);
        LookPos = new Vector3(LookPos.x, transform.position.y, LookPos.z);
        transform.LookAt(LookPos);

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

        if (NumShots > MaxShots)
        {
            NumShots = MaxShots;
        }

        if (NumShots <= 0)
        {
            NumShots = 1;

        }
    }



    void SetLead(bool input)
    {
        IsLead = input;
    }
}
