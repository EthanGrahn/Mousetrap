using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableManager : MonoBehaviour {

	[SerializeField]
	private float outlineStartDistance = 10;
	[SerializeField]
	[Range(0,1)]
	private float outlineFinalOpacity = 0.75f;

	private Renderer _renderer;
	private MaterialPropertyBlock _propertyBlock;
	private GameManager gameManager;
	private Color newColor;
	private float distance;
	private bool zero = true;

	// Use this for initialization
	void Awake () {
		_propertyBlock = new MaterialPropertyBlock();
		_renderer = GetComponent<Renderer>();
		gameManager = GameManager.Instance;

		_renderer.GetPropertyBlock(_propertyBlock);
		newColor = _renderer.material.GetColor("_OutlineColor");
		newColor.a = 0;
		_propertyBlock.SetColor("_OutlineColor", newColor);	
		_renderer.SetPropertyBlock(_propertyBlock);
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(gameManager.Player.transform.position, transform.position);
		if (distance <= outlineStartDistance)
		{
			_renderer.GetPropertyBlock(_propertyBlock);
			newColor = _renderer.material.GetColor("_OutlineColor");
			newColor.a = outlineFinalOpacity - (outlineFinalOpacity * distance / outlineStartDistance);
			_propertyBlock.SetColor("_OutlineColor", newColor);
			_renderer.SetPropertyBlock(_propertyBlock);
			zero = false;
		}
		else if (!zero)
		{
			_renderer.GetPropertyBlock(_propertyBlock);
			newColor = _renderer.material.GetColor("_OutlineColor");
			newColor.a = 0;
			_propertyBlock.SetColor("_OutlineColor", newColor);	
			_renderer.SetPropertyBlock(_propertyBlock);
			zero = true;
		}
	}
}
