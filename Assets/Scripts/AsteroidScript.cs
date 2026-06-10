using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public Rigidbody2D body;


    void Start()
    {
        body.angularVelocity = Random.Range(-180f,180f);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
