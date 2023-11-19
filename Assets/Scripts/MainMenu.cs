using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string asteroidsGame;
    //public GameManager scoreManager; 
    public TextMeshProUGUI highScoreText;


    //public AchievementsMenu menu;
    //public GameObject achievementsMenu;

    // Start is called before the first frame update
    void Start()
    {
        //adds current highscore 
        var highScore = PlayerPrefs.GetInt("score");
        highScoreText.text = highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame() {

        SceneManager.LoadScene(asteroidsGame);
    }

    public void OpenAcheivments() {
        
        //access static variable instance (singleton)
        AchievementsMenu.instance.openPannel();
        

    }

    public void OptionsMode()
    {

    }


    public void QuitGame() {

        Application.Quit();
    }

}
