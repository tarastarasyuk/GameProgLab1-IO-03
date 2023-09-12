using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _body.velocity.y);

        // Flip player for horizontal movement
        // if (horizontalInput > 0.01F)
        // {
        //     transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
        // }
        // else if (horizontalInput < -0.01F)
        // {
        //     transform.localScale = new Vector3(-0.2F, 0.2F, 0.2F);
        // }

        if (Input.GetKey(KeyCode.Space))
        {
            _body.velocity = new Vector2(_body.velocity.x, speed);
        }
    }
}