using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFireRate : RunnerPickup
{
    public float FireRate;

    public override void AdjustPlayer()
    {
        RunnerPlayer.instance.AdjustFireRate(-FireRate);

    }


}
