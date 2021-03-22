using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollectible : MonoBehaviour
{
    [Header("Pick one")]
    public bool isAttackSpeedParticle;
    public bool isDmgParticle;
    public bool isMovementSpeedParticle;
    public bool isHpParticle;

    public GameObject effectSfx;

    private PlayerStats playerStats;

    public void GiveEffect() {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        if (isAttackSpeedParticle) {
            playerStats.AttackSpeedCollected();
        } else if (isDmgParticle) {
            playerStats.DmgCollected();
        } else if (isMovementSpeedParticle) {
            playerStats.MovementSpeedCollected();
        } else if (isHpParticle) {
            playerStats.HealthCollected();
        }
        GameObject sfxEffect = Instantiate(effectSfx, transform.position, Quaternion.identity);
        Destroy(sfxEffect, 1f);
        Destroy(gameObject);
    }

    
}
