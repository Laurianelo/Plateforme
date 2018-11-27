using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class Enemy : MonoBehaviour {

    [SerializeField]
    private float updateRate = 2f;
    [SerializeField]
    private Path path;
    [SerializeField]
    private float speed;
    [SerializeField]
    private ForceMode2D fMode;
    [SerializeField]
    private float nextWaypointDistance;

    private Transform target;
    private Seeker seeker;
    private bool pathIsDone;
    private int currentWaypoint;
    private Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.Instance.playerInstanciate;

        if(target == null)
        {
            Debug.LogError("no target");
        }

        StartCoroutine(UpdatePath());
    }


    private IEnumerator UpdatePath()
    {
        if(target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathCompleted);
            yield return new WaitForSeconds(1f/ updateRate);
            StartCoroutine(UpdatePath());
        }
    }

    public void OnPathCompleted(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;

        }
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            if(GameManager.Instance.playerInstanciate != null)
            {
                target = GameManager.Instance.playerInstanciate;
                StartCoroutine(UpdatePath());
            }
            return;
        }

        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
          if(pathIsDone)
            {
                return;
            }
            pathIsDone = true;
            return;
        }
        pathIsDone = false;

        Vector3 dir = path.vectorPath[currentWaypoint] - transform.position;

        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float _distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if(_distance < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }



    }




}
