using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NumbersPlayer : MonoBehaviour
{

    public TextMeshProUGUI NumText;
    public static NumbersPlayer instance = null;



    public int CurrentNum;
    public int StartingNum;

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
            DontDestroyOnLoad(transform.gameObject);
        }
        CurrentNum = StartingNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(NumbersEnemy Enemy) 
    {
        if (Enemy.IsCorrupted) { 
        
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
}
