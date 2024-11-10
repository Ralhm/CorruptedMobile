using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : RunnerPickup
{
    public float Speed;

    public override void AdjustPlayer()
    {
        RunnerPlayer.instance.AdjustMoveSpeed(Speed);

    }
}
