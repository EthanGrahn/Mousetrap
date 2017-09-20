using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ButtonHover : MonoBehaviour {

    [SerializeField]
    private float extentionAmt = 80;
    [SerializeField]
    private float transitionSpeed = 0.5f;
    [SerializeField]
    private float transitionDelay = 0.2f;
    [SerializeField]
    private AnimationCurve transitionCurve;
    private RectTransform rTransform;
    private float initOffset;
    private float scaleTime = 0;

    private void Start()
    {
        rTransform = GetComponent<RectTransform>();
        transitionCurve.MoveKey(1, new Keyframe(transitionSpeed, 1));
        initOffset = rTransform.offsetMin.x;
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
        for (float i = scaleTime; i <= transitionSpeed; i += Time.deltaTime)
        {
            yield return null;
            ratio = transitionCurve.Evaluate(i) * extentionAmt;
            rTransform.offsetMin = new Vector2(initOffset - ratio, rTransform.offsetMin.y);
            scaleTime = i;
        }
        rTransform.offsetMin = new Vector2(initOffset - extentionAmt, rTransform.offsetMin.y);
    }

    /// <summary>
    /// Shrink the button that is no longer being hovered over.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shrink()
    {
        yield return new WaitForSecondsRealtime(transitionDelay);
        float ratio = 0;
        for (float i = scaleTime; i > 0; i -= Time.deltaTime)
        {
            yield return null;
            ratio = transitionCurve.Evaluate(i) * extentionAmt;
            rTransform.offsetMin = new Vector2(initOffset - ratio, rTransform.offsetMin.y);
            scaleTime = i;
        }
        rTransform.offsetMin = new Vector2(initOffset, rTransform.offsetMin.y);
    }
}
