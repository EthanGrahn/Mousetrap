using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Collider ) )]
public class EventHandler : MonoBehaviour {

    public enum EventType {
        TEXT,
        IMAGE,
        CUTSCENE
    }
    public EventType eventType = EventType.TEXT;

    public string textToDisplay;
    public Sprite imageToDisplay;
    public Object sceneToLoad;

    /// <summary>
    /// Unity on collision enter event to trigger custom event.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter( Collision collision ) {
        switch ( eventType ) {
            case EventType.TEXT:
                DisplayText();
                break;
            case EventType.IMAGE:
                DisplayImage();
                break;
            case EventType.CUTSCENE:
                LoadCutscene();
                break;
            default:
                Debug.LogError( "Event type not registering" );
                break;
        }
    }

    /// <summary>
    /// Display text to player.
    /// </summary>
    private void DisplayText( ) {
        if ( textToDisplay == string.Empty )
            return;

        // Displaying options to be decided
    }

    /// <summary>
    /// Display an image to the player.
    /// </summary>
    private void DisplayImage( ) {
        if ( !imageToDisplay )
            return;

        // Displaying options to be decided
    }

    /// <summary>
    /// Load a scene that operates as a cutscene.
    /// </summary>
    private void LoadCutscene( ) {
        try {
            GameManager.Instance.SceneSwitch.ChangeLevel( sceneToLoad.name );
            // scene requires a timer of sorts to return back to level at it's current state
        } catch {
            if ( sceneToLoad != null )
                Debug.LogError( "Object with name '" + sceneToLoad.name + "' may not be a scene." );
            else
                Debug.LogError( "Scene object is null." );
        }
    }
}
