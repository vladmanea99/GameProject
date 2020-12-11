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
  
    // Start is called before the first frame update
    void Start()
    {
        // Circle collider is used for the vision of the enemy
        circleCollider2D = GetComponent<CircleCollider2D>();
        Enemy = GameObject.FindWithTag("Enemy");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            // Need to find the number of the layer for Enemy and just say, search for every layer, other than it, thus the ~
            int layerMask = ~(1 << LayerMask.NameToLayer("Enemy"));
            Debug.Log("Player is in range");
            Vector3 direction;
            Vector3 startingRayPosition = transform.position + new Vector3(0, transform.localScale.y, 0);
            // For each ray we see if it hits the player directly or not
            for (int i = 0; i < numberOfRays; i++)
            {
                // The direction starts from the middle of the box of the enemy and towards different parts of the player collider
                direction = (collision.transform.position + (i + 1) * collision.transform.localScale / numberOfRays) - startingRayPosition;
                raycastHit2D = Physics2D.Raycast(startingRayPosition, direction.normalized, Mathf.Infinity, layerMask);
                if (raycastHit2D.collider && raycastHit2D.collider.tag == "Player")
                {
                    Debug.Log("I found the player");
                    Enemy.GetComponent<EnemyPatroll>().animator.SetBool("Detected", true);
                    break;
                }
            }
        }
        
    }   

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Player is out of range");
            Enemy.GetComponent<EnemyPatroll>().animator.SetBool("Detected", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
