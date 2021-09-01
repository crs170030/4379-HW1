using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text treasureText;

    public int treasureCount;

    // initialization
    void Start()
    {
        treasureText = GetComponent<Text>() as Text;
    }

    void FixedUpdate()
    {
        //treasureCount += 1;
        //treasureText.text = "Treasure: " + treasureCount.ToString("00");
    }
    
    public void IncreaseTreasure(int amount)
    {
        //treasureCount += amount;
    }
}
