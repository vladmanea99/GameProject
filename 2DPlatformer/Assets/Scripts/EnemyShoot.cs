using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;
    void Shoot()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyVisionCollider>().IsPlayerSeen())
        {
            //Shoot();
        }
    }
}
