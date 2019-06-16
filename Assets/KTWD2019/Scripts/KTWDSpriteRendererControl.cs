using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTWDSpriteRendererControl : MonoBehaviour
{
    private SpriteRenderer srenderer;

    // Start is called before the first frame update
    void Start()
    {
        srenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetEnabled()
    {
        srenderer.enabled = true;
    }
    public void SetDisabled()
    {
        srenderer.enabled = false;
    }
}
