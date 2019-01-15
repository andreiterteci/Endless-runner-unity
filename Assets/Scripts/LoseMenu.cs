using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour {

    public Text FinalScore;
    public Text HighscoreText;


	private void Start () {
        gameObject.SetActive(false);
        HighscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
    }
	

	private void Update () {
		
	}
    public void ToggleMenu(float scor)
    {
        gameObject.SetActive(true);
        FinalScore.text = ((int)scor).ToString();
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
