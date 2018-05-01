using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public GameObject objToWatch;
    public GameObject endGameCanvas;

    private bool started = false;

    // Use this for initialization
    void Awake()
    {
        endGameCanvas.SetActive(false);
        SceneManager.sceneLoaded += OnSceneLoaded;
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


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
    }

    IEnumerator WaitForExit()
    {
        bool complete = false;
        while (!complete)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                complete = true;
            }

            yield return null;
        }

        Time.timeScale = 1;
        GameManager.Instance.SceneSwitch.ChangeLevel("Menu");
    }
}
