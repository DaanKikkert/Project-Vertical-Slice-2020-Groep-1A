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
    [SerializeField] private float MaxWT;
    [SerializeField] private float walktime;
    
    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;

    public void DebugMessage(String msg)
    {
        Debug.Log(msg);
    }

    private void Start()
    {
        GameObject[] movePoints = GameObject.FindGameObjectsWithTag("MovePoints");
        moveSpots = new Transform[movePoints.Length];

       for(int i = 0; i < moveSpots.Length; ++i)
        {
            moveSpots[i] = movePoints[i].transform;
        }


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
        walktime -= 1 * Time.deltaTime;
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < distance || walktime <= 0)
        {

            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
                OnPathComplete?.Invoke();
            }
            walktime = MaxWT;
        }
    }
}
