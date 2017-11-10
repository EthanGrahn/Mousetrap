using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Chewable : MonoBehaviour {

    public int minMashes = 8;
    public int maxMashes = 16;
    public AudioClip chewSound;

    int mashes;
    int mashCount = 0;
    AudioSource aSource;
    float timer = 0;

    // Use this for initialization
    void Start () {
        if (minMashes > maxMashes)
            minMashes = maxMashes;

        aSource = GetComponent<AudioSource>();
        aSource.clip = chewSound;
        mashes = Random.Range(minMashes, maxMashes);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                StartCoroutine("ChewSound");
                mashCount++;
            }

            if (mashCount >= mashes)
                Destroy(this.gameObject);
        }
    }

    IEnumerator ChewSound()
    {
        if (aSource.isPlaying)
        {
            timer = Time.time;
        }
        else
        {
            timer = Time.time;
            aSource.Play();

            while (Time.time - timer < 1)
            {
                yield return null;
            }

            aSource.Stop();
        }
    }
}
