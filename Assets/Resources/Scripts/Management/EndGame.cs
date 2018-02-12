using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject objToWatch;
    public GameObject endGameCanvas;

    private bool started = false;

	// Use this for initialization
	void Start () {
        endGameCanvas.SetActive(false);
	}

    private void FixedUpdate()
    {
        if (objToWatch == null && !started)
        {
            started = true;
            endGameCanvas.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine("WaitForExit");
        }
    }

    IEnumerator WaitForExit()
    {
        bool complete = false;
        while (!complete)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                complete = true;

            yield return null;
        }

        Time.timeScale = 1;
        GameManager.Instance.SceneSwitch.ChangeLevel("Menu");
    }
}
