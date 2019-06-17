using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDChangeDirectionOnHit : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dir;
    public float maxSpeed = 5;

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
        float newx = transform.position.x + dir * maxSpeed * Time.fixedDeltaTime;
        float newy = transform.position.y +
            0.5f * 80f * Physics2D.gravity.y * Time.fixedDeltaTime * Time.fixedDeltaTime;
		rb.MovePosition(new Vector2(newx, newy));
    }

    // This function gets called everytime this object collides with another
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (collisionData.collider.gameObject.CompareTag("Ground"))
            return;
        dir = -dir;
    }
}
