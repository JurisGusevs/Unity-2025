using UnityEngine;

public class FireGun : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = -500f;
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private float destroyDelay = 5f;
    private float fireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireTime)
        {
            fireTime += fireRate;
            GameObject projectileInstance = Instantiate(projectile, spawnpoint.position, projectile.transform.rotation);
            projectileInstance.transform.localScale = transform.localScale;

            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            rb.linearVelocity = projectileInstance.transform.up * projectileSpeed * Time.deltaTime;
            if (projectileInstance != null)
            {
                Destroy(projectileInstance, destroyDelay);
            }
        }
    }
}
