using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider hpSlider;
    public Enemy enemy;


    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = enemy.startHp;
        hpSlider.value = enemy.hp;
    }
}
