using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Chewable : MonoBehaviour {

    public int minMashes = 8;
    public int maxMashes = 16;
    public AudioClip chewSound;
    public GameObject chewUI;

    int mashes;
    int mashCount = 0;
    AudioSource aSource;
    float timer = 0;
    private bool displayUI = false;

    // Use this for initialization
    void Start () {
        if (minMashes > maxMashes)
            minMashes = maxMashes;
        if (chewUI)
            chewUI.SetActive(false);

        aSource = GetComponent<AudioSource>();
        aSource.clip = chewSound;
        mashes = Random.Range(minMashes, maxMashes);
    }

    private void OnGUI()
    {
        if (displayUI)
        {
            chewUI.SetActive(true);
            chewUI.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayUI = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("j"))
            {
                StartCoroutine("ChewSound");
                mashCount++;
            }

            if (mashCount >= mashes)
                Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayUI = false;
            chewUI.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        displayUI = false;
        if (chewUI)
            chewUI.SetActive(false);
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
