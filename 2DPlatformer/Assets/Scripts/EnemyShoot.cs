using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    [SerializeField] EnemyProjectileBehaviour ProjectilePrefab;
    [SerializeField] Transform LaunchOffset;
    [SerializeField] float cooldownTime;
    private float currentCooldownTime;
    private bool isOnCooldown;

    public void startCooldown()
    {
        currentCooldownTime = 0;
        isOnCooldown = true;
        animator.SetBool("Detected", true);
    }

    void Shoot()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation, this.transform);
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
            animator.SetBool("Detected", false);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckForCooldown();

        if (GetComponent<EnemyVisionCollider>().IsPlayerSeen() && !GetComponent<EnemyVisionCollider>().HasPlayerExitedVision() && !isOnCooldown)
        {
            isOnCooldown = true;
            Shoot();
            animator.SetBool("Detected", true);
        }
    }
}
