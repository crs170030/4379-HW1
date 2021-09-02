using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePowerUp : PowerUpBase
{
    protected override void PowerUp(Player player)
    {
        player.damagable = false;
    }

    protected override void PowerDown(Player player)
    {
        player.damagable = true;
        PowerDownBase(player);
    }
}
