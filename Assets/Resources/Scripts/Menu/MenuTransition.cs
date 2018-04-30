using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuTransition : MonoBehaviour
{
    private enum MenuState
    {
        P1,
        P2
    }

    [SerializeField]
    private string levelName;
    [SerializeField]
    private VideoPlayer introPlayer;
    [SerializeField]
    private VideoPlayer page1to2Player;
    [SerializeField]
    private VideoPlayer page2to1Player;
    [SerializeField]
    private VideoPlayer pageZoomPlayer;
    [SerializeField]
    private KeyCode enterLevelKey;
    [SerializeField]
    private KeyCode pageLeftKey;
    [SerializeField]
    private KeyCode pageRightKey;
    [SerializeField]
    private GameObject controlsGameObject;
    private MenuState menuState = MenuState.P1;
    private List<VideoPlayer> videoPlayers;

    private void Awake()
    {
        videoPlayers = new List<VideoPlayer> { introPlayer, page1to2Player, page2to1Player, pageZoomPlayer };

        foreach(VideoPlayer vp in videoPlayers)
        {
            vp.Prepare();
            if (vp != introPlayer)
                vp.targetCameraAlpha = 0;
        }

        StartCoroutine("WaitForControls");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(pageRightKey) || Input.GetKeyDown(KeyCode.Alpha1)) && !IsVideoPlaying())
        {
            if (menuState == MenuState.P2)
            {
                return;
            }
            else if (menuState == MenuState.P1)
            {
                StartCoroutine(PlayVideo(page1to2Player));
                menuState = MenuState.P2;
            }
        }

        if (Input.GetKeyDown(pageLeftKey) && !IsVideoPlaying())
        {
            if (menuState == MenuState.P1)
            {
                return;
            }
            else if (menuState == MenuState.P2)
            {
                StartCoroutine(PlayVideo(page2to1Player));
                menuState = MenuState.P1;
            }
        }

        if (Input.GetKeyDown(enterLevelKey) && !IsVideoPlaying() && menuState == MenuState.P2)
        {
            StartCoroutine(PlayVideo(pageZoomPlayer));
            StartCoroutine("BeginLevel");
        }
    }

    IEnumerator PlayVideo(VideoPlayer vPlayer)
    {
        vPlayer.targetCameraAlpha = 1;
        yield return new WaitWhile(() => !vPlayer.isPrepared);
        foreach(VideoPlayer vp in videoPlayers)
        {
            if (vp != vPlayer)
            {
                vp.targetCameraAlpha = 0;
                vp.frame = 0;
                vp.Prepare();
            }
        }
        vPlayer.Play();
        yield return new WaitWhile(() => vPlayer.isPlaying);
    }

    IEnumerator BeginLevel()
    {
        yield return new WaitWhile(() => !IsVideoPlaying());
        controlsGameObject.SetActive(false);
        yield return new WaitWhile(() => IsVideoPlaying());
        SceneManager.LoadScene(levelName);
    }

    IEnumerator WaitForControls()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitWhile(() => introPlayer.isPlaying);
        controlsGameObject.SetActive(true);
    }

    /// <summary>
    /// Are any of the VideoPlayers currently playing?
    /// </summary>
    /// <returns>True if any VideoPlayer is currently playing</returns>
    bool IsVideoPlaying()
    {
        return introPlayer.isPlaying || page1to2Player.isPlaying || page2to1Player.isPlaying || pageZoomPlayer.isPlaying;
    }
}
