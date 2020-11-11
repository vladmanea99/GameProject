

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 5f;
  public float jumpSpeed = 8f;
  private float movement = 0f;
  private Rigidbody2D rigidBody;
  public bool isTouchingGround;
  public int cScale = 1;
  public ProjectileBehavior ProjectilePrefab;
  public Transform LaunchOffset;
  void Start () {
    rigidBody = GetComponent<Rigidbody2D> ();
  }
  private void Movement(){
    movement = Input.GetAxis ("Horizontal");
    Vector3 characterScale = transform.localScale;
    if (movement > 0f) {
      rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      characterScale.x = -1;
      cScale = -1;
    }
    else if (movement < 0f) {
      rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      characterScale.x = 1;
      cScale = 1;
    } 
    else {
      rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
    }
    transform.localScale = characterScale;
  }
  private void FixedUpdate() {
    Movement();
  }
  void Update () {

    // 
    

    if(Input.GetKeyDown (KeyCode.UpArrow) && isTouchingGround){
      rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
      
    }
    if(Input.GetKeyDown (KeyCode.Space)){
      Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
    }

  }

    
}
