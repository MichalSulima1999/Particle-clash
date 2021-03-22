using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public GameObject selectLevel;

     public void MenuButton() {
        SceneManager.LoadScene(0);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void CreditsLevel() {
        SceneManager.LoadScene(6);
    }

    public void Exit() {
        Application.Quit();
    }

    public void StartBtn() {
        if (!selectLevel.activeSelf)
            selectLevel.SetActive(true);
        else
            selectLevel.SetActive(false);
    }

    public void StartTutorial() {
        SceneManager.LoadScene(1);
    }
    
    public void StartLevel1() {
        SceneManager.LoadScene(2);
    }
    
    public void StartLevel2() {
        SceneManager.LoadScene(3);
    }
    
    public void StartLevel3() {
        SceneManager.LoadScene(4);
    }
    
    public void StartLevel4() {
        SceneManager.LoadScene(5);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
            SceneManager.LoadScene(0);
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.P))
            PlayerPrefs.SetInt("levelsWon", 4);
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.O))
            PlayerPrefs.SetInt("levelsWon", 0);
    }

}
