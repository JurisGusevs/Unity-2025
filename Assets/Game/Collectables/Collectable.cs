using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            animator.SetTrigger("Collect");
            GameManager.Instance.IncreaseScore();
        }
    }

    public void OnCollected()
    {
        Destroy(gameObject);
    }
}
