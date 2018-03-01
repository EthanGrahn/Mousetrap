using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public SceneSwitch SceneSwitch;
    public GameObject Player;
    public CharacterMovement pMovement;
    public CpManager cpManager;


    private void Awake( ) {
        if ( Instance ) {
            DestroyImmediate( gameObject );
            return;
        }

        DontDestroyOnLoad( gameObject );
        Instance = this;

        pMovement = Player.GetComponent<CharacterMovement>();
    }

    private void OnLevelWasLoaded( int level ) {
        if ( level == 1 ) // Menu
        {
            Cursor.visible = true;
            // Set the scenes for each button
            GameObject.Find( "StartButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Level1" ); } );
            GameObject.Find( "OptionsButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Options" ); } );
            GameObject.Find( "CreditsButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Credits" ); } );
            GameObject.Find( "ExitButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ExitGame( ); } );
        }
        else if (level == 4)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
