using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ParentHealth : MonoBehaviour
{

    [SerializeField] private float _startHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _dmg;


    void Awake()
    {
        //Zet de health die gebruikt word gelijk aan een standaard value
        _currentHealth = _startHealth;
    }

    public void TakeDamage()
    {
        //Doet de damage door dmg van currentHealth af te halen
        _currentHealth -= _dmg;
        //Print zet de hp die over is in het console.
        print(_currentHealth);

        if (_currentHealth <= 0f)
        {
            Death();
        }

    }

    void Death()
    {
        Destroy(this.gameObject);
        print("death");
    }
}
