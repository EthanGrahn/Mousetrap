using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitTransparency : MonoBehaviour {

    public float transitionSpeed = 1;

    private bool transparent = false;
    private Color newColor;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingOrder = 5; // render ahead of he player sprite and most other objects
        newColor = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        bool found = false;        
        RaycastHit[] hits;

        hits = Physics.RaycastAll(Camera.main.transform.position, 
                                  GameManager.Instance.Player.transform.position - Camera.main.transform.position, 
                                  (Camera.main.transform.position - GameManager.Instance.Player.transform.position).magnitude);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<SplitTransparency>() != null)
            {
                if (!transparent)
                    StartCoroutine("FadeOut");
                transparent = true;
                found = true;
                break;
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
        newColor = GetComponent<Renderer>().material.color;
        while (newColor.a - Time.deltaTime / transitionSpeed > 0)
        {
            newColor.a -= Time.deltaTime / transitionSpeed;
            GetComponent<Renderer>().material.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        
        newColor.a = 0;
        GetComponent<Renderer>().material.color = newColor;
    }

    private IEnumerator FadeIn()
    {
        newColor = GetComponent<Renderer>().material.color;
        while(newColor.a + Time.deltaTime / transitionSpeed < 1)
        {
            newColor.a += Time.deltaTime / transitionSpeed;
            GetComponent<Renderer>().material.color = newColor;
            yield return new WaitForEndOfFrame();
        }

        newColor.a = 1;
        GetComponent<Renderer>().material.color = newColor;
        transparent = false;
    }
}
