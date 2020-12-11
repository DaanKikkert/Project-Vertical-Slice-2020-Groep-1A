using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startHealth;
    [SerializeField] private float _currentHealth;    


    void Awake()
    {
        //Zet de health die gebruikt word gelijk aan een standaard value
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float _dmg)
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

