using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private float _direction;
    private Rigidbody2D _body;
    private bool _isTouchingGround;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        _direction = Input.GetAxis("Horizontal");

        HandleDirectionMovement();
        HandleJump();
    }

    private void HandleJump()
    {
        if (Input.GetButton("Jump") && _isTouchingGround)
        {
            _body.velocity = new Vector2(_body.velocity.x, jumpSpeed);
        }
    }

    private void HandleDirectionMovement()
    {
        if (_direction > 0F)
        {
            _body.velocity = new Vector2(_direction * speed, _body.velocity.y);
        }
        else if (_direction < 0F)
        {
            _body.velocity = new Vector2(_direction * speed, _body.velocity.y);
        }
        else
        {
            _body.velocity = new Vector2(0, _body.velocity.y);
        }
    }
}