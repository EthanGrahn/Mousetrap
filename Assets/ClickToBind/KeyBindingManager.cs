using UnityEngine;
using System.Collections.Generic;

public class KeyBindingManager : MonoBehaviour {

	private static KeyBindingManager _singleton;
	public static KeyBindingManager singleton
	{
		get
		{
			if(_singleton == null)
			{
				_singleton = GameObject.FindObjectOfType<KeyBindingManager>();
			}

			return _singleton;
		}
	}

	public Dictionary<keyType,KeyCode> keyDict = new Dictionary<keyType, KeyCode>();

	void OnEnable()
	{		
		if(keyDict.Count != 0)
			return;

		KeyBinding[] tempArray;
		tempArray = GameObject.FindObjectsOfType<KeyBinding>();

		foreach(KeyBinding key in tempArray)
		{
			if(!keyDict.ContainsKey(key.keyName))
				keyDict.Add(key.keyName,key.thisKey);
		}
	}

	//Returns key code
	public static KeyCode GetKeyCode(keyType key)
	{
		KeyCode _keyCode = KeyCode.None;
		KeyBindingManager.singleton.keyDict.TryGetValue(key, out _keyCode);
		return _keyCode;
	}

	//Use in place of Input.GetKey
	public static bool GetKey(keyType key)
	{
		KeyCode _keyCode = KeyCode.None;
		KeyBindingManager.singleton.keyDict.TryGetValue(key, out _keyCode);
		return Input.GetKey(_keyCode);
	}

	//Use in place of Input.GetKeyDown
	public static bool GetKeyDown(keyType key)
	{
		KeyCode _keyCode = KeyCode.None;
		KeyBindingManager.singleton.keyDict.TryGetValue(key, out _keyCode);
		return Input.GetKeyDown(_keyCode);
	}

	//Use in place of Input.GetKeyUP
	public static bool GetKeyUp(keyType key)
	{
		KeyCode _keyCode = KeyCode.None;
		KeyBindingManager.singleton.keyDict.TryGetValue(key, out _keyCode);
		return Input.GetKeyUp(_keyCode);
	}

	public void UpdateDictionary(keyType key, KeyCode code)
	{
		keyDict[key] = code;
	}
}

//used to safe code inputs
//Add new keys to "bind" here
public enum keyType
{
	none,
	up,
	down,
	left,
	right,
	jump,
	interact
}
