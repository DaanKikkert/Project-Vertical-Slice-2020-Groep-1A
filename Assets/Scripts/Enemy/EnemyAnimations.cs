using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Vector3 prevPos;
    private Vector3 direction;
    Animator pacerAnim;

    void Start()
    {
        prevPos = transform.position;
        pacerAnim = GetComponent<Animator>();
    }



    void Update()
    {
        Vector3 direction = (transform.position - prevPos);

        prevPos = transform.position;
        //Debug.Log(direction);
        if (direction.x > 0 && direction.x > direction.y)
        {
            Debug.Log("Left");
            pacerAnim.SetInteger("WalkDirection", 3);
        }
        else if (direction.x < 0 && direction.x < direction.y)
        {
            Debug.Log("Right");
            pacerAnim.SetInteger("WalkDirection", 4);
        }
        else if (direction.y > 0)
        {
            Debug.Log("Upwards");
            pacerAnim.SetInteger("WalkDirection", 1);
        }
        else if(direction.y < 0)
        {
            Debug.Log("Downwards");
            pacerAnim.SetInteger("WalkDirection", 2);
        }
        
    }
    
}
