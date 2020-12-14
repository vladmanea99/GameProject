using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float Speed = 20f;
    // Update is called once per frame
    //public float delay = 2.0; //Delay of 5 seconds.
    public float lifetime = 5.0f;
    public int x;
    private void Start() {
        Destroy (gameObject, lifetime);
        GameObject Player = GameObject.Find("Player");
        PlayerMovement playerScript = Player.GetComponent<PlayerMovement>();
        x = playerScript.cScale;
        Debug.Log(x);

    }

    private void Update()
    {

        //gameObject.GetComponent<Rigidbody2D>().gravity = 0f;
        if(x == 1)
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
        }
        if(x == -1)
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        
        //
        
       
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Se ciocneste de");
        //Debug.Log(collision.gameObject.name);

        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        //var player = collision.collider.GetComponent<PlayerBehaviour>();
       

        if(enemy)
        {
            enemy.TakeHit(1);
            
        }
       Destroy(gameObject);

    }


}
