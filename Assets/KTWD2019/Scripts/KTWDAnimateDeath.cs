using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDAnimateDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AnimateDeath()
    {
        // 1. Turn off colliders
        var colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        // 2. apply an impulse upward and then Mario will drop
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        rb.AddForce(Vector2.up * 100f, ForceMode2D.Impulse);
    }
}
