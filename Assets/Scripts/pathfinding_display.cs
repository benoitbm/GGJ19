using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfinding_display : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform dest;
    [SerializeField] private float timeBeforeUpdate = 1.0f;

    private LineRenderer lineRenderer;
    private NavMeshAgent agent;
    private float lastTimeSinceUpdate = 0;
    //private CapsuleCollider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(dest.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position;
        StartCoroutine(waitEndFrame());
    }

    void DrawPath(NavMeshPath path)
    {
        lineRenderer.SetPosition(0, transform.position);
        int nbCorners = path.corners.Length;

        if (nbCorners < 2) //if the path has 1 or no corners, there is no need
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, dest.position /*+ new Vector3(0, 92, 0)*/);
            return;
        }

        lineRenderer.positionCount = nbCorners;

        for (int i = 1; i < nbCorners; ++i)
            lineRenderer.SetPosition(i, path.corners[i] /*+ new Vector3(0, 92, 0)*/);
    }

    IEnumerator waitEndFrame()
    {
        yield return new WaitForSeconds(.5f);
        DrawPath(agent.path);
    }
}
