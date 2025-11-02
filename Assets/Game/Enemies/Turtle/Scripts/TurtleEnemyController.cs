using UnityEngine;

public class TurtleEnemyController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float playerPositionOffest = 1f;
    [SerializeField] private AudioSource attackAudioSource;
    
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    public bool isTriggered = false;
    public bool isPlayerInAttackRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Is enemy triggered: " + isTriggered);
        if (isTriggered)
        {
            if (isPlayerInAttackRange)
            {
                Debug.Log("Attacking the player");
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                animator.SetTrigger("Attack"); // Trigger from Animator parameters
            }
            else if (player.transform.position.x < transform.position.x + playerPositionOffest)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
                rigidbody.linearVelocity = new Vector2(-moveSpeed, 0f);
                spriteRenderer.flipX = false;
            }
            else if (player.transform.position.x > transform.position.x - playerPositionOffest)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
                rigidbody.linearVelocity = new Vector2(moveSpeed, 0f);
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            rigidbody.linearVelocity = Vector2.zero; // new Vector2(0f, 0f)
        }
    }

    public void AttackPlayer()
    {
        Debug.Log("Attacking the player");
        attackAudioSource.Play();
        if (isPlayerInAttackRange)
        {
            Debug.Log("Player gets damage!");
            GameManager.Instance.LooseLife();
        }
    }
}
