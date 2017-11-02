using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeek : MonoBehaviour {

    List<int> skipNum1 = new List<int>{ 65, 68, 69, 74, 75, 85, 87 };
    List<int> skipNum2 = new List<int>{ 79, 100, 101, 106, 107, 117, 119 };

    AudioSource aSource;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && Input.inputString.Length > 0)
        {
            Debug.Log(">" + ((int)Input.inputString.ToCharArray()[0]) + "<");
            int key = ((int)Input.inputString.ToCharArray()[0]);
            float result = 0;
            if (key >= 97 && key <= 122)
            {
                if (skipNum1.Contains(key))
                    return;
                result = ((float)key - 97) / 26 * 3;
            }
            else if (key >= 65 && key <= 90)
            {
                if (skipNum2.Contains(key))
                    return;
                result = ((float)key - 65) / 26 * 3;
            }
            else if (key >= 48 && key <= 57)
            {
                int tmp = (key - 48);

                switch(tmp)
                {
                    case 1:
                        result = 0.001f;
                        break;
                    case 2:
                        result = 0.3461539f;
                        break;
                    case 3:
                        result = 0.4615385f;
                        break;
                    case 4:
                        result = 1.038462f;
                        break;
                    case 5:
                        result = 1.153846f;
                        break;
                    case 6:
                        result = 2.076923f;
                        break;
                    case 7:
                        result = 2.538461f;
                        break;
                    default:
                        return;
                }
            }
            Debug.Log(result);
            aSource.pitch = result;
            aSource.Play();
        }
	}
}
