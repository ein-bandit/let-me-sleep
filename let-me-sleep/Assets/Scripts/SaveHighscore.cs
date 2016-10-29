using UnityEngine;
using System.Collections;

public class SaveHighscore : MonoBehaviour
{
    private const int maxHighScoreLength = 5;
    private string[] currentHighScores;

    // Use this for initialization
    void Start()
    {
        currentHighScores = GameManager.getHighscores();
        foreach (string str in currentHighScores)
        {
            Debug.Log(str);
        }
        Debug.Log("currentHighscoreLength " + currentHighScores.Length);
    }

    public void saveHighScore(string name, int score)
    {

        Debug.Log("before saving...");
        foreach (string str in currentHighScores)
        {
            Debug.Log(str);
        }



        int newHighscoreIndex = 0;

        int loop = maxHighScoreLength;
        if (currentHighScores.Length < maxHighScoreLength)
        {
            loop = currentHighScores.Length;
        }

        //enlarge array if not 5
        if (currentHighScores.Length < maxHighScoreLength)
        {
            string[] newArray = new string[currentHighScores.Length + 1];
            for (int i = 0; i < currentHighScores.Length; i++)
            {
                Debug.Log("copying value " + currentHighScores[i]);
                newArray[i] = currentHighScores[i];
                Debug.Log("copied value " + newArray[i]);
            }
            currentHighScores = newArray;
            //override loop to have new length.
            loop = currentHighScores.Length;

            Debug.Log("new array...");
            foreach (string str in currentHighScores)
            {
                Debug.Log(str);
            }

        }
        

        for (int i = 0; i < loop; i++)
        {
            //jump over last values if array was extended and highscore can be null at last index.
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
        Debug.Log("new high score: " + highscore);

        //save last highscore at this position
        string nextValue = currentHighScores[newHighscoreIndex];
        Debug.Log("nextvalue: " + nextValue);

        //save new highscore at new position.
        currentHighScores[newHighscoreIndex] = highscore;

        for (int i = (newHighscoreIndex + 1); i < currentHighScores.Length; i++)
        {
            string temp = currentHighScores[i];
            currentHighScores[i] = nextValue;
            nextValue = temp;
        }
        

        Debug.Log("saving...");
        foreach(string str in currentHighScores)
        {
            Debug.Log(str);
        }

        GameManager.saveHighScores(currentHighScores);

    }
}
