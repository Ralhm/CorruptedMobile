using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.name);

        if (other.gameObject.layer == 12)
        {
            Debug.Log("Setting Checkpoint");
            other.gameObject.GetComponent<CombinedPlayers>().SetCheckpoint(other.gameObject.transform.position);
        }
    }
}
