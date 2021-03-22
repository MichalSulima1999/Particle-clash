using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHp = 100;
    public int hp;
    public float spottedSpeed = 5f;
    public float maxPatrolSpeed = 3f;
    public float movementSpeedAttacking = 1f;

    public int hpPerWave = 10;

    public float attackSpeed = 0.1f;
    private float attackTime;
    public GameObject bullet;
    public GameObject attackPoint;

    public GameObject deathEffect;

    private Rigidbody2D rbody;

    public float timeToChangeDirection = 2f;
    private float counterToChangeDirection;

    public float sightRange = 2f;
    private bool playerInSight;
    public float attackRange = 2f;
    private bool playerInAttackRange;

    public LayerMask whatIsPlayer;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");

        GameObject[] targets = GameObject.FindGameObjectsWithTag("EnemyTarget");

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        startHp += (int)(PlayerStats.Rounds * hpPerWave * GameManager.Difficulty);
        hp = startHp;

        attackSpeed *= 1 / GameManager.Difficulty;
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyTarget");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= sightRange) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    private void Update() {
        playerInSight = Physics2D.OverlapCircle(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);

        

        if (!playerInSight && !playerInAttackRange) {
            Patrol();
        } else if (playerInSight && !playerInAttackRange) {
            if (target == null)
                return;
            PlayerSpotted();
        } else {
            if (target == null)
                return;
            Attack();
        }
    }

    void Patrol() {
        counterToChangeDirection -= Time.deltaTime;
        if (counterToChangeDirection <= 0) {
            counterToChangeDirection = timeToChangeDirection;

            float randomX = Random.Range(-maxPatrolSpeed, maxPatrolSpeed);
            float randomY = Random.Range(-maxPatrolSpeed, maxPatrolSpeed);
            rbody.velocity = new Vector2(randomX, randomY);
        }
    }

    void PlayerSpotted() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, spottedSpeed * Time.deltaTime);
        LookAtPlayer();
    }

    void LookAtPlayer() {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Attack() {
        LookAtPlayer();
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeedAttacking * Time.deltaTime);
        attackTime -= Time.deltaTime;
        if(attackTime <= 0f) {
            Instantiate(bullet, attackPoint.transform.position, attackPoint.transform.rotation);
            attackTime = attackSpeed;
        }
    }

    public void TakeDamage(int damage) {
        hp -= damage;

        if(hp <= 0) {
            Die();
        }
    }

    void Die() {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
