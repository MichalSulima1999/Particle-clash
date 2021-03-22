using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private WaveGenerator waveGenerator;

    private GameObject[] enemies;

    public static bool won;

    public static bool lost;

    public static float Difficulty = 0.8f;

    public GameObject wonUI;
    public GameObject lostUI;

    public static int levelsDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        won = false;
        waveGenerator = GetComponent<WaveGenerator>();
        InvokeRepeating("checkWin", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (lost) {
            lostUI.SetActive(true);
        }
    }

    void checkWin() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0 && waveGenerator.wavesEnded) {
            won = true;
            wonUI.SetActive(true);

            levelsDone = SceneManager.GetActiveScene().buildIndex;
            if (levelsDone > PlayerPrefs.GetInt("levelsWon")) {
                PlayerPrefs.SetInt("levelsWon", levelsDone);
            }
        }
    }
}
