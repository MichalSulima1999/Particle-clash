using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiStatsManager : MonoBehaviour
{
    public Slider hpSlider;
    public Text hpText;
    public Text strText;
    public Text asText;
    public Text msText;
    public Text waveText;

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = PlayerStats.maxHP;
        hpSlider.value = PlayerStats.Hp;
        hpText.text = "HP: " + PlayerStats.Hp + "/" + PlayerStats.maxHP;
        strText.text = PlayerStats.DmgParticlesNumber + "";
        asText.text = PlayerStats.AttackSpeedParticlesNumber + "";
        msText.text = PlayerStats.MovementSpeedParticlesNumber + "";
    }
}
