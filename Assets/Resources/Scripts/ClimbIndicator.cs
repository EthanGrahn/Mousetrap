using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ClimbIndicator : MonoBehaviour {

    private class SpriteLocation
    {
        public SpriteLocation(Vector3 pos, bool flipped)
        {
            position = pos;
            isFlipped = flipped;
        }

        Vector3 position;
        bool isFlipped;
    }

    public GameObject initialSprite;

    private float hSpacing = 0;
    private float vSpacing = 0;

    private Vector3 spriteSize;
    private Vector3 right;
    private Vector3 up;
    private List<SpriteLocation> spriteLocs;

	// Use this for initialization
	void Start () {
        spriteSize = initialSprite.GetComponent<RectTransform>().sizeDelta / 2;
        spriteSize.z = 0.1f;
        right = initialSprite.transform.right;
        up = initialSprite.transform.up;

        BoxCollider[] cols = GetComponents<BoxCollider>();
        List<BoxCollider> c = new List<BoxCollider>();
        c.AddRange(cols);
        
        for (int i = 0; i < c.Count; ++i)
        {
            if (!c[i].isTrigger)
                c.Remove(c[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator InitPlacement()
    {
        bool flipped = false;
        spriteLocs.Add(new SpriteLocation(initialSprite.transform.position, flipped));

        Vector3 offsetR = (right * hSpacing) + (up * vSpacing);
        Vector3 offsetL = (-right * hSpacing) + (up * vSpacing);
        Vector3 curCheck = initialSprite.transform.position + offsetR;
        while (PlacementCheck(curCheck))
        {
            flipped = !flipped;
            spriteLocs.Add(new SpriteLocation(curCheck, flipped));
            yield return null;
        }

    }

    private bool PlacementCheck(Vector3 position)
    {
        Collider[] cols = Physics.OverlapBox(position, spriteSize);
        return true;
    }
}
