using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int enemyDamage = 10;
    public Rigidbody2D rb;

    public GameObject hitGroundEffect;
    public GameObject hitEnemyEffect;
    public GameObject hitPlayerEffect;

    public bool isEnemy;

    public GameObject shootPlayerSFX;
    public GameObject shootEnemySFX;
    GameObject sound;
    public GameObject damageSFX;
    GameObject damageSound;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", 1);

        if (!isEnemy)
            sound = Instantiate(shootPlayerSFX, transform.position, Quaternion.identity);
        else
            sound = Instantiate(shootEnemySFX, transform.position, Quaternion.identity);
        Destroy(sound, 0.5f);
    }

    void DestroyBullet() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && isEnemy) {
            GameObject effect = Instantiate(hitPlayerEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);

            damageSound = Instantiate(damageSFX, transform.position, Quaternion.identity);
            Destroy(damageSound, 0.5f);

            collision.GetComponent<PlayerStats>().GetDamage((int)(enemyDamage * GameManager.Difficulty));

            Destroy(gameObject);
        } else if (collision.CompareTag("Enemy") && !isEnemy) {
            GameObject effect = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            damageSound = Instantiate(damageSFX, transform.position, Quaternion.identity);
            Destroy(damageSound, 0.5f);

            collision.GetComponent<Enemy>().TakeDamage((int)(PlayerStats.Damage / GameManager.Difficulty));

            Destroy(gameObject);
        } else if (collision.CompareTag("Enemy") && isEnemy) {

        } else {
            if (!collision.CompareTag("ParticleCollectible") && !collision.CompareTag("EnemyBullet") && !collision.CompareTag("Bullet")) {
                GameObject effect = Instantiate(hitGroundEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);

                damageSound = Instantiate(damageSFX, transform.position, Quaternion.identity);
                Destroy(damageSound, 0.5f);

                Destroy(gameObject);
            }
        }
            
    }
}
