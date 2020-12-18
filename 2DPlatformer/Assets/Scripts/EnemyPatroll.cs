using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float cScale = 1;
    [SerializeField] public List<Vector3> points;
    [SerializeField] public float speed;
    [SerializeField] public float waitTime;
    public bool hasToWait = false;
    public float currentWaitedTime;
    Rigidbody2D rb2D;
    Vector3 destinationPoint;
    // Start is called before the first frame update

    // When neccesary I just flip the entire game object on the OX axis to go left or right on the map
    public float getCScale()
    {
        return cScale;
    }
    public void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        cScale = newScale.x;
        transform.localScale = newScale;
    }

    // Entity has to wait a certain amount of time until it can move
    void Wait()
    {
        currentWaitedTime += Time.deltaTime;

        if (currentWaitedTime > waitTime)
        {
            hasToWait = false;
        }
    }

    // Give the object a destination to go to (usually it should be on same OY axis, just x to differ
    void WalkTo(Vector3 destination)
    {

        Vector3 direction = destination - transform.position;
        if (Mathf.Sign(direction.normalized.x) != Mathf.Sign(transform.localScale.x))
        {
            Flip();
        }
        rb2D.velocity = (direction.normalized * Time.deltaTime * speed);
    }

    // Find the next waypoint the List of waypoints 
    Vector2 FindNextWaypoint(Vector3 currentDestination)
    {
        int indice = points.IndexOf(currentDestination);
        if (indice == points.Count - 1)
        {
            return points[0];
        }
        else
        {
            return points[indice + 1];
        }
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (points.Count > 1)
        {
            destinationPoint = points[0];
        }    
    }

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        if (hasToWait)
        {

            Wait();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasToWait && !GetComponent<EnemyVisionCollider>().IsPlayerSeen())
        {
            // If it's not close enough to the place it has to go, just make it walk for more time
            if (Vector3.Distance(transform.position, destinationPoint) > 0.1)
            {
                WalkTo(destinationPoint);
            }
            // If it reached that place, it must wait a few seconds and then go to the next waypoint
            else
            {
                hasToWait = true;
                currentWaitedTime = 0;
                rb2D.velocity = Vector2.zero;
                destinationPoint = FindNextWaypoint(destinationPoint);

            }
        }
        
    }
}
