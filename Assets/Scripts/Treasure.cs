using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : CollectibleBase
{
    //[SerializeField] Text treasureUI = null;
    [SerializeField] int _treasureAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Collect(Player player)
    {
        player.IncreaseTreasure(_treasureAmount);
    }
}
