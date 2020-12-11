using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_projectile : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Playershooting _shooting;
    private Rigidbody2D rigidb;
    [SerializeField] private int _shootDirection;
    [SerializeField] private float speed;
    [SerializeField] private float fallTimer = 1;
    float pVelocityX;
    float pVelocityY;
    [SerializeField] private int velDiv;

    public float dmg;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidb = player.GetComponent<Rigidbody2D>();
        _shooting = player.GetComponent<Playershooting>();
        _shootDirection = _shooting.shootDirection;

        pVelocityX = rigidb.velocity.x;
        pVelocityY = rigidb.velocity.y;
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidb.velocity.x);
        switch (_shootDirection)
        {
            case 1:
                transform.Translate(pVelocityX / velDiv  * Time.deltaTime, -speed * Time.deltaTime, 0);
                break;
            case 2:
                transform.Translate(speed * Time.deltaTime, pVelocityY / velDiv * Time.deltaTime, 0);
                break;
            case 3:
                transform.Translate(-speed * Time.deltaTime, pVelocityY / velDiv * Time.deltaTime, 0);
                break;
            case 4:
                transform.Translate(pVelocityX / velDiv * Time.deltaTime, speed * Time.deltaTime, 0);
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            if (collision.tag == "Enemy")
            {
                Health enemyHealth = collision.gameObject.GetComponent<Health>();
                enemyHealth.TakeDamage(dmg);
                Destroy(this.gameObject);
            }
            Destroy(this.gameObject);
        }        
    }
}
