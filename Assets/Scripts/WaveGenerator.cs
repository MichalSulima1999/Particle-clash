using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    public Text wavesText;

    private int waveIndex = 0;

    public int maxWaves = 10;

    public bool wavesEnded;

    private void Update() {
        if (waveIndex >= maxWaves) {
            countdown = 0;
            wavesEnded = true;
            return;
        }
            

        if (countdown <= 0f || Input.GetKeyDown(KeyCode.N)) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        wavesText.text = PlayerStats.Rounds + "/" + maxWaves;
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy() {
        for(int i = 0; i < spawnPoints.Length; i++) {
            Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
        } 
    }
}
