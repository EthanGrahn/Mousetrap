using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SpiderVignette : MonoBehaviour {

	[SerializeField]
	PostProcessingProfile profile;
	[SerializeField]
	float startDistance = 10;
	[SerializeField]
	[Range(0,1)]
	float endIntensity = 0.67f;

	private GameObject spider;
	private GameObject[] spiders;
	private float lDistance = float.MaxValue;

	// Use this for initialization
	void Start () {
		VignetteModel.Settings vignSettings = profile.vignette.settings;
        vignSettings.intensity = 0;
        profile.vignette.settings = vignSettings;

		spiders = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	// Update is called once per frame
	void Update () {
		lDistance = float.MaxValue;
		foreach (GameObject s in spiders)
		{
			if (!s)
				continue;
			if (Vector3.Distance(transform.position, s.transform.position) < lDistance)
			{
				lDistance = Vector3.Distance(transform.position, s.transform.position);
				spider = s;
			}
		}

		if (spider && Vector3.Distance(transform.position, spider.transform.position) <= startDistance)
		{
			float normalized = 1 - Vector3.Distance(transform.position, spider.transform.position) / startDistance;
			VignetteModel.Settings vignSettings = profile.vignette.settings;
			vignSettings.intensity = normalized * endIntensity;
			profile.vignette.settings = vignSettings;
		}
		else
		{
            VignetteModel.Settings vignSettings = profile.vignette.settings;
            vignSettings.intensity = 0;
            profile.vignette.settings = vignSettings;
		}
	}
}
