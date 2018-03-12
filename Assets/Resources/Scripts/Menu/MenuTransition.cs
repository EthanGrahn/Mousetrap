using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour {

	[SerializeField] private string levelName;
	[SerializeField] private KeyCode levelSelectKey;
	private bool transitioning = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(levelSelectKey) && !transitioning)
		{
			transitioning = true;
			GameObject.Find("Canvas").GetComponent<Animator>().SetBool("Zoom", true);
			StartCoroutine("Transition");
		}
	}

	IEnumerator Transition()
	{
		yield return new WaitForSeconds(GameObject.Find("Canvas").GetComponent<Animation>().clip.length);
		SceneManager.LoadScene(levelName);
	}
}
