using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : MonoBehaviour
{    
    Animator bodyAnim;
    // Start is called before the first frame update
    void Start()
    {
        
        bodyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            bodyAnim.SetInteger("WalkDirection", 1);           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            bodyAnim.SetInteger("WalkDirection", 2);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            bodyAnim.SetInteger("WalkDirection", 3);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            bodyAnim.SetInteger("WalkDirection", 4);
        }
        else
        {
            bodyAnim.SetInteger("WalkDirection", 0);            
        }
    }
}
