using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDChangeDirectionOnHit : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dir;
    public float maxSpeed = 10f;
    private float accel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = (Random.Range(0, 2) == 0) ? -1f : 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(Vector2.right * dir * accel * 1000f * Time.fixedDeltaTime);
        }
    }

    // This function gets called everytime this object collides with another
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (collisionData.collider.gameObject.CompareTag("Ground"))
            return;
        Debug.Log("enter!!!");
        dir = -dir;
    }
}
