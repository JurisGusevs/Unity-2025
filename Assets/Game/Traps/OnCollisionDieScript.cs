using UnityEngine;

public class OnCollisionDieScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.isPlayerDead = true;
        }
    }
}
