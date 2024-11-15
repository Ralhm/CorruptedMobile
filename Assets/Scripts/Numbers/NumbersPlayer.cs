using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumbersPlayer : MonoBehaviour
{

    public TextMeshProUGUI NumText;
    public static NumbersPlayer instance = null;

    public Rigidbody RB;



    public bool IsLookingAtCamera;
    public int CurrentNum;
    public int StartingNum;
    public float JumpForce;

    public bool IsLead;

    public LayerMask Mask;
    public int TraceDistance;

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
        CurrentNum = StartingNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLead) {
            if (Input.GetMouseButtonDown(0))
            {
                GetHitTarget();

            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            
            }

        }
        LookAtCamera();
    }

    public void Attack(NumbersEnemy Enemy) 
    {
        if (Enemy.IsCorrupted) {
            Enemy.Die();
            return;
        }


        if (Enemy.Num > CurrentNum) {
            Enemy.Attack();
        }
        else
        {
            Enemy.Die();
        }
    }

    public void IncreaseNum(int val)
    {
        CurrentNum += val;
        NumText.text = CurrentNum.ToString();
    }

    public void DecreaseNum(int val)
    {



        CurrentNum -= val;
        if (CurrentNum < StartingNum) { 
            CurrentNum = StartingNum;
        }


        NumText.text = CurrentNum.ToString();




    }


    public void GetHitTarget()
    {
        //Debug.Log("Shooting!");

        Ray trace = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Physics.Raycast(trace, out Hit))
        {
            Debug.Log(Hit.collider.gameObject.name);
            if (Hit.collider != null)
            {

                NumbersEnemy enemy = Hit.collider.gameObject.GetComponent<NumbersEnemy>();
                if (enemy != null)
                {
                    NumbersPlayer.instance.Attack(enemy);
                    Debug.Log("Hit Enemy!");

                }

            }




        }

    }

    public void LookAtCamera()
    {
        //Vector3 dir = (new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z) - transform.position).normalized;

        
    }

    public void Jump()
    {
        //Debug.DrawLine(transform.position, transform.position + (Vector3.down * TraceDistance));
        if (Physics.Raycast(transform.position, Vector3.down, TraceDistance, Mask) )
        {
            RB.AddForce(JumpForce * Vector3.up);
        }



        
    }

    void SetLead(bool input)
    {
        IsLead = input;
    }
}
