using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int loadScene;
    public int nextlvl;

    private void OnCollisionEnter2D(Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerBehaviour>();
        if(player){
            SceneManager.LoadScene(loadScene);
            PlayerPrefs.SetInt("level", nextlvl);
        }
    }
}
