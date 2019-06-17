using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDAnimateWin : MonoBehaviour
{
    public void AnimateWin()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Win", true);

        Rigidbody2D rbPlayer = GetComponent<Rigidbody2D>();
        rbPlayer.constraints |= RigidbodyConstraints2D.FreezeAll;
    }
}
