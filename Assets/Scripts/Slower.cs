using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Add Time limit on Slow Down Effect. Add a timer for 5 seconds that calls change speed again to positive speed amount

public class Slower : Enemy
{
    [SerializeField] float _speedAmount = .25f;

    protected override void PlayerImpact(Player player)
    {
        player.ChangeSpeed(-_speedAmount);
    }
}
