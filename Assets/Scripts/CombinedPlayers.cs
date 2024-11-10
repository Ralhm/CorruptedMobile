using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedPlayers : MonoBehaviour
{

    AutoMovement Mover;

    CameraController Controller;

    Vector3 CheckpointLocation;

    public NumbersPlayer NumbersPlayer;
    public RunnerPlayer RunnerPlayer;


    // Start is called before the first frame update
    void Awake()
    {
        Mover = GetComponent<AutoMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SwapLeader()
    {
        Mover.IsMovingForward = !Mover.IsMovingForward;
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
}
