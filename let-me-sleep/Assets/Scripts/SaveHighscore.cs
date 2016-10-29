using UnityEngine;
using System.Collections;

public class SaveHighscore : MonoBehaviour {

    private const string playerPrefsKey = "LetMeSleepHighScores";
    private string[] currentHighScores;

    // Use this for initialization
    void Start () {
        currentHighScores = PlayerPrefsX.GetStringArray(playerPrefsKey);
        if (currentHighScores.Length == 0)
        {
            currentHighScores = new string[1];
        }

        Debug.Log("currentHighscoreLength " + currentHighScores.Length);
    }
	
	public void saveHighScore(string name, int score)
    {
        Debug.Log("trying to save highscore");
        var newHighscoreIndex = 0;
        var loop = 10;
        if (currentHighScores.Length <= 10)
        {
            loop = currentHighScores.Length;
        }

        //find position for score
        for (int i = 0; i < loop; i++)
        {
            if (currentHighScores[i] != null)
            {
                int temp = int.Parse(currentHighScores[i].Split(',')[1]);
                if (temp <= score)
                {
                    newHighscoreIndex = i;
                    break;
                }
            }
        }

        Debug.Log("newHighscoreIndex " + newHighscoreIndex);
        
        string highscore = name + ',' + score.ToString();

        //save last highscore at this position
        string nextValue = currentHighScores[newHighscoreIndex];
        //save new highscore at new position.
        currentHighScores[newHighscoreIndex] = highscore;

        //loop for highscores on indices newHighscoreIndex ++ and set the respective last highscore at i+1.
        int restOfArray = loop - newHighscoreIndex;
        //loop (10 or less) - highscoreIndex (pos of new highscore) - 1 (last highscore will drop out if highscore already full (10)).
        if (loop == 10)
        {
            restOfArray -= 1;
        }
        for (int i = newHighscoreIndex + 1; i < restOfArray; i++)
        {
            string temp = currentHighScores[i];
            currentHighScores[i] = nextValue;
            nextValue = temp;
        }

        PlayerPrefsX.SetStringArray(playerPrefsKey, currentHighScores);

    }
}
