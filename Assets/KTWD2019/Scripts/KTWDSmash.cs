using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDSmash : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D HeadCollider;
    private Animator animator;
    private AudioSource source;

    void Start()
    {
        HeadCollider = GetComponent<BoxCollider2D>();
        animator = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Killed", true);
        Destroy(transform.parent.gameObject, 0.5f);
        source.Play();
    }
}
