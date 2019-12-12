using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoints : MonoBehaviour
{
    public enum State
    {
        Patrol = 0,
        Seek =1
    }

    public NavMeshAgent agent;

    public State currentState = State.Patrol;
    public Transform target;

    public Transform waypointParent;
    public float movespeed;
    public float stoppingDistance = 1f;

    // Creates a collection of transforms
    private Transform[] waypoints;
    private int currentIndex = 1;
    public float seekRadius = 5f;

    public float distanceToNode;
    public float distanceToPlayer;

    // CTRL + M + O (Fold Code)
    // CTRL + M + P (Unfold Code)

    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < .5f)
        {
            // currentIndex = currentIndex +1
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }

        //agent.SetDestination(point.position);
        //transform.position = Vector3.MoveTowards(transform.position, point.position, 0.1f);

        if (distanceToPlayer < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.1f);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    // Use this for initialization

    void Start ()
    {
        //Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame


    void Update()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distance < .5f)
        {
            // currentIndex = currentIndex +1
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, point.position, 0.1f);

        agent.SetDestination(point.position);

        // Switch current state
        switch (currentState)
        {
            case State.Patrol:
                // Patrol state
                Patrol();
                break;
            case State.Seek:
                // Seek state
                Seek();
                break;
            default:
                break;
        }

         // Switch current state
         // If we are in patrol
         // Call Patrol()
         // If we are in Seek
         // Call Seek()  
    }
}
