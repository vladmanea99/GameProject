using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public float lifetime = 5.0f;
    public float x;
    private void Start() {
        Destroy (gameObject, lifetime);
        GameObject Enemy = GameObject.Find("Enemy");
        EnemyPatroll enemyScript = Enemy.GetComponent<EnemyPatroll>();
        x = enemyScript.getCScale();
        //Vector3 newScale = transform.localScale;
        Debug.Log(x);

    }

    // Update is called once per frame
    void Update()
    {
        if(x > 0)
        {
  
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        if(x < 0)
        {

            transform.position += -transform.right * Time.deltaTime * Speed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerBehaviour>();
        //Debug.Log("Intra aici");
        if(player)
        {
            player.TakeHit(1);
        }
        //Destroy(gameObject);
        Destroy(gameObject);

    }
}
