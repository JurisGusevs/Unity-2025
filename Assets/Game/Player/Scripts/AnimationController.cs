using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float animationTriggerOffset = 0.1f;
    private PlayerMovement playerMovementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.isPlayerDead)
        {
            animator.SetTrigger("Death");
        } 
        else
        {
            if (rb.linearVelocityX < -animationTriggerOffset)
            {
                spriteRenderer.flipX = true;
            }
            else if (rb.linearVelocityX > animationTriggerOffset)
            {
                spriteRenderer.flipX = false;
            }

            // && = AND || = OR
            if (Mathf.Abs(rb.linearVelocityX) > animationTriggerOffset && Mathf.Abs(rb.linearVelocityY) < animationTriggerOffset)
            {
                animator.Play("Run");
            }
            else if (rb.linearVelocityY > animationTriggerOffset)
            {
                animator.Play("Jump");
            }
            else if (rb.linearVelocityY < -animationTriggerOffset)
            {
                animator.Play("Falling");
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }

    public void OnPlayerDeath()
    {
        GameManager.Instance.LooseLife(true);
        GameManager.Instance.EnableGameOverScreen();
        Destroy(gameObject);
    }
}
