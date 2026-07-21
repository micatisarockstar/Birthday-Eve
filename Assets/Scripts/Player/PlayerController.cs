using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3.5f;
    public float runSpeed = 6.5f;
    public SpriteRenderer spriteRenderer;   // drag sprite Kavi di sini
    private Rigidbody2D rb;
    private float moveInput;
    private bool isRunning;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;             // side-scroll 2D, bukan platformer dengan gravitasi
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // A/D atau tombol panah, sudah default di Unity
        isRunning = Input.GetKey(KeyCode.LeftShift);
        // Sprite flip otomatis -> INI PENGGANTI ANIMASI ARAH, cukup 1 gambar statis
        if (moveInput > 0.01f) spriteRenderer.flipX = false;
        else if (moveInput < -0.01f) spriteRenderer.flipX = true;
    }
    void FixedUpdate()
    {
        float speed = isRunning ? runSpeed : walkSpeed;
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
    public bool IsMoving() => Mathf.Abs(moveInput) > 0.01f;
    public bool IsRunning() => isRunning;
}