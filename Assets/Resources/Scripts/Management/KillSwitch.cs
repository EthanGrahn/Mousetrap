using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            GameManager.Instance.SceneSwitch.ChangeLevel("Menu");
        }
    }
}
