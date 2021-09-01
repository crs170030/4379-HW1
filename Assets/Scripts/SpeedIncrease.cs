using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 5;

    protected override void Collect(Player player)
    {
        //pull motor controller from player
        //TankController controller = player.GetComponent<TankController>();
        if(player != null)//controller != null
        {
            //controller.MaxSpeed += _speedAmount;
            //Debug.Log("max speed is now " + controller.MaxSpeed);
            player.ChangeSpeed(_speedAmount);
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        //calculated rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
