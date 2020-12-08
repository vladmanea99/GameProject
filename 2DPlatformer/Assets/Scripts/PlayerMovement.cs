//Tot ce cine de controlul playerului se afla aici

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Animator animator;
  public float speed = 5f;
  public float jumpSpeed = 8f;
  private float movement = 0f;
  private Rigidbody2D rigidBody;
  public bool isTouchingGround;// checker pentru daca atinge pamantul
  public int cScale = 1; //valoare care tine minte in ce directie se uita playerul
  public ProjectileBehavior ProjectilePrefab;
  public Transform LaunchOffset;
  void Start () {
    rigidBody = GetComponent<Rigidbody2D> ();
  }
  private void Movement(){
    movement = Input.GetAxis ("Horizontal");
    Vector3 characterScale = transform.localScale;
    if (movement > 0f) { // daca se misca la dreapta(a.k.a. inspre x pozitiv)
      rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      if (cScale == 1) // flip la player daca se uita inspre x negativ
      {
        characterScale.x = characterScale.x * -1;
        cScale = -1;
      }
       
    }
    else if (movement < 0f) { // daca se misca la stanga( x negativ)
      rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
      if (cScale == -1) // flip la player daca se uita inspre x pozitiv
            {
        characterScale.x = characterScale.x * -1;
        cScale = 1;
       }
      
    } 
    else { //daca se opreste
      rigidBody.velocity = new Vector2 (0,rigidBody.velocity.y);
    }
    transform.localScale = characterScale;
  }
  private void FixedUpdate() {
    Movement();
  }
  void Update () {

    animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x)); //schimba valoarea "Speed" din animatorul playerului cu velocity-ul sau (ABS pentru ca poate fi negativ)

    if(Input.GetKeyDown (KeyCode.UpArrow) && isTouchingGround){ // daca sare(si verifica daca e pe ground) , uparrow.
      rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
      
    }
    if(Input.GetKeyDown (KeyCode.Space)){ // pentru tras, space, restul in ProjectileBehaviour 
      Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
    }

    //pentru crouch, deocamdata downarrow si doar face animatia schimband valoarea "isCrouching" din animator cu true sau false
    if (Input.GetKeyDown (KeyCode.DownArrow))
    {
       animator.SetBool("isCrouching", true); 
    }

    if (Input.GetKeyUp (KeyCode.DownArrow))
    {
       animator.SetBool("isCrouching", false);
    }

    }


}
