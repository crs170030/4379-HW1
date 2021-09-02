using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float powerupDuration = 5f;
    [SerializeField] Material glowup = null;
    [SerializeField] ParticleSystem _collectParticles = null;
    [SerializeField] AudioClip _collectSound = null;
    //[SerializeField] float timeFlash = 0.1f;

    protected abstract void PowerUp(Player player);

    Player savedPlayer;
    float timeRemaining;
    bool isActive;
    //bool flashToggle = true;

    MeshRenderer _msh;
    BoxCollider _bcd;
    Rigidbody _rb;     

    private void Awake()
    {
        //get powerup visuals
        _rb = GetComponent<Rigidbody>();
        _msh = GetComponent<MeshRenderer>();
        _bcd = GetComponent<BoxCollider>(); //WARNING: What if shape is not a box?
        //get tank visuals
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            //spawn particles and sfx and sex because we need to disable object
            //Feedback();
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }

    protected virtual void Collect(Player player)
    {
        //call power up script
        PowerUp(player);
        timeRemaining = powerupDuration;
        isActive = true;
        savedPlayer = player;
        player.ChangeColor(false, glowup);
        Debug.Log("Powering Up.");
        Debug.Log("Time remaining == "+ timeRemaining);
        //disable visuals on power up
        //disable mesh renderer
        _msh.enabled = false;
        //disable collider
        _bcd.enabled = false;
    }

    protected virtual void PowerDown(Player player) //override this if the powerup need to do something
    {
        PowerDownBase(player); 
    }

    protected virtual void PowerDownBase(Player player)
    {
        Debug.Log("Powering Down...");
        isActive = false;

        //reset colors on player
        player.ChangeColor(true, glowup);

        //disable the power up
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(timeRemaining >= 0)
        {
            //Debug.Log("Time remaining == "+ timeRemaining);
            timeRemaining -= Time.deltaTime;
            /*timeFlash -= Time.deltaTime;
            if(timeRemaining < 1 && timeFlash >= 0)
            {
                flashToggle = !flashToggle;
                savedPlayer.ChangeColor(flashToggle, glowup);
            }*/
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
