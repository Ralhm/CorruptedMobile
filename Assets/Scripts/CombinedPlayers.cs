using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinedPlayers : MonoBehaviour
{

    AutoMovement Mover;

    public CameraController Controller;

    Vector3 CheckpointLocation;

    public NumbersPlayer NumPlayer;
    public RunnerPlayer RunningPlayer;

    public Transform LeadPosition;
    public Transform FollowPosition;

    public Rigidbody RB;

    public LayerMask Mask;
    public float TraceDistance;

    // Start is called before the first frame update
    void Awake()
    {
        Mover = GetComponent<AutoMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapLeader();
        }
    }


    private void FixedUpdate()
    {
        //Nasty ass bullshit
        if (Physics.Raycast(NumPlayer.transform.position, Vector3.right, TraceDistance, Mask))
        {
            Mover.IsMoving = false;
        }
        else if (Physics.Raycast(RunningPlayer.transform.position, transform.forward, TraceDistance, Mask))
        {
            Mover.IsMoving = false;
            return;
        }
        else {
            Mover.IsMoving = true;
        }
    }

    public void SwapLeader()
    {
        Mover.IsMovingForward = !Mover.IsMovingForward;

        RunningPlayer.transform.SetParent(transform);
        NumPlayer.transform.SetParent(transform);

        if (RunningPlayer.IsLead) //Switch to NumPlayer as Lead
        {





            RunningPlayer.IsLead = false;
            RunningPlayer.transform.position = FollowPosition.position;

            

            NumPlayer.IsLead = true;
            NumPlayer.transform.position = LeadPosition.position;
            NumPlayer.RB.useGravity = true;

            NumPlayer.transform.localRotation = Quaternion.Euler(-90, 0, 0);

            RunningPlayer.transform.SetParent(NumPlayer.transform);
            RunningPlayer.RB.useGravity = false;

            //Deactivate collision for non leads
            RunningPlayer.GetComponent<CapsuleCollider>().enabled = false;
            RunningPlayer.GetComponent<Rigidbody>().isKinematic = true;
            NumPlayer.GetComponent<BoxCollider>().enabled = true;



        }
        else //Switch to RunningPlayer as Lead
        {
            RunningPlayer.IsLead = true;
            RunningPlayer.transform.position = LeadPosition.position;
            RunningPlayer.RB.useGravity = true;

            NumPlayer.IsLead = false;
            NumPlayer.transform.position = FollowPosition.position;

            NumPlayer.RB.useGravity = false;

            RunningPlayer.GetComponent<CapsuleCollider>().enabled = true;
            RunningPlayer.GetComponent<Rigidbody>().isKinematic = false;
            NumPlayer.GetComponent<BoxCollider>().enabled = false;
            NumPlayer.RB.velocity = Vector3.zero;
        }



        Controller.SwapAngle();
    }


    public void Respawn()
    {
        transform.position = CheckpointLocation;


        if (RunningPlayer.IsLead) {

            RunningPlayer.transform.position = LeadPosition.position;
            NumPlayer.transform.position = FollowPosition.position;
        }
        else
        {
            RunningPlayer.transform.position = FollowPosition.position;
            NumPlayer.transform.position = LeadPosition.position;
        }
    }

    public void SetCheckpoint(Vector3 SpawnLocation)
    {
        CheckpointLocation = SpawnLocation;
    }


}
