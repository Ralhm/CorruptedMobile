using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShots : RunnerPickup
{

    public int NumShots;

    public override void AdjustPlayer()
    {
        RunnerPlayer.instance.AdjustSpreadShot(NumShots);

    }
}
