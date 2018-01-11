using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitTransparency : MonoBehaviour {

    public float transitionSpeed = 1;

    private bool transparent = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        bool found = false;        
        RaycastHit[] hits;

        hits = Physics.RaycastAll(Camera.main.transform.position, GameManager.Instance.CharMovement.transform.position - Camera.main.transform.position, (Camera.main.transform.position - GameManager.Instance.CharMovement.transform.position).magnitude);

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
        Color newColor = GetComponent<Renderer>().material.color;
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
        Color newColor = GetComponent<Renderer>().material.color;
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
