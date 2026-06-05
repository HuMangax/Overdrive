using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed;
    public float turnSpeed;
    public float decay;

    private bool moving;
    public InputActionReference move;
    private float turnDirection;
    public InputActionReference turn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moving = move.action.IsPressed();
        turnDirection = turn.action.ReadValue<float>();
    }

    void FixedUpdate()
    {
        float velocityMod = moving ? 1f : 0f;
        Vector2 forwardVelocity = velocityMod * moveSpeed * (Vector2)transform.up;
        body.linearVelocity = (body.linearVelocity + forwardVelocity) * decay;

        body.angularVelocity = turnDirection * turnSpeed;
    }
}
