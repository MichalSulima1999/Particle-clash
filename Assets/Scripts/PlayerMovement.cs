using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.won) {
            rb2d.velocity = Vector2.zero;
            return;
        }
            

        float movementX = Input.GetAxisRaw("Horizontal") * PlayerStats.MSpeed;
        float movementY = Input.GetAxisRaw("Vertical") * PlayerStats.MSpeed;

        rb2d.velocity = new Vector2(movementX, movementY);

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angleDeg = 180 / Mathf.PI * angleRad;

        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ParticleCollectible")) {
            collision.GetComponent<ParticleCollectible>().GiveEffect();
        }
    }
}
