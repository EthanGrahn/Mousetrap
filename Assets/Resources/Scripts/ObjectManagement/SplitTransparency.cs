using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitTransparency : MonoBehaviour {

    public float transitionSpeed = 1;

    private bool transparent = false;
    private Color newColor;
    private Renderer _renderer;

	// Use this for initialization
	void Awake () {
        _renderer = GetComponent<Renderer>();
        _renderer.sortingOrder = 5; // render ahead of the player sprite and most other objects
    }
	
	// Update is called once per frame
	void Update () {
        bool found = false;

        RaycastHit raycastHit;
        Ray ray = new Ray(Camera.main.transform.position, GameManager.Instance.Player.transform.position - Camera.main.transform.position);

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.gameObject.GetComponent<SplitTransparency>() != null 
                && raycastHit.collider.gameObject == this.gameObject)
            {
                if (!transparent)
                    StartCoroutine("FadeOut");
                transparent = true;
                found = true;
            }
        }

        if (!found && transparent)
        {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeIn");
        }
	}

    private IEnumerator FadeOut()
    {
        newColor = _renderer.material.color;
        while (newColor.a - Time.deltaTime / transitionSpeed > 0)
        {
            newColor.a -= Time.deltaTime / transitionSpeed;
            _renderer.material.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        
        newColor.a = 0;
        _renderer.material.color = newColor;
    }

    private IEnumerator FadeIn()
    {
        newColor = _renderer.material.color;
        while(newColor.a + Time.deltaTime / transitionSpeed < 1)
        {
            newColor.a += Time.deltaTime / transitionSpeed;
            _renderer.material.color = newColor;
            yield return new WaitForEndOfFrame();
        }

        newColor.a = 1;
        _renderer.material.color = newColor;
        transparent = false;
    }
}
