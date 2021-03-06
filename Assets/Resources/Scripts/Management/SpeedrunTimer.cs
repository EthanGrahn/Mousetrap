﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeedrunTimer : MonoBehaviour
{
    [SerializeField]
    private KeyCode toggleKey;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text shadowText;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        timerText.gameObject.SetActive(false);
        shadowText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Unity event called when scene has been loaded.
    /// </summary>
    /// <param name="scene">Scene data</param>
    /// <param name="mode">The mode used to load the scene</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Office Level") // Office Level
        {
            startTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            timerText.gameObject.SetActive(!timerText.gameObject.activeSelf);
            shadowText.gameObject.SetActive(!shadowText.gameObject.activeSelf);
        }

        if (timerText.gameObject.activeSelf)
        {
            int intTime = (int)(Time.time - startTime);
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            float fraction = (Time.time - startTime) * 1000;
            fraction = (fraction % 1000);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
            shadowText.text = timerText.text;
        }
    }
}
