using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float shootStartSpeed = 2f;
    private float shootTimer;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.won)
            return;

        shootTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootTimer <= 0) {
            Shoot();
            shootTimer = Mathf.Max(shootStartSpeed - 0.1f * PlayerStats.AttackSpeedParticlesNumber, 0.2f);
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
