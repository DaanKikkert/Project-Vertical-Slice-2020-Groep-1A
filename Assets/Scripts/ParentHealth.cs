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

    // Called from UnityEvent
    //public void TakeDamage(float dmg = 1f)
    //{
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            
        //}

//    }

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
    }

    public void Death()
    {
        Destroy(gameObject);
        print("Death");
    }
}
