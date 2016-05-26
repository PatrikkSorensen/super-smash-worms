using UnityEngine;
using Pathfinding;
using System.Collections; 

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnemyAI : MonoBehaviour {

    public Transform target;
    public float updateRate = 2.0f; 

    private Seeker m_Seeker;
    private Rigidbody2D m_Rigidbody;

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

        m_Seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath()); 
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

        yield return new WaitForSeconds(1.0f / updateRate);
        StartCoroutine(UpdatePath());
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        if (path.vectorPath.Count == 0)
            return; 

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End of path reached");

            pathIsEnded = true; 
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        m_Rigidbody.AddForce(dir, fMode);

        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]); 

        if (distance < thresholdDistance)
        {
            currentWaypoint++;
            return; 
        }

         
    }
}
