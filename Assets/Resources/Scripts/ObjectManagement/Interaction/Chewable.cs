using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Chewable : MonoBehaviour
{
    public int minMashes = 8;
    public int maxMashes = 16;
    public AudioClip chewSound;
    public GameObject chewUI;
    public Vector3 uiOffset = Vector3.zero;

    int mashes;
    int mashCount = 0;
    AudioSource aSource;
    float timer = 0;
    private bool displayUI = false;
    private bool inZone = false;

    // Use this for initialization
    void Start()
    {
        if (minMashes > maxMashes)
        {
            minMashes = maxMashes;
        }
        if (chewUI)
        {
            chewUI.SetActive(false);
        }

        aSource = GetComponent<AudioSource>();
        aSource.clip = chewSound;
        mashes = Random.Range(minMashes, maxMashes);
    }

    private void Update()
    {
        if (Input.GetKeyDown("j") && inZone)
        {
            StartCoroutine("ChewSound");
            mashCount++;

            if (mashCount >= mashes)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        if (displayUI)
        {
            chewUI.SetActive(true);
            chewUI.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1) + uiOffset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayUI = true;
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayUI = false;
            inZone = false;
            chewUI.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        displayUI = false;
        if (chewUI)
        {
            chewUI.SetActive(false);
        }
    }

    /// <summary>
    /// Play the chewing noise. Stops playing if key is not continuously pressed.
    /// </summary>
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
