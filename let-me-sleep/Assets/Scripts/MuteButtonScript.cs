using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {

    private Button audioButton;
    private bool soundMuted = false;
	// Use this for initialization
	void Start () {

        audioButton = GameObject.FindGameObjectWithTag("MuteButton").GetComponent<Button>();
        audioButton.onClick.AddListener(() => ToggleMuteSound());
    }
	

    void ToggleMuteSound()
    {
        soundMuted = !soundMuted;
        AudioListener.volume = soundMuted ? 0 : 1;
        Debug.Log("sound is muted: " + soundMuted);
    }
}
