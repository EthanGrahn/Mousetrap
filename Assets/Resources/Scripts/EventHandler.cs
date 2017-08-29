using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour {

    public enum EventType
    {
        TEXT,
        IMAGE,
        CUTSCENE
    }
    public EventType eventType = EventType.TEXT;
    
    public string textToDisplay;
    public Image imageToDisplay;
    public Object sceneToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Unity on collision enter event to trigger custom event.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

    }

    /// <summary>
    /// Display text to player.
    /// </summary>
    private void DisplayText()
    {
        if (textToDisplay == string.Empty)
            return;
    }

    /// <summary>
    /// Display an image to the player.
    /// </summary>
    private void DisplayImage()
    {
        if (!imageToDisplay)
            return;
    }

    /// <summary>
    /// Load a scene that operates as a cutscene.
    /// </summary>
    private void LoadCutscene()
    {
        try
        {
            GameManager.Instance.SceneSwitch.ChangeLevel(sceneToLoad.name);
        } catch
        {
            Debug.LogWarning("Object with name '" + sceneToLoad.name + "' may not be a scene.");
        }
    }
}
