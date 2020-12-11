using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private GameObject Projectile;
    public int shootDirection;
    [SerializeField] private float shootDelay;
    private float shootTimer;    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= 1f * Time.deltaTime;
        if (shootTimer <= 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                shootDirection = 1;
                Shoot(0);
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                shootDirection = 2;
                Shoot(1);
                
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                shootDirection = 3;
                Shoot(2);
                
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                shootDirection = 4;
                Shoot(3);
                
            }
            
            
        }
        //Debug.Log(shootTimer);
    }

    void Shoot(int _shootpoint)
    {
        Vector3 _instantiateLocation = new Vector3(shootPoints[_shootpoint].transform.position.x, shootPoints[_shootpoint].transform.position.y, shootPoints[_shootpoint].transform.position.z);
        Instantiate(Projectile, _instantiateLocation, this.gameObject.transform.rotation);
        shootTimer = shootDelay;
    }
}
