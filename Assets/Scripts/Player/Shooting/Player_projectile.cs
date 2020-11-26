using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_projectile : Projectile
{
    private GameObject player;
    private Playershooting _shooting;
    [SerializeField] private int _shootDirection;
    [SerializeField] private float speed;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _shooting = player.GetComponent<Playershooting>();
        _shootDirection = _shooting.shootDirection;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (_shootDirection)
        {
            case 1:
                transform.Translate(0, -speed * Time.deltaTime, 0);
                break;
            case 2:
                transform.Translate(speed * Time.deltaTime, 0, 0);
                break;
            case 3:
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                break;
            case 4:
                transform.Translate(0, speed * Time.deltaTime, 0);
                break;
        }

    }
}
