using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableManager : MonoBehaviour {

	[SerializeField]
	private float outlineStartDistance = 10;
	[SerializeField]
	[Range(0,1)]
	private float outlineFinalOpacity = 0.75f;

	private Collider _collider;
	private Renderer _renderer;
	private MaterialPropertyBlock _propertyBlock;
	private GameManager gameManager;
	private Color newColor;
	private Vector3 closestPoint1, closestPoint2;
	private float distance;
	private bool zero = true;

	// Use this for initialization
	void Awake () {
		_collider = GetComponent<Collider>();
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
		if (_renderer.isVisible)
		{
            closestPoint1 = _collider.ClosestPointOnBounds(gameManager.Player.transform.position);
            closestPoint2 = gameManager.Player.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            distance = Vector3.Distance(closestPoint1, closestPoint2);
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
}
