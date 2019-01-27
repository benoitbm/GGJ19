using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Audio_Wwise;
public class CarPatrol : MonoBehaviour
{
    public Transform[] waypoints; //List of waypoints for navigation
    public GameObject player;

    protected float distanceToWaypoint = 3.0f; //Distance at which agent validates arrival at waypoint
    protected int nextPointIndex = 0; //Waypoint destination

    private NavMeshAgent agent;
    private bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.height = 0f;
        agent.baseOffset = 0;
        AudioMaster.Instance.PlaySound("Car_Start", gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if(this.GetComponent<CarContact>().carHit != false)
        {
            Stop();
            stopped = true;
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[nextPointIndex].position) < distanceToWaypoint)
            {
                GetNextWaypoint(); //Call of movement test procedure
                if(stopped == true)
                {
                    AudioMaster.Instance.PlaySound("Car_Start", gameObject);
                    stopped = false;
                }
                
            }
            else
            {
                agent.SetDestination(waypoints[nextPointIndex].position); //Continue moving towards point
            }
        }
        
    }

    void GetNextWaypoint() //Movement test procedure
    {
        nextPointIndex++; //Increment waypoint count on validation

        if (nextPointIndex == waypoints.Length)
        {
            nextPointIndex = 0; //Restart patrol route
        }
    }

    private void Stop() //Stops
    {
        
        agent.SetDestination(this.transform.position); //prevent AI from moving towards next waypoint
        AudioMaster.Instance.PlaySound("Car_Stop", gameObject);
        stopped = false;
    }
}
