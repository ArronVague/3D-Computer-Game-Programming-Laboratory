using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartOptions : MonoBehaviour
{
    public int sceneToStart = 1;
    public bool changeScenes;
    public bool changeMusicOnStart;
    public int musicToChangeTo = 0;

    [HideInInspector] public bool inMainMenu = true;
    [HideInInspector] public Animator animColorFade;
    [HideInInspector] public Animator animMenuAlpha;
    [HideInInspector] public AnimationClip fadeColorAnimationClip;
    [HideInInspector] public AnimationClip fadeAlphaAnimationClip;

    private PlayMusic playMusic;
    private float fastFadeIn = .01f;
    private ShowPanels showPanels;

    void Awake()
    {
        showPanels = GetComponent<ShowPanels>();
        playMusic = GetComponent<PlayMusic>();
    }

    public void StartButtonClicked()
    {
        if (changeMusicOnStart)
        {
            playMusic.FadeDown(fadeColorAnimationClip.length);
            Invoke("PlayNewMusic", fadeAlphaAnimationClip.length);
        }

        if (changeScenes)
        {
            Invoke("LoadDelayed", fadeColorAnimationClip.length * .5f);
            animColorFade.SetTrigger("fade");
        }
        else
        {
            StartGameInScene();
        }
    }

    public void LoadDelayed()
    {
        inMainMenu = false;
        showPanels.HideMenu();
        SceneManager.LoadScene(sceneToStart);
    }

    public void StartGameInScene()
    {
        inMainMenu = false;

        if (changeMusicOnStart)
        {
            Invoke("PlayNewMusic", fadeAlphaAnimationClip.length);
        }
        animMenuAlpha.SetTrigger("fade");
        Invoke("HideDelayed", fadeAlphaAnimationClip.length);
        Debug.Log("Game started in the same scene! Put your game starting stuff here.");
    }

    public void PlayNewMusic()
    {
        playMusic.FadeUp(fastFadeIn);
        playMusic.PlaySelectedMusic(musicToChangeTo);
    }

    public void HideDelayed()
    {
        showPanels.HideMenu();
    }
}
