using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDFlagDropFinished : MonoBehaviour
{
    private UIScript ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindObjectOfType<UIScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        string otherColliderTag = otherCollider.gameObject.tag;

        // The level is complete when flag finishes its drop
        if (otherColliderTag == "FlagPoleFlag")
        {
            ui.LevelClear(0);
        }
    }
}
