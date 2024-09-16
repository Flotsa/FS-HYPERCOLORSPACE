using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public static GameEngine Instance;



    int lives = 3;
    int deaths = 0;
    int score = 0;
    float time = 0;
    int currentLevel = 0;

    bool doingTransition = false;


    public int nbEnemiesOnLevel = 50;
    public int currentNbEnemiesOnLevel;

    public TextMeshProUGUI retryUI;
    public UI_Text_Manager UIText;
    public float transitionTime = 3f;
    public Camera mainCam;



    public GameEngine GetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        return Instance;
    }

    public void addScore(int scoreToAdd)
    {
        score+= scoreToAdd;
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public int getLives()
    {
        return lives;
    }

    public int getDeaths()
    {
        return deaths;
    }

    public int getScore()
    {
        return score;
    }

    public float getTime()
    {
        return time;
    }

    public void ResetLives()
    {
        lives = 3;
    }

    public void ResetTime()
    {
        time = 0;
    }

    public void ResetDeaths()
    {
        deaths = 0;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetGame()
    {
        
        currentLevel = 1;
        ResetLives();
        ResetDeaths();
        ResetScore();
        ResetTime();
        
    }

    public void LoseLife()
    {
        
        if (lives <= 0) { GameOver(); return; }
        lives--;
        deaths++;
        
        //loop protection
        if(lives == 0) { deaths++;}
    }

    public void finishLevel()
    {
        currentLevel++;
        if (currentLevel >= 4) 
        {
            currentLevel = 0;
            GameOver();
            
        }
        else
        {

            SceneManager.LoadScene(currentLevel);
            doingTransition = false;
            nbEnemiesOnLevel = FindAnyObjectByType(typeof(nbEnemies)).GetComponent<nbEnemies>().getNbEnemies();
            currentNbEnemiesOnLevel = nbEnemiesOnLevel;
        }    

    }

    

    private void OnLevelWasLoaded()
    {
        nbEnemiesOnLevel = FindAnyObjectByType(typeof(nbEnemies)).GetComponent<nbEnemies>().getNbEnemies();
        currentNbEnemiesOnLevel = nbEnemiesOnLevel;
    }
    
    public void GameOver()
    {
        retryUI.gameObject.SetActive(true);
        UIText.GameOver();
        
        Time.timeScale = 0;
    }

    public void ResetLevel()
    {
        retryUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        ResetLives();
        UIText.Play();
        CancelInvoke();


    }

    public void QuitToMenu()
    {
        currentNbEnemiesOnLevel = 99;
        retryUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        UIText.MainMenu();
        


    }

    public void LevelTransition()
    {

        doingTransition = true;
        mainCam.clearFlags = CameraClearFlags.Nothing;
        Invoke("UndoCamEffect", transitionTime);
        Invoke("finishLevel", transitionTime);
        
    }

    public void UndoCamEffect()
    {
        mainCam.clearFlags = CameraClearFlags.SolidColor;
    }

    public void EnemyKilled()
    {
        currentNbEnemiesOnLevel--;
    }    

    

    // Start is called before the first frame update
    void Start()
    {
        GetInstance();
        currentNbEnemiesOnLevel = nbEnemiesOnLevel;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;



        if (currentNbEnemiesOnLevel <= 0 && currentLevel >= 1 && doingTransition == false)
        {
            LevelTransition();
        }

        if (mainCam == null)
        {
            mainCam = FindAnyObjectByType(typeof(Camera)).GetComponent<Camera>();

            if (mainCam.clearFlags == CameraClearFlags.SolidColor)
            {
                doingTransition = false;
            }
        }
    }
}
