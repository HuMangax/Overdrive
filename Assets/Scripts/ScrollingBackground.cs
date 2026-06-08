using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;

    private SpriteRenderer _renderer;
    private float _spriteHeight;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _spriteHeight = _renderer.bounds.size.y;
    }

    private void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // When the sprite has scrolled fully below the camera, jump it back up
        if (transform.position.y < -_spriteHeight)
            transform.position += Vector3.up * _spriteHeight * 2f;
    }
}
