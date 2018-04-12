using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueFalloff : MonoBehaviour {

	private float m_totalTime = 1;
	private float m_initValue = 0;

	[SerializeField]
	private AnimationCurve pattern;

	private bool active = false;
	private float currValue;

	[HideInInspector]
	public UnityFloatEvent valueChangeEvent;

	public void StartFalloff(float time, float initValue, bool performInFixedUpdate)
	{
		if (!active)
		{
			m_totalTime = time;
			m_initValue = initValue;
			currValue = m_initValue;
			StartCoroutine(BeginFalloff(performInFixedUpdate, (initValue<0)));
		}
	}
	
	private IEnumerator BeginFalloff(bool fixedUpdate, bool negative)
	{
		active = true;
		if (negative) 
		{
			m_initValue = Mathf.Abs(m_initValue);
			currValue = m_initValue;
		}
		float time = Time.time;
		while(currValue > 0)
        {
			currValue = m_initValue * (pattern.Evaluate((Time.time - time)/m_totalTime));
			if (!negative)
				valueChangeEvent.Invoke(currValue);
			else
				valueChangeEvent.Invoke(-currValue);

            if (fixedUpdate)
                yield return new WaitForFixedUpdate();
            else
                yield return new WaitForEndOfFrame();
        }
		currValue = 0;
		valueChangeEvent.Invoke(currValue);
		active = false;
	}
}
