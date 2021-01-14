using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public float lifetime = 5.0f;
    public float x;

    private void Start()
    {
        Destroy(gameObject, lifetime);
        GameObject Enemy = this.transform.parent.gameObject;
        this.transform.parent = null;
        EnemyPatroll enemyScript = Enemy.GetComponent<EnemyPatroll>();
        //Vector3 newScale = transform.localScale;
        transform.localScale = new Vector3(transform.localScale.x / 3, transform.localScale.y / 3, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(x.ToString() + " " + gameObject.GetInstanceID().ToString());
        if (x > 0)
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        if (x < 0)
        {
            transform.position += -transform.right * Time.deltaTime * Speed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerBehaviour>();
        //Debug.Log("Intra aici");
        if (player)
        {
            player.TakeHit(1);
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Bullet")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}