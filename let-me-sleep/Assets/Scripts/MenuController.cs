using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private Button audioButton;
    private Button highScoreButton;
    private Button startButton;
    private Button exitButton;
    private bool soundMuted = false;
    
    public Sprite spriteMuted;
    public Sprite spriteUnmuted;

    // Use this for initialization
    void Start()
    {
        changeMutedSprite();
               
        audioButton = GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Button>();
        highScoreButton = GameObject.FindGameObjectWithTag("Highscore").GetComponent<Button>();
        startButton = GameObject.FindGameObjectWithTag("Game").GetComponent<Button>();
        exitButton = GameObject.FindGameObjectWithTag("Exit").GetComponent<Button>();
        audioButton.onClick.AddListener(() => ToggleMuteSound());
        highScoreButton.onClick.AddListener(() => SceneManager.LoadScene("Highscore"));
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        exitButton.onClick.AddListener(() => Application.Quit());
        GameManager.startMusic();
    }
        

    void ToggleMuteSound()
    {
        Debug.Log("toggling music");
        soundMuted = !soundMuted;
        AudioListener.volume = soundMuted ? 0 : 1;
        changeMutedSprite();
    }

    void changeMutedSprite()
    {
        if (soundMuted)
        {
            GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Image>().sprite = spriteMuted;
        } else
        {
            GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Image>().sprite = spriteUnmuted;
        }
    }
}
