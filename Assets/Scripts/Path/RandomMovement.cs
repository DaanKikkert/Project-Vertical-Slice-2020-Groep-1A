using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;
    [SerializeField] private float distance = 0.3f;
    [SerializeField] private UnityEvent OnPathComplete;
    [SerializeField] private UnityEvent OnMoveEvent;

    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;
    
    public void DebugMessage(String msg)
    {
        Debug.Log(msg);
    }
    
    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    private void Update()
    {
      Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //  Debug.Log("Moving towards: " + transform.position);
        //  Debug.Log("Extra debugs: " + transform.position + " Object name: " + transform.name);
        OnMoveEvent?.Invoke();
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < distance)
        {
            
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
                OnPathComplete?.Invoke();
            }
        }
    }
}
