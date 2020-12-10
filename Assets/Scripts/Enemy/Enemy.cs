using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shootPos;
    [SerializeField] private float timeBetweenShots = 0.3333f; // 3 shots per second
    [SerializeField] private float timestamp;
    [SerializeField] private bool active;
    [SerializeField] private int bulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug purposes Shoot2(active);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Random rnd = new Random();
           
            int chance = rnd.Next(1, 11);
            Debug.Log(chance);
           
            if (!chance.Equals(10)) return;

            GameObject bullet =
                Instantiate(prefabBullet, shootPos.transform.position, Quaternion.identity) as GameObject;
        //    timestamp = Time.time + timeBetweenShots;
            
            bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * bulletSpeed;
        }
    }
    
    void Shoot2(bool active)
    {
        if (!active) return;

        if (Time.time >= timestamp)
        {

            GameObject bullet =
                Instantiate(prefabBullet, shootPos.transform.position, Quaternion.identity) as GameObject;
            timestamp = Time.time + timeBetweenShots;

            bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * bulletSpeed;
        }
    }
}