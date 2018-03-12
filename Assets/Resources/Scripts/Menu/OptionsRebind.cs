using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
    CURRENTLY UNUSABLE
 */

public class OptionsRebind : MonoBehaviour {

    private bool keyNeeded = false;
    private string inputString = string.Empty;
    //private InputCode keyCode;

    private void OnGUI( ) {
        if ( keyNeeded ) {
            if ( Event.current.keyCode != KeyCode.None && inputString == string.Empty ) {
                inputString = Event.current.keyCode.ToString();
                //keyCode = (InputCode)(int)Event.current.keyCode;
                keyNeeded = false;
                Debug.Log( Event.current.keyCode );
            }
        }
    }

    public void InputFieldSelect( InputField iField ) {
        inputString = string.Empty;
        keyNeeded = true;
        StartCoroutine( "WaitForInput", iField );
    }

    public void InputFieldDeselect( ) {
        StartCoroutine( "Deselect" );
    }

    IEnumerator Deselect( ) {
        // lets WaitForInput finish its last steps
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        StopAllCoroutines();
    }

    IEnumerator WaitForInput( InputField iField ) {
        yield return new WaitWhile( ( ) => { return inputString == string.Empty; } );
        yield return new WaitForEndOfFrame();
        //Rebind.BindKeyToAction( iField.transform.GetChild( 3 ).name, keyCode, 0 );
        iField.DeactivateInputField();
        iField.interactable = false;
        //iField.text = keyCode.ToString().ToUpper();
        yield return null;
        iField.interactable = true;
    }
}
