using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour
{


    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoseHealth()
    {
        Health--;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
