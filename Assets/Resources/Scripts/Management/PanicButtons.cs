using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicButtons : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R))
		{
			GameManager.Instance.SceneSwitch.ChangeLevel("Office Level");
		} 
		else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C))
		{
			GameManager.Instance.cpManager.ResetPlayer();
		} 
		else if (Input.GetKey(KeyCode.Escape))
		{
			GameManager.Instance.SceneSwitch.ChangeLevel("Menu");
		}
	}
}
