using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionCollider : MonoBehaviour
{
    // Number of rays that should search to see if the enemy has clear sight of the player
    GameObject Enemy;
    [SerializeField] public uint numberOfRays;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rb2D;
    private RaycastHit2D raycastHit2D;
    private bool isPlayerSeen;
    private bool hasPlayerExitedVision;
    [SerializeField] float searchTime;
    private float currentSearchTime;

    public bool IsPlayerSeen()
    {
        return isPlayerSeen;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Circle collider is used for the vision of the enemy
        isPlayerSeen = false;
        hasPlayerExitedVision = false;
        circleCollider2D = GetComponent<CircleCollider2D>();
        Enemy = GameObject.FindWithTag("Enemy");
    }

    void FindTarget(Collider2D target)
    {
        // Need to find the number of the layer for Enemy and just say, search for every layer, other than it, thus the ~
        int layerMask = ~(1 << LayerMask.NameToLayer("Enemy"));
        Vector3 direction;
        Vector3 startingRayPosition = transform.position + new Vector3(0, transform.localScale.y, 0);
        // For each ray we see if it hits the player directly or not
        for (int i = 0; i < numberOfRays; i++)
        {
            // The direction starts from the middle of the box of the enemy and towards different parts of the player collider
            direction = (target.transform.position + (i + 1) * target.transform.localScale / numberOfRays) - startingRayPosition;
            raycastHit2D = Physics2D.Raycast(startingRayPosition, direction.normalized, Mathf.Infinity, layerMask);
            if (raycastHit2D.collider && raycastHit2D.collider.tag == "Player")
            {
                isPlayerSeen = true;
                Enemy.GetComponent<EnemyPatroll>().animator.SetBool("Detected", true);
                break;
            }
        }
    }

    void SearchTarget()
    {
        currentSearchTime += Time.deltaTime;
        if (currentSearchTime > searchTime)
        {
            isPlayerSeen = false;
        }
    }

    void FacePlayer(Collider2D collision)
    {       // if enemy is facing right and player is on left, enemy should turn
        if ((transform.localScale.x > 0 && (collision.transform.position - transform.position).x < 0) ||
            // if enemy is facing left and player is on right, enemy shoud turn
            (transform.localScale.x < 0 && (collision.transform.position - transform.position).x > 0))
        {
            GetComponent<EnemyPatroll>().Flip();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            FindTarget(collision);
            hasPlayerExitedVision = false;
            currentSearchTime = 0;
            FacePlayer(collision);
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && !isPlayerSeen)
        {
            FindTarget(collision);
            hasPlayerExitedVision = false;
            currentSearchTime = 0;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            FacePlayer(collision);
            currentSearchTime = 0;
            hasPlayerExitedVision = true;
            Enemy.GetComponent<EnemyPatroll>().animator.SetBool("Detected", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
if (isPlayerSeen && hasPlayerExitedVision && currentSearchTime < searchTime)
        {
            SearchTarget();
        }
    }
}
