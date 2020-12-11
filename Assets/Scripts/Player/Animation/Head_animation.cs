using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_animation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private Sprite[] heads;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[0];
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[1];
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[2];
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[3];
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[0];
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[1];
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[2];
        }
        else if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[3];
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heads[0];
        }
    }
}
