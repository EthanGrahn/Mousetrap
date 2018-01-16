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
    private List<SpriteLocation> spriteLocs = new List<SpriteLocation>();
    private List<BoxCollider> colsB = new List<BoxCollider>();

    // Use this for initialization
    void Start () {
        spriteSize = initialSprite.GetComponent<RectTransform>().sizeDelta / 2;
        spriteSize.z = 0.1f;
        right = initialSprite.transform.right;
        up = initialSprite.transform.up;

        BoxCollider[] cols = GetComponents<BoxCollider>();
        colsB.AddRange(cols);
        
        for (int i = 0; i < colsB.Count; ++i)
        {
            if (!colsB[i].isTrigger)
                colsB.Remove(colsB[i]);
        }

        StartCoroutine(InitPlacement());
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator InitPlacement()
    {
        bool flipped = false;
        spriteLocs.Add(new SpriteLocation(initialSprite.transform.position, flipped));

        Vector3 offsetR = (right * (spriteSize.x + hSpacing)) + (up * (spriteSize.y + vSpacing));
        Vector3 offsetL = (-right * (spriteSize.x + hSpacing)) + (up * (spriteSize.y + vSpacing));

        Vector3 curCheck = initialSprite.transform.position + offsetR;
        while (PlacementCheck(curCheck))
        {
            flipped = !flipped;
            spriteLocs.Add(new SpriteLocation(curCheck, flipped));
            Instantiate(initialSprite, curCheck, initialSprite.transform.rotation);

            if (flipped)
                curCheck += offsetL;
            else
                curCheck += offsetR;

            yield return null;
        }
        Debug.Log(spriteLocs.Count);

    }

    private bool PlacementCheck(Vector3 position)
    {
        Bounds bound = new Bounds(position, spriteSize);
        foreach (BoxCollider b in colsB)
        {
            if (b.bounds.Contains(bound.min) && b.bounds.Contains(bound.max))
            {
                Debug.Log("true");
                return true;
            }
        }

        return false;
    }
}
