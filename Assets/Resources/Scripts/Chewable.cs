using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chewable : MonoBehaviour {

    public int minMashes = 8;
    public int maxMashes = 16;

    int mashes;
    int mashCount = 0;

    // Use this for initialization
    void Start () {
        if (minMashes > maxMashes)
            minMashes = maxMashes;

        mashes = Random.Range(minMashes, maxMashes);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Rebind.GetInputDown("Interact"))
            mashCount++;

        if (mashCount >= mashes)
            Destroy(this.gameObject);
    }
}
