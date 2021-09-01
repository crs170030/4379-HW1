using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerUp : PowerUpBase
{
    //[SerializeField] Material glowup = null;
    //[SerializeField] GameObject gun = null;
    //[SerializeField] GameObject box = null;
    //[SerializeField] GameObject tire_left = null;
    //[SerializeField] GameObject tire_right = null;

    //either: get ref for the two mats, change color to blue, and then reset 
    //or do all color changes in the power up script

    protected override void PowerUp(Player player)
    {
        //make colors go whoosh
       // gun.GetComponent<MeshRenderer>().material = glowup;
       // box.GetComponent<MeshRenderer>().material = glowup;
        //tire_left.GetComponent<MeshRenderer>().material = glowup;
        //tire_right.GetComponent<MeshRenderer>().material = glowup;
    }
}
