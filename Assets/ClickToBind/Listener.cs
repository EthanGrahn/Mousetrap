using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {

	//Script used as a example of how to use keyBindingManager

	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	public GameObject box4;
	
	// Update is called once per frame
	void Update () {

		if(KeyBindingManager.GetKeyDown(keyType.up))
		{
			box1.SetActive(!box1.activeSelf);
		}

		if(KeyBindingManager.GetKeyDown(keyType.down))
		{
			box2.SetActive(!box2.activeSelf);
		}

		if(KeyBindingManager.GetKeyDown(keyType.left))
		{
			box3.SetActive(!box3.activeSelf);
		}
				
		if(KeyBindingManager.GetKeyDown(keyType.right))
		{
			box4.SetActive(!box4.activeSelf);
		}
	}
}
