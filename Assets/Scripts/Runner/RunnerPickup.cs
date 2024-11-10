using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPickup : MonoBehaviour
{



    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            AdjustPlayer();
            Destroy(this.gameObject);

        }
    }

    public virtual void AdjustPlayer()
    {



    }

}
