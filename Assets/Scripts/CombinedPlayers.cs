using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void SwapLeader()
    {
        Mover.IsMovingForward = !Mover.IsMovingForward;

        RunningPlayer.transform.SetParent(transform);
        NumPlayer.transform.SetParent(transform);

        if (RunningPlayer.IsLead)
        {





            RunningPlayer.IsLead = false;
            RunningPlayer.transform.position = FollowPosition.position;

            

            NumPlayer.IsLead = true;
            NumPlayer.transform.position = LeadPosition.position;

            RunningPlayer.transform.SetParent(NumPlayer.transform);




        }
        else
        {
            RunningPlayer.IsLead = true;
            RunningPlayer.transform.position = LeadPosition.position;

            NumPlayer.IsLead = false;
            NumPlayer.transform.position = FollowPosition.position;

            NumPlayer.transform.SetParent(RunningPlayer.transform);
        }



        Controller.SwapAngle();
    }


    public void Respawn()
    {
        transform.position = CheckpointLocation;
    }

    public void SetCheckpoint(Vector3 SpawnLocation)
    {
        CheckpointLocation = SpawnLocation;
    }

    public void Jump(float Force)
    {
        RB.AddForce(Force * transform.up);
    }
}
