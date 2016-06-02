using UnityEngine;
using Pathfinding;
using System.Collections;
using System;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class AstarNavigator : MonoBehaviour {

    public Transform target;
    public float updateRate = 6.0f; 

    private Seeker m_Seeker;
    private Rigidbody2D m_Rigidbody;
    private bool m_isUpdating = false; 

    public Path path;

    public float speed = 300.0f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float thresholdDistance = 3.0f;

    private int currentWaypoint = 0; 

    void Start()
    {
        m_Seeker = GetComponent<Seeker>();
        m_Rigidbody = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.Log("No target assigned");
            return;
        }

        //m_Seeker.StartPath(transform.position, target.position, OnPathComplete);

        //StartCoroutine(UpdatePath()); 
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path. Errors: " + p.error);

        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    public IEnumerator UpdatePath ()
    {
        if (target == null)
            yield break;

        m_Seeker.StartPath(transform.position, target.position, OnPathComplete);

        Debug.Log("Updating path"); 
        yield return new WaitForSeconds(1.0f / updateRate);
        StartCoroutine(UpdatePath());
    }

    void FixedUpdate()
    {
        //if (target == null)
        //    return;

        //if (path == null)
        //    return; 

        //if(currentWaypoint >= path.vectorPath.Count)
        //{
        //    pathIsEnded = true;

        //    if (pathIsEnded)
        //        return;
        //}

        //pathIsEnded = false;

        //Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        //dir *= speed * Time.fixedDeltaTime;

        //m_Rigidbody.AddForce(dir, fMode);

        //float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]); 

        //if (distance < thresholdDistance)
        //{
        //    currentWaypoint++;
        //    return; 
        //}
    }

    public Vector3 getDestination(GameObject m_target)
    {
        target = m_target.transform;

        if (path == null)
        {
            Debug.Log("Path is null, returning vector.zero");
            return Vector3.zero;
        }

        if (currentWaypoint >= path.vectorPath.Count - 1)
        {
            Debug.Log("AT MY END OF THE PATH"); 
            return Vector3.zero;
        }

        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < thresholdDistance)
        {
            Debug.Log("Distance to next waypoint: " + distance + ", current waypoint: " + currentWaypoint);
            currentWaypoint++;
        }

        Debug.Log(currentWaypoint + ", " + path.vectorPath.Count); 
        Vector3 m_currentPathPosition = path.vectorPath[currentWaypoint];
        Vector3 dir = (m_currentPathPosition - transform.position).normalized;



        Debug.Log("Path length: " + path.vectorPath.Count);
        Debug.Log("Getting destination" + dir + "p.vecorPath" + m_currentPathPosition);

        return dir;
    }

    public void StartUpdatingPath()
    {
        if (!m_isUpdating)
        {
            StartCoroutine(UpdatePath());
            m_isUpdating = true; 
        } else
        {
            return; 
        }
    }

    public void StopUpdatingPath()
    {
        if (m_isUpdating)
        {
            StopCoroutine(UpdatePath());
            m_isUpdating = false;
        }
        else
        {
            return;
        }
    }
}
