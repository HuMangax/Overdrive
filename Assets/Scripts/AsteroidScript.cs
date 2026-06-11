using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public Rigidbody2D body;
    public AsteroidSize size;
    public float moveSpeed;
    public int edge;

    public void init(int spawnEdge, AsteroidSize asteroidSize, Vector2? fragmentVelocity = null)
    {
        size = asteroidSize;
        edge = spawnEdge;
        body.angularVelocity = Random.Range(-180f,180f);
        body.linearVelocity = fragmentVelocity.HasValue
            ? fragmentVelocity.Value
            : DetermineVelocity();
    }

    Vector2 DetermineVelocity()
    {
        float velocityMod = Random.Range(-0.3f, 0.3f);
        float xVelocity = 0f;
        float yVelocity = 0f;
        // Set velocity based on which edge the asteroid spawned at
        switch (edge)
        {
            case 0: // North
                xVelocity = Offset();
                yVelocity = -moveSpeed * velocityMod;
                break;
            case 1: // East
                xVelocity = -moveSpeed * velocityMod;
                yVelocity = Offset();
                break;
            case 2: // South
                xVelocity = Offset();
                yVelocity = moveSpeed * velocityMod;
                break;
            case 3: // West
                xVelocity = moveSpeed * velocityMod;
                yVelocity = Offset();
                break;
        }
        return new Vector2(xVelocity, yVelocity);
    }

    float Offset()
    {
        return Random.Range(-moveSpeed/2f, moveSpeed/2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) Hit();
    }

    void Hit()
    {
        FindObjectOfType<SpawnerScript>().SpawnFragments(transform.position, size);
        Destroy(gameObject);
    }
}
