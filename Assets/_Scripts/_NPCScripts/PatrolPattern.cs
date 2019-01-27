using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPattern : MonoBehaviour
{
    public Transform[] waypoints; //List of waypoints for navigation
    public Rigidbody aRigidbody;
    public Transform target;

    protected float distanceToWaypoint = 1.5f; //Distance at which agent validates arrival at waypoint
    protected int nextPointIndex = 0; //Waypoint destination
    protected bool reversePatrol = false;

    private NavMeshAgent agent;
    private Vector3 targetPostition; //Used to turn NPC towards player position only on Y axis



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Reaction>().contact != true) //Until contact, move on patrol path
        {
            if (Vector3.Distance(transform.position, waypoints[nextPointIndex].position) < distanceToWaypoint)
            {
                GetNextWaypoint(); //Call of movement test procedure
            }
            else
            {
                agent.SetDestination(waypoints[nextPointIndex].position); //Continue moving towards point
            }
        }
        else
        {
            Stop();
            LookAtPlayer();
        }
            
        
        
    }

    void GetNextWaypoint() //Movement test procedure
    {
        if(this.gameObject.tag == "NPCS")
        {
            if (reversePatrol == false)
            {
                nextPointIndex++; //Incrementation of waypoint index

                if (nextPointIndex == waypoints.Length) //Check if agent arrived at end of path
                {
                    reversePatrol = true;
                    //nextPointIndex = 0;
                    nextPointIndex = waypoints.Length - 1;
                }
            }
            else
            {
                nextPointIndex--;

                if (nextPointIndex == 0)
                {
                    reversePatrol = false; //Go back on patrol path
                    nextPointIndex = 0;
                }
            }
            //nextPointIndex++; //Incrementation of waypoint index
        }
        else
        {
            int rand = Random.Range(0, waypoints.Length);
            nextPointIndex = rand;
        }



    }

    private void Stop() //Stops
    {
        aRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        agent.SetDestination(this.transform.position); //prevent AI from moving towards next waypoint
    }

    private void LookAtPlayer() //Rotates towards player
    {
        //transform.LookAt(target);
        targetPostition = new Vector3(target.position.x,
                                       this.transform.position.y,
                                       target.position.z);
        this.transform.LookAt(targetPostition); //Look at Player current position
    }
}
