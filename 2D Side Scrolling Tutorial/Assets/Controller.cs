using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    /// <summary> Player References </summary>
    private PlayerInput playerInput;

    /// <summary> Player Physics </summary>
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool facingRight = true;

    /// <summary> Player Movement Stats </summary>
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Jumping();
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Mathf.Abs(playerInput.actions["Horizontal"].ReadValue<float>()) * movementSpeed * Time.deltaTime, 0, 0);

        if ((playerInput.actions["Horizontal"].ReadValue<float>() > 0 && !facingRight) || (playerInput.actions["Horizontal"].ReadValue<float>() < 0 && facingRight))
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jumping()
    {
        if (playerInput.actions["Jump"].triggered && JumpAvaliable())
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    private bool JumpAvaliable()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
