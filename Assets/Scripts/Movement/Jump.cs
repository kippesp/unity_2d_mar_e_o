using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Jump")]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{
    [Header("Jump setup")]
    // the key used to activate the push
    public KeyCode key = KeyCode.Space;
   private AudioSource source;
   // strength of the push 
    public float jumpStrength = 10f;

    [Header("Ground setup")]
    //if the object collides with another object tagged as this, it can jump again
    public string groundTag = "Ground";
    private string obstaclesTag = "Obstacles";

    //this determines if the script has to check for when the player touches the ground to enable him to jump again
    //if not, the player can jump even while in the air
    public bool checkGround = true;

    private bool canJump = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }

    // Read the input from the player
    void Update()
    {
        if (canJump
            && Input.GetKeyDown(key))
        {
            // Apply an instantaneous upwards force
            rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            canJump = !checkGround;
            source.Play();
        }
        
        animator.SetBool("Jumping", !canJump);
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        string tag = collisionData.gameObject.tag;
        if (checkGround && (tag == groundTag || tag == obstaclesTag))
        {
            canJump = true;
        }
    }
}