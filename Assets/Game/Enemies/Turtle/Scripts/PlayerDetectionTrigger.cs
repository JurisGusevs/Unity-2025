using System;
using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{
    private TurtleEnemyController turtleController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turtleController = GetComponentInParent<TurtleEnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        Debug.Log("Object entered trigger " + colliderObject.gameObject.name);
        if (colliderObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            turtleController.isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colliderObject)
    {
        Debug.Log("Object exited trigger " + colliderObject.gameObject.name);
        if (colliderObject.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            turtleController.isTriggered = false;
        }
    }
}
