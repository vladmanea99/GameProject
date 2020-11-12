using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float Speed = 20f;
    // Update is called once per frame
    
    private void Update()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerMovement playerScript = Player.GetComponent<PlayerMovement>();
        int x = playerScript.cScale;
        Debug.Log(x);
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
        Destroy(gameObject);
    }
}
