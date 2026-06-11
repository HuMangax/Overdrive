using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed;
    public float turnSpeed;
    public float decay;

    public InputActionReference move;
    public InputActionReference turn;
    public InputActionReference shoot;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private bool moving;
    private float turnDirection;
    private float nextFireTime;

    void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.Playing)
        {
            moving = false;
            turnDirection = 0f;
            return;
        }

        moving = move.action.IsPressed();
        turnDirection = turn.action.ReadValue<float>();

        if (shoot.action.IsPressed() && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void FixedUpdate()
    {
        float velocityMod = moving ? 1f : 0f;
        Vector2 forwardVelocity = velocityMod * moveSpeed * (Vector2)transform.up;
        body.linearVelocity = (body.linearVelocity + forwardVelocity) * decay;

        body.angularVelocity = turnDirection * turnSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Asteroid")) return;
        
        Die();
    }

    public void Die()
    {
        GameManager.Instance.TriggerGameOver();
    }
}
