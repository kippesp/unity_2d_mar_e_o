using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class KTWDCollectableAttribute : MonoBehaviour
{
    public int pointsWorth = 1;
    
    private UIScript userInterface;
    private AudioSource audiosource;
    private SpriteRenderer srenderer;
    private Collider2D collider;

    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        userInterface = GameObject.FindObjectOfType<UIScript>();

        audiosource = GetComponent<AudioSource>();
        srenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }


    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, true);
    }


    // This function gets called everytime this object collides with another
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string playerTag = otherCollider.transform.root.gameObject.tag;

        // is the other object a player?
        if(playerTag == "Player")
        {
            if(userInterface != null)
            {
                // add one point
                int playerId = (playerTag == "Player") ? 0 : 1;
                userInterface.AddPoints(playerId, pointsWorth);
            }

            if (audiosource != null)
            {
                audiosource.Play();
            }

            // Disable collider and rendering while the sound finishes playing
            srenderer.enabled = false;
            collider.enabled = false;

            // Schedule this object to be destroyed
            Destroy(gameObject, 1f);
        }
    }
}
