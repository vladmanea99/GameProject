
using System.IO;
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
    private float critValue;
    private void Start() 
    {
        Destroy (gameObject, lifetime);
        GameObject Player = GameObject.Find("Player");
        PlayerMovement playerScript = Player.GetComponent<PlayerMovement>();
        x = playerScript.cScale;
    }

    private void Update()
    {
        //gameObject.GetComponent<Rigidbody2D>().gravity = 0f;

        transform.position += transform.right * Time.deltaTime * Speed;

        //



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if(enemy)
        {
            critValue = Random.Range(0.0f, 1.0f);
            if (critValue >= 0.8f)
            {
                enemy.TakeHit(2);
            }    
            else
            {
                enemy.TakeHit(1);
            }    
            Destroy(gameObject);
        }
       Destroy(gameObject);
    }


}
