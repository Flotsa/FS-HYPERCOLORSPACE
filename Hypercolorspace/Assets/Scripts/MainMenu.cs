using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public UI_Text_Manager textManager;
    public GameObject mainMenuParentToEnable;

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {

        SceneManager.LoadScene(1);
        //GameEngine.Instance.finishLevel();
        
        GameEngine.Instance.ResetGame();
        textManager.Play();
        
        gameObject.SetActive(false);
        
    }

    public void Retry()
    {
        if(GameEngine.Instance.getCurrentLevel() == 0)
        {
            QuitToMenu();
            mainMenuParentToEnable.SetActive(true);
            return;
        }
        SceneManager.LoadScene(GameEngine.Instance.getCurrentLevel());
        GameEngine.Instance.ResetLevel();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
        GameEngine.Instance.QuitToMenu();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
