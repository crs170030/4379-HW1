using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] Text _treasureUI = null;

    int _currentHealth;
    int _treasureCount;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    void Start()
    {
        _currentHealth = _maxHealth; //reset health at start
        _treasureCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureCount += amount;
        _treasureUI.text = "Treasure = " + _treasureCount;
        Debug.Log("Treasure = " + _treasureCount);
    }

    public void ChangeSpeed(float amount)
    {
        _tankController.MaxSpeed += amount;
        Debug.Log("MaxSpeed is now " + _tankController.MaxSpeed);
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles, man
        //play sounds
    }
}
