using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private Rigidbody2D _body;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _body.linearVelocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid")) Destroy(gameObject);
    }
}
