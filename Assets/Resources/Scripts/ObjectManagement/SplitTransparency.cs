using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitTransparency : MonoBehaviour {

    public float transitionSpeed = 1;
    [SerializeField]
    [Range(0,1)]
    private float endOpacity = 0.1f;

    private bool transparent = false;
    private Color newColor;
    private Renderer _renderer;
    private LayerMask layerMask = 1 << 15;

	// Use this for initialization
	void Awake () {
        _renderer = GetComponent<Renderer>();
        _renderer.sortingOrder = 5; // render ahead of the player sprite and most other objects
    }
	
	// Update is called once per frame
	void Update () {
        bool found = false;

        if (_renderer.isVisible)
        {
            RaycastHit[] raycastHit;
            Ray ray = new Ray(Camera.main.transform.position, GameManager.Instance.Player.transform.position - Camera.main.transform.position);
            raycastHit = Physics.RaycastAll(ray, Vector3.Distance(Camera.main.transform.position, GameManager.Instance.Player.transform.position), layerMask);
            foreach(RaycastHit r in raycastHit)
            {
                if (r.collider.gameObject == this.gameObject)
                {
                    if (!transparent)
                        StartCoroutine("FadeOut");
                    transparent = true;
                    found = true;
                }
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
        while (newColor.a - Time.deltaTime / transitionSpeed > endOpacity)
        {
            newColor.a -= Time.deltaTime / transitionSpeed;
            _renderer.material.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        
        newColor.a = endOpacity;
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
