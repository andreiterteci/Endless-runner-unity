using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float score = 0.0f;
    public Text scoreText;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 100;
    private int scoreToNextLevel = 10;
    private bool hasLost = false;
    public LoseMenu loseMenu;

    private void Update () {
        if (hasLost == true)
        { return; }
        if (score >= scoreToNextLevel)
            LevelUp();
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
	}

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMovement>().setSpeed(difficultyLevel);
    }

    public void onLose()
    {
        hasLost = true;
        PlayerPrefs.SetFloat("Highscore", score);
        loseMenu.ToggleMenu(score);
    }
}
