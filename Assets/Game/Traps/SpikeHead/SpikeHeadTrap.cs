using UnityEngine;

public class SpikeHeadTrap : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            GameManager.Instance.LooseLife();
        }
    }
}
