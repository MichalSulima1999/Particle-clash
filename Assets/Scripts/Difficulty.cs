using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public Text difficultyText;

    public float easyDif = 0.5f;
    public float mediumDif = 0.8f;
    public float hardDif = 1f;
    public float hellDif = 1.15f;

    private void Start() {
        GameManager.Difficulty = mediumDif;
    }

    public void Easy() {
        difficultyText.text = "Difficulty: EASY";
        difficultyText.color = Color.white;

        GameManager.Difficulty = easyDif;
    }

    public void Medium() {
        difficultyText.text = "Difficulty: MEDIUM";
        difficultyText.color = Color.white;

        GameManager.Difficulty = mediumDif;
    }

    public void Hard() {
        difficultyText.text = "Difficulty: HARD";
        difficultyText.color = Color.white;

        GameManager.Difficulty = hardDif;
    }

    public void Hell() {
        difficultyText.text = "Difficulty: HELL";
        difficultyText.color = Color.red;

        GameManager.Difficulty = hellDif;
    }
}
