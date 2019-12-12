using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//  CTRL + K + D (Cleans Code)
public class Enemy : MonoBehaviour
{

    // camelCasing - variables
    // PascalCasing - functions & class names
    public NavMeshAgent agent;
    public Transform target;

   void Start()
   {
      
   }


    // Update is called once per frame
    void Update ()
    {
       
        agent.SetDestination(target.position);
	}
}
