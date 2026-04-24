using UnityEngine;
using System.Collections;

public class MovementCharacter : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float movementSpeed = 5.0f;
    public float jumpForce = 10f;

    [Header("Player Config")]
    [SerializeField] private Transform groundPosition;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radiusGroundCheck = 0.1f;
    [SerializeField] public bool isGround;
    public int consecutiveJump = 2;

    [Header("Dash Config")]
    public int consecutiveDash = 2;
    public float dashForce = 50f;

    [Header("Attack Config")]
    public GameObject bulletPrefab;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }
    
    private void CheckGround()
    {
        bool wasGrounded = isGround;
        isGround = Physics2D.OverlapCircle(groundPosition.position, radiusGroundCheck, groundLayer);

        if (isGround && !wasGrounded)
        {
            consecutiveJump = 2;
            consecutiveDash = 2;
        }
    }

    public void OnMovementCharacter(float dirX)
    {
        float lerpFactor = isGround ? 0.2f : 0.05f;
        float xVelocity = Mathf.Lerp(rb2D.linearVelocity.x, dirX * movementSpeed, lerpFactor);

        Vector2 newLinearVelocity = new Vector2(xVelocity, rb2D.linearVelocity.y);
        rb2D.linearVelocity = newLinearVelocity;
    }

    public void OnDashCharacter(float dirX)
    {
        if (consecutiveDash > 0)
        {
            if (dirX >= 0)
            {
                StartCoroutine(PerformDash(1));
            }
            else if (dirX < 0)
            {
                StartCoroutine(PerformDash(-1));
            }
        }
    }

    IEnumerator PerformDash(float dirX)
    {
        consecutiveDash--;
        float originalGravity = rb2D.gravityScale;

        rb2D.gravityScale = 0;
        Vector2 newLinearVelocity = new Vector2(dirX * dashForce, 0);
        rb2D.linearVelocity = newLinearVelocity;

        yield return new WaitForSeconds(0.15f);
        rb2D.gravityScale = originalGravity;

        yield return new WaitForSeconds(1f);
        consecutiveDash++;

        if(consecutiveDash > 2) consecutiveDash = 2;
    }
    
    public void OnJumpCharacter()
    {
        if (consecutiveJump > 0)
        {
            if (!isGround)
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, 0);
            }
            
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            consecutiveJump--;
        }
    }
    public void OnAttackCharacter()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 shootDirection = (mouseWorldPosition - transform.position).normalized;

        Vector2 spawnPos = (Vector2)transform.position + (shootDirection * 0.5f);

        GameObject bulletObject = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        BulletMovement bullet = bulletObject.GetComponent<BulletMovement>();


        bullet.Launch(shootDirection, 20f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            consecutiveJump = 2;
        }
    }
}
