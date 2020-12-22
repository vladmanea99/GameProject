using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime; //how much time the player has to hold down the downarrow key for it to go through a platform
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();  //effector take the PlatformEffector2D property
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.2f;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;//change the collider from above the platform to below, so the player can go though it
                waitTime = 0.2f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;//changes the collider back to above the platform
        }
    }
}
