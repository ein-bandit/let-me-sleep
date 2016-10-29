using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour {

    bool stopTime = false;
    float timeLasted = 0.0f;
    float remainingTime = 5.4f;
    float bonusTime = 3.0f;
    public Text uiText;
    public Text totalScore;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(!stopTime)
        {
            remainingTime -= Time.deltaTime;
            timeLasted += Time.deltaTime;
            uiText.text = remainingTime.ToString("#");
            if(remainingTime <= 0.0f)
            {
                Time.timeScale = 0f;
                print(timeLasted.ToString("#"));
            }
        }  
	}

    void addTime()
    {
        remainingTime += bonusTime;
    }
}
