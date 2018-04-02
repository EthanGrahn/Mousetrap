using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ( scene.name == "Menu" ) // Menu
        {
            Cursor.visible = false;
        }
        else if ( scene.name == "Office Level" ) // Office Level
        {
            Cursor.visible = false;
            Player = GameObject.FindGameObjectWithTag("Player");
            pMovement = Player.GetComponent<CharacterMovement>();
            cpManager.player = Player;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
