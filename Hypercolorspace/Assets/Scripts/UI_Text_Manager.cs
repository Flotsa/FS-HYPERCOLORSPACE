using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Text_Manager : MonoBehaviour
{
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Deaths;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI TimeScore;

    //labels
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI DeathsText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeScoreText;




    // Start is called before the first frame update
    void Start()
    {


    }

    public void MainMenu()
    {
        Lives.gameObject.SetActive(false);
        LivesText.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);


        Deaths.gameObject.SetActive(false);
        TimeScore.gameObject.SetActive(false);
        DeathsText.gameObject.SetActive(false);
        TimeScoreText.gameObject.SetActive(false);
    }


    public void GameOver()
    {
        Deaths.gameObject.SetActive(true);
        TimeScore.gameObject.SetActive(true);
        DeathsText.gameObject.SetActive(true);
        TimeScoreText.gameObject.SetActive(true);
    }

    public void Play()
    {
        Lives.gameObject.SetActive(true);
        LivesText.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(true);


        Deaths.gameObject.SetActive(false);
        TimeScore.gameObject.SetActive(false);
        DeathsText.gameObject.SetActive(false);
        TimeScoreText.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        Lives.SetText(GameEngine.Instance.getLives().ToString());
        Deaths.SetText(GameEngine.Instance.getDeaths().ToString());
        Score.SetText(GameEngine.Instance.getScore().ToString());
        //TimeScore.SetText(GameEngine.Instance.getTime().ToString());
        TimeScore.SetText((GameEngine.Instance.getTime()*60).ConvertTo<int>().ToString());

    }
}
