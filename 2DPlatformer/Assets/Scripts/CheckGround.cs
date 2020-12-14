// scriptul pentru a verifica daca playerul este pe pamant + animatorul pentru jump

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    GameObject Player;
    int numberOfGrounds = 0; 
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject; // facem referinta la player
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision) // daca playerul e pe pamant, bool-ul "isTouchingGround" devine true, iar bool-ul "isJumping" din animator devine fals
    {
        numberOfGrounds += 1;
        Player.GetComponent<PlayerMovement>().isTouchingGround = true;
        Player.GetComponent<PlayerMovement>().animator.SetBool("isJumping", false);
    }
    private void OnCollisionExit2D(Collision2D collision) // invers...mi-e prea lene
    {
        numberOfGrounds += -1;
        if (numberOfGrounds == 0)
        {
            Player.GetComponent<PlayerMovement>().animator.SetBool("isJumping", true);
            Player.GetComponent<PlayerMovement>().isTouchingGround = false;
        }
    }
}