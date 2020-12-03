using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private GameObject prefabBullet;
  [SerializeField] private GameObject player;
  [SerializeField] private GameObject shootPos;
  [SerializeField] private float timeBetweenShots = 0.3333f; // 3 shots per second
  [SerializeField] private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Time.time >= timestamp)
        {
            Vector2 position = new Vector2(player.transform.position.x, player.transform.position.y);
            
            GameObject bullet =
                Instantiate(prefabBullet, shootPos.transform.position, Quaternion.identity) as GameObject;
            timestamp = Time.time + timeBetweenShots;
            
            bullet.transform.LookAt(position);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 1000);
        }
    }
}
