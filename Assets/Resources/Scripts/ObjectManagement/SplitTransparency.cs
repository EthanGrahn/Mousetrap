using System.Collections;
using UnityEngine;

public class SplitTransparency : MonoBehaviour
{
    public float transitionSpeed = 1;
    [SerializeField]
    [Range(0, 1)]
    private float endOpacity = 0.1f;
    
    private Color newColor;
    private Renderer _renderer;

    // Use this for initialization
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.sortingOrder = 5; // render ahead of the player sprite and most other objects
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeOut");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeIn");
        }
    }

    /// <summary>
    /// Make the object's material become less opaque
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Make the object's material become opaque
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeIn()
    {
        newColor = _renderer.material.color;

        while (newColor.a + Time.deltaTime / transitionSpeed < 1)
        {
            newColor.a += Time.deltaTime / transitionSpeed;
            _renderer.material.color = newColor;
            yield return new WaitForEndOfFrame();
        }

        newColor.a = 1;
        _renderer.material.color = newColor;
    }
}
