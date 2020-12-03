using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ParentHealth : MonoBehaviour
{

    [SerializeField] private float _startHealth = 5f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    void Update()
    { 
        float dmg = 1f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentHealth -= dmg;
            print("Taking damage");
            if (_currentHealth <= 0)
            {
                Death();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        float dmg = 1f;
        _currentHealth -= dmg;
        print("Taking damage");

        if (_currentHealth <= 0)
        {
            Death();
            print("Death");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        print("Death");
    }
}
