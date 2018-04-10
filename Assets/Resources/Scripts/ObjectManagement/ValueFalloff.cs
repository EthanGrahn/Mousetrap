using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueFalloff : MonoBehaviour {

	private float m_totalTime = 1;
	private float m_initValue = 0;
	private float m_finalValue = 0;

	[SerializeField]
	private AnimationCurve pattern;

	private bool active = false;
	private float currValue;

	[HideInInspector]
	public UnityFloatEvent valueChangeEvent;

	public void StartFalloff(float time, float initValue, float finalValue, bool performInFixedUpdate)
	{
		if (!active)
		{
			m_totalTime = time;
			m_initValue = initValue;
			currValue = m_initValue;
			m_finalValue = finalValue;
			StartCoroutine(BeginFalloff(performInFixedUpdate, (initValue<finalValue)));
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
		while(currValue > m_finalValue)
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
		currValue = m_finalValue;
		valueChangeEvent.Invoke(currValue);
		active = false;
	}
}
