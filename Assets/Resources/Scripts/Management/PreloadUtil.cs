using System.Collections;
using UnityEngine;

public class PreloadUtil : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("WaitBeforeLoad");
    }

    IEnumerator WaitBeforeLoad()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.SceneSwitch.ChangeLevel("Menu");
        Destroy(this);
    }
}
