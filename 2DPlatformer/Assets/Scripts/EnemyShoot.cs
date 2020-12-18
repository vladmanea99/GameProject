using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EnemyProjectileBehaviour ProjectilePrefab;
    [SerializeField] Transform LaunchOffset;
    [SerializeField] float cooldownTime;
    private float currentCooldownTime;
    private bool isOnCooldown;
    void Shoot()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        currentCooldownTime = 0;
    }

    void CheckForCooldown() 
    {
        if (currentCooldownTime < cooldownTime)
        {
            currentCooldownTime += Time.deltaTime;
        }
        else
        {
            currentCooldownTime = 0;
            isOnCooldown = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckForCooldown();

        if (GetComponent<EnemyVisionCollider>().IsPlayerSeen() && !isOnCooldown)
        {
            isOnCooldown = true;
            Shoot();
        }
    }
}
