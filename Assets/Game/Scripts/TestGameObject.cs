using UnityEngine;

public class TestGameObject : MonoBehaviour
{

    [SerializeField] GameObject alien;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alien.AddComponent<Rigidbody2D>();
        Rigidbody2D rb = alien.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
