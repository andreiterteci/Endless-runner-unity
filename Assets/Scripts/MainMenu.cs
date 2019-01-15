using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text HighscoreText;

	// Use this for initialization
	void Start () {
        HighscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
	}
	
	// Update is called once per frame
	void Update () {
        	
	}

    public void toPlay()
    {
        SceneManager.LoadScene("Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

