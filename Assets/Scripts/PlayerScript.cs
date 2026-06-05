using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 5;
    private Vector2 direction;
    public InputActionReference move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = move.action.ReadValue<Vector2>();
        body.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
