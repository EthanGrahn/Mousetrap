using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour {

    [SerializeField]
    private float extentionAmt = 80;
    [SerializeField]
    private float transitionSpeed = 0.5f;
    [SerializeField]
    private float transitionDelay = 0.2f;
    [SerializeField]
    private AnimationCurve transitionCurve;
    private Transform rTransform;
    private float initOffset;
    private float scaleTime = 0;

    private void Start()
    {
        rTransform = gameObject.transform;
        transitionCurve.MoveKey(1, new Keyframe(transitionSpeed, 1));
        initOffset = rTransform.position.x;
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
            rTransform.position = new Vector3(initOffset - ratio, rTransform.position.y);
            scaleTime = i;
        }
        rTransform.position = new Vector3(initOffset - extentionAmt, rTransform.position.y);
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
            rTransform.position = new Vector3(initOffset - ratio, rTransform.position.y);
            scaleTime = i;
        }
        rTransform.position = new Vector3(initOffset, rTransform.position.y);
    }
}
