using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health playerhealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerhealth.TakeDamage(1);
        }
    }
}
