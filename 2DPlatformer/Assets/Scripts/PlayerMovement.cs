//Tot ce cine de controlul playerului se afla aici

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public static bool IsInputEnabled = true;
  public Transform Player;
  public Animator animator;
  public float crouchValue;
  private Vector2 crouchScale;
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
    Player = GameObject.FindWithTag("Player").transform;
    crouchScale = new Vector3(0f, crouchValue, 0f);
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


  void FixedUpdate() {

   if (IsInputEnabled) { Movement(); }
  }
  void Update () {

    animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x)); //schimba valoarea "Speed" din animatorul playerului cu velocity-ul sau (ABS pentru ca poate fi negativ)

    if(Input.GetKeyDown (KeyCode.UpArrow) && isTouchingGround && IsInputEnabled)
    {
       rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
    }
    if(Input.GetKeyDown (KeyCode.Space) && IsInputEnabled)  // pentru tras, space, restul in ProjectileBehaviour
        {
      Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
    }

    //pentru crouch
    if (Input.GetKeyDown (KeyCode.DownArrow) && isTouchingGround)
    {
 
        Player.GetComponent<BoxCollider2D>().size -= crouchScale;
        Player.GetComponent<BoxCollider2D>().offset -= crouchScale / 2;
        animator.SetBool("isCrouching", true);
        IsInputEnabled = false;
        rigidBody.velocity = new Vector2(0f, 0f);
    }

    if (Input.GetKeyUp (KeyCode.DownArrow) && IsInputEnabled == false)
    {
        Player.GetComponent<BoxCollider2D>().size += crouchScale;
        Player.GetComponent<BoxCollider2D>().offset += crouchScale / 2;
        animator.SetBool("isCrouching", false);
        IsInputEnabled = true;
    }

    }


}

