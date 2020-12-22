//Tot ce cine de controlul playerului se afla aici

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public static bool IsInputEnabled = true;
    [SerializeField] GameObject camera;
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
  public int LastSwap = 1;
    private Vector3 lastPosition;
  [SerializeField] float LevelDistance = 39.08f;
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
    lastPosition = transform.position;
    animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x)); //schimba valoarea "Speed" din animatorul playerului cu velocity-ul sau (ABS pentru ca poate fi negativ)

    if(Input.GetKeyDown (KeyCode.UpArrow) && isTouchingGround && IsInputEnabled)
    {
       rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
    }
    if(Input.GetKeyDown (KeyCode.Space) && IsInputEnabled)  // pentru tras, space, restul in ProjectileBehaviour
        {
      Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
    }
    if (Input.GetKeyDown("1")){
        transform.position = new Vector3(transform.position.x + LevelDistance*(1-LastSwap), transform.position.y, transform.position.z);
        camera.GetComponent<CameraPostProcessingColor>().moveToDimension("1", lastPosition);
            LastSwap = 1;
    }
    if (Input.GetKeyDown("2"))
    {
        transform.position = new Vector3(transform.position.x + LevelDistance*(2-LastSwap), transform.position.y, transform.position.z);
        camera.GetComponent<CameraPostProcessingColor>().moveToDimension("2", lastPosition);
        LastSwap = 2;
    }
    if (Input.GetKeyDown("3"))
    {
        transform.position = new Vector3(transform.position.x + LevelDistance*(3-LastSwap), transform.position.y, transform.position.z);
        camera.GetComponent<CameraPostProcessingColor>().moveToDimension("3", lastPosition);
        LastSwap = 3;
    }
    if (Input.GetKeyDown("4"))
    {
        transform.position = new Vector3(transform.position.x + LevelDistance*(4-LastSwap), transform.position.y, transform.position.z);
        camera.GetComponent<CameraPostProcessingColor>().moveToDimension("4", lastPosition);
        LastSwap = 4;
    }
    if (Input.GetKeyDown("5"))
    {
        transform.position = new Vector3(transform.position.x + LevelDistance*(5-LastSwap), transform.position.y, transform.position.z);
        camera.GetComponent<CameraPostProcessingColor>().moveToDimension("5", lastPosition);
        LastSwap = 5;
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

