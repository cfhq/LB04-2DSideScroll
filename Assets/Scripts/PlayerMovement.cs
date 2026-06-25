using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed = 3f;
    private float jumpStength = 10f;
    private Animator animator;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        var x = horizontalInput * speed * Time.deltaTime;
        var xyz = new Vector3(x, 0f, 0f);
        transform.Translate(xyz);

        if (horizontalInput < 0) sr.flipX = true;
        else sr.flipX = false;

        float absoluteSpeed = Mathf.Abs(horizontalInput);
        animator.SetFloat("Walk", absoluteSpeed);

        var ath = Mathf.Abs(rb.linearVelocity.y) < 0.001f;
        if (Input.GetKeyDown(KeyCode.Space) && ath)
        {
            var y = new Vector2(0f, jumpStength);
            rb.AddForce(y, ForceMode2D.Impulse);
        }
    }
}
