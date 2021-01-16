using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthbarBehaviour Healthbar;
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Hitpoints = 0;
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void TakeHit(float damage)
    { 
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        if(Hitpoints <= 0){
            
        }
    }
}
