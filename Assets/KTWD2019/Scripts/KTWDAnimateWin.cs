using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDAnimateWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateWin()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Win", true);

        Rigidbody2D rbPlayer = GetComponent<Rigidbody2D>();
        rbPlayer.constraints |= RigidbodyConstraints2D.FreezeAll;
    }
}
