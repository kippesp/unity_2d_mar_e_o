using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KTWDKillPlayer : MonoBehaviour
{
	public bool destroyWhenActivated = false;
	private int healthChange = -1;

    public AudioClip MainTheme;
    public AudioClip MarioDeathTheme;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MainTheme;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		OnTriggerEnter2D(collisionData.collider);
	}
	private void OnTriggerEnter2D(Collider2D colliderData)
	{

        GameObject playerGameObject = GameObject.FindWithTag("Player");

        // trigger end game theme
        audioSource.clip = MarioDeathTheme;
        audioSource.Play();

        // This is a modification from the original script which obtained the
        // HealthSystemAttribute from the colliding object.  Since our game
        // has three colliders (head, body, feet), this won't work.  We require
        // the "player" to have the HealthSystemAttribute.

		HealthSystemAttribute healthScript = playerGameObject.GetComponent<HealthSystemAttribute>();
		//HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();

		if(healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);

			if(destroyWhenActivated)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
