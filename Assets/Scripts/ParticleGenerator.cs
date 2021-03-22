using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    private int mode = 0;

    public GameObject strParticle;
    public GameObject aSParticle;
    public GameObject mSParticle;
    public GameObject hpParticle;
    public GameObject enemyParticle;

    public GameObject spawnEffect;
    public GameObject spawnLoc;
    public ParticleSystem generatorParticles;

    public Sprite enemyGenerator;
    public Sprite friendlyGenerator;

    public float timeToGenerate = 10f;
    private float timeCounter;

    private void Start() {
        ChangeMode(friendlyGenerator, new Color(1f, 0.4f, 0.033f, 1f));
        timeCounter = 5f;
    }

    private void Update() {
        if (GameManager.won || GameManager.lost)
            return;

        timeCounter -= Time.deltaTime;

        if(timeCounter <= 0) {
            switch (mode) {
                case 0:
                    GenerateParticle(strParticle, new Color(1f, 0.4f, 0.033f, 1f));
                    break;
                case 1:
                    GenerateParticle(aSParticle, Color.yellow);
                    break;
                case 2:
                    GenerateParticle(mSParticle, Color.cyan);
                    break;
                case 3:
                    GenerateParticle(hpParticle, Color.green);
                    break;
                case 4:
                    GenerateParticle(enemyParticle, Color.red);
                    break;
            }
            timeCounter = timeToGenerate;
        }
    }

    void GenerateParticle(GameObject part, Color color) {
        Instantiate(part, spawnLoc.transform.position, Quaternion.identity);
        GameObject effect = Instantiate(spawnEffect, spawnLoc.transform.position, Quaternion.identity);
        var eff = effect.GetComponent<ParticleSystem>().main;
        eff.startColor = color;
        Destroy(effect, 2f);
    }

    void ChangeMode(Sprite sprite, Color color) {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        var generatorPart = generatorParticles.main;
        generatorPart.startColor = color;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")) {
            gameObject.layer = 8;
            gameObject.tag = "EnemyTarget";

            switch (mode) {
                case 0:
                    mode++;
                    ChangeMode(friendlyGenerator, Color.yellow);
                    break;
                case 1:
                    mode++;
                    ChangeMode(friendlyGenerator, Color.cyan);
                    break;
                case 2:
                    mode++;
                    ChangeMode(friendlyGenerator, Color.green);
                    break;
                case 3:
                    mode = 0;
                    ChangeMode(friendlyGenerator, new Color(1f, 0.4f, 0.033f, 1f));
                    break;
                default:
                    mode = 0;
                    ChangeMode(friendlyGenerator, new Color(1f, 0.4f, 0.033f, 1f));
                    break;
            }
        } else if (collision.CompareTag("EnemyBullet")) {
            gameObject.layer = 0;
            gameObject.tag = "Untagged";
            ChangeMode(enemyGenerator, Color.red);
            mode = 4;
        }
    }
}
