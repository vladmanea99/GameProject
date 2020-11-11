using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ma impusc");
      
            Player.GetComponent<PlayerMovement>().isTouchingGround = true;
            
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Ma impusc de 2 ori");
       
            Player.GetComponent<PlayerMovement>().isTouchingGround = false;
            
        
    }
}
