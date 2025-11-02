using UnityEngine;

public class PlayerInAttackRangeTrigger : MonoBehaviour
{
    private TurtleEnemyController turtleController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turtleController = GetComponentInParent<TurtleEnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            Debug.Log("Player entered attack range");
            turtleController.isPlayerInAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            Debug.Log("Player exited attack range");
            turtleController.isPlayerInAttackRange = false;
        }
    }
}
