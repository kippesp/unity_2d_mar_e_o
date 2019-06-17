using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDFlagPoleReached : MonoBehaviour
{
    private GameObject flagGameObject;
    private Animator flagAnimator;

    private UIScript ui;

    // Start is called before the first frame update
    void Start()
    {
        flagGameObject = GameObject.FindWithTag("FlagPoleFlag");
        flagAnimator = flagGameObject.GetComponent<Animator>();
        flagAnimator.enabled = false;
        ui = GameObject.FindObjectOfType<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        GameObject player = otherCollider.transform.root.gameObject;
        string playerTag = player.tag;

        if (playerTag == "Player")
        {
            var Script = player.GetComponent<KTWDAnimateWin>();
            Script.AnimateWin();

            flagAnimator.enabled = true;

            //Debug.Log("Flag pole reached");

            ui.StopMusic();

            AudioSource audioSource = GetComponentInParent<AudioSource>();
            audioSource.Play();

        }
    }
}
