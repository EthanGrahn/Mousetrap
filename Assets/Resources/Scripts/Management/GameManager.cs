using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public SceneSwitch SceneSwitch;
    public CharacterMovement CharMovement;
    public CpManager cpManager;

<<<<<<< Updated upstream
    private void Start( ) {
=======
    private void Awake( ) {
>>>>>>> Stashed changes
        if ( Instance ) {
            DestroyImmediate( gameObject );
            return;
        }

        DontDestroyOnLoad( gameObject );
        Instance = this;
    }

    private void OnLevelWasLoaded( int level ) {
        if ( level == 1 ) // Menu
        {
            // Set the scenes for each button
<<<<<<< Updated upstream
            GameObject.Find( "StartButton" ).GetComponent<Button>().onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Level1" ); } );
            GameObject.Find( "OptionsButton" ).GetComponent<Button>().onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Options" ); } );
            GameObject.Find( "CreditsButton" ).GetComponent<Button>().onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Credits" ); } );
            GameObject.Find( "ExitButton" ).GetComponent<Button>().onClick.AddListener( delegate { SceneSwitch.ExitGame(); } );
=======
            GameObject.Find( "StartButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Level1" ); } );
            GameObject.Find( "OptionsButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Options" ); } );
            GameObject.Find( "CreditsButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ChangeLevel( "Credits" ); } );
            GameObject.Find( "ExitButton" ).GetComponent<Button>( ).onClick.AddListener( delegate { SceneSwitch.ExitGame( ); } );
>>>>>>> Stashed changes
        }
    }
}
