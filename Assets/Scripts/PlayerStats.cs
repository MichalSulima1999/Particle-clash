using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int maxHP;
    public int startHP = 100;
    public static int Hp;

    public static float MSpeed = 10f;
    public static float ASpeed = 1f;
    public static int Damage = 10;

    public int maxParticles = 20;

    public static int AttackSpeedParticlesNumber;
    public static int DmgParticlesNumber;
    public static int MovementSpeedParticlesNumber;
    public static int HpParticlesNumber;

    public int startDMG = 10;

    [Header("Particles Properties")]
    public int dmgPerParticle;
    public float movementPerParticle;
    public int hpPerParticle;
    public PlayerParticles playerParticle;

    public GameObject playerDieEffect;

    public static int Rounds;

    private void Start() {
        AttackSpeedParticlesNumber = 1;
        DmgParticlesNumber = 1;
        MovementSpeedParticlesNumber = 1;
        HpParticlesNumber = 1;

        Hp = startHP + HpParticlesNumber * hpPerParticle;
        maxHP = Hp;

        ASpeed = Mathf.Sqrt(ASpeed + AttackSpeedParticlesNumber);
        Damage = DmgParticlesNumber * dmgPerParticle + startDMG;
        MSpeed = Mathf.Sqrt(MSpeed + MovementSpeedParticlesNumber * movementPerParticle)*1.5f;

        Rounds = 0;

        InvokeRepeating("RegenerateHP", 0f, 0.5f);
    }

    void RegenerateHP() {
        if (GameManager.lost || GameManager.won)
            return;
        if (Hp < maxHP)
            Hp += (int)Mathf.Ceil(HpParticlesNumber / 2f);

        if (Hp > maxHP)
            Hp = maxHP;
    }

    public void GetDamage(int damage) {
        Hp -= damage;

        if (Hp <= 0) {
            Hp = 0;
            Die();
        }
    }

    void Die() {
        GameManager.lost = true;
        GameObject effect = Instantiate(playerDieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        gameObject.SetActive(false);
    }

    public void AttackSpeedCollected() {
        if (AttackSpeedParticlesNumber >= maxParticles)
            return;

        AttackSpeedParticlesNumber++;

        var emission = playerParticle.attackSpeedParticles.emission;
        emission.rateOverTime = AttackSpeedParticlesNumber;
        ASpeed = Mathf.Sqrt(ASpeed + AttackSpeedParticlesNumber);
    }

   public void DmgCollected() {
        if (DmgParticlesNumber >= maxParticles)
            return;

        DmgParticlesNumber++;

        var emission = playerParticle.dmgParticles.emission;
        emission.rateOverTime = DmgParticlesNumber;
        Damage = DmgParticlesNumber * dmgPerParticle + startDMG;
    }

    public void MovementSpeedCollected() {
        if (MovementSpeedParticlesNumber >= maxParticles)
            return;

        MovementSpeedParticlesNumber++;

        var emission = playerParticle.movementSpeedParticles.emission;
        emission.rateOverTime = MovementSpeedParticlesNumber;

        MSpeed = Mathf.Sqrt(MSpeed + MovementSpeedParticlesNumber * movementPerParticle)*1.5f;
    }

    public void HealthCollected() {
        if (HpParticlesNumber >= maxParticles)
            return;

        HpParticlesNumber++;

        var emission = playerParticle.hpParticles.emission;
        emission.rateOverTime = HpParticlesNumber;

        maxHP += HpParticlesNumber * hpPerParticle;
        Hp += HpParticlesNumber * hpPerParticle;
    }
}
