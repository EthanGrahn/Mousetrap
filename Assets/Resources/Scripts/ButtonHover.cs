using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ButtonHover : MonoBehaviour {

    public float transitionSpeed = 0.5f;
    [SerializeField]
    private AnimationCurve transitionCurve;
    private RectTransform rTransform;

    private void Start()
    {
        rTransform = GetComponent<RectTransform>();
        transitionCurve.MoveKey(1, new Keyframe(transitionSpeed, 1));
    }

    /// <summary>
    /// Call extend method when mouse hovers over button.
    /// </summary>
    public void MouseOver()
    {
        StopAllCoroutines();
        StartCoroutine("Extend");
    }

    /// <summary>
    /// Call the shrink method when the mouse leaves the button.
    /// </summary>
    public void MouseExit()
    {
        StopAllCoroutines();
        StartCoroutine("Shrink");
    }

    /// <summary>
    /// Expand the button that is being hovered over.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Extend()
    {
        float ratio = 0;
        for (float i = rTransform.localScale.x - 1; i <= transitionSpeed; i += Time.deltaTime)
        {
            yield return null;
            ratio = transitionCurve.Evaluate(i);
            rTransform.localScale = new Vector3(1 + (0.5f * ratio), 1f);
        }
        rTransform.localScale = new Vector3(1.5f, 1f);
    }

    /// <summary>
    /// Shrink the button that is no longer being hovered over.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shrink()
    {
        float scaleDiff = rTransform.localScale.x - 1;
        float ratio = 0;
        for (float i = scaleDiff; i > 0; i -= Time.deltaTime)
        {
            yield return null;
            ratio = transitionCurve.Evaluate(i);
            rTransform.localScale = new Vector3(1 + (0.5f * ratio), 1f);
        }
        rTransform.localScale = new Vector3(1f, 1f);
    }
}
