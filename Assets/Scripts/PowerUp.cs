using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : CollectibleBase
{
    [SerializeField] float powerupDuration = 5f;

    //bad solution: change every tank piece indivdually. Better to change the body material itself in real time?
    [SerializeField] GameObject turret = null;
    [SerializeField] GameObject body = null;
    [SerializeField] GameObject left_tred = null;
    [SerializeField] GameObject right_tred = null;

    [SerializeField] Material defaultPaint = null;
    [SerializeField] Material defaultTires = null;

    protected abstract void PowerUp(Player player);

    Player savedPlayer;
    float timeRemaining;
    bool isActive;

    MeshRenderer _msh;
    BoxCollider _bcd;

    private void Awake()
    {
        //get powerup visuals
        _msh = GetComponent<MeshRenderer>();
        _bcd = GetComponent<BoxCollider>(); //WARNING: What if shape is not a box?
        //get tank visuals
        
    }

    protected override void Collect(Player player)
    {
        //call power up script
        PowerUp(player);
        timeRemaining = powerupDuration;
        isActive = true;
        savedPlayer = player;
        Debug.Log("Powering Up.");
        //disable visuals on power up
        //disable mesh renderer
        _msh.enabled = false;
        //disable collider
        _bcd.enabled = false;
    }

    protected virtual void PowerDown(Player player)
    {
        Debug.Log("Powering Down...");
        isActive = false;

        //reset colors on player
        turret.GetComponent<MeshRenderer>().material = defaultPaint;
        body.GetComponent<MeshRenderer>().material = defaultPaint;
        left_tred.GetComponent<MeshRenderer>().material = defaultTires;
        right_tred.GetComponent<MeshRenderer>().material = defaultTires;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            if(isActive == true)
            {
                PowerDown(savedPlayer);      
            }
        }
    }

    
}
