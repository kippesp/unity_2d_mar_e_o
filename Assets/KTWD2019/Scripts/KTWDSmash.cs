using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDSmash : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D HeadCollider;
    private Animator animator;
    private AudioSource source;
    private Collider2D parentCollider;

    void Start()
    {
        HeadCollider = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
        parentCollider = GetComponentInParent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        parentCollider.enabled = false;
        animator.SetBool("Killed", true);
        Destroy(transform.parent.gameObject, 0.5f);
        source.Play();
    }
}
