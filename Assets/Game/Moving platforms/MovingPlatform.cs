using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxXaxisValue = 0f;
    [SerializeField] private float minXaxisValue = 0f;
    [SerializeField] private GameObject player;

    // B
    [SerializeField] private Transform[] points;
    [SerializeField] private float marginOfError = 0.01f;
    [SerializeField] private bool loopPoints;

    private int currentPointIndex = 0;
    private int indexStep = -1;

    // Update is called once per frame
    void Update()
    {
        // A approach
        //if (transform.position.x > maxXaxisValue)
        //{
        //    moveSpeed = -moveSpeed;
        //}
        //else if (transform.position.x < minXaxisValue)
        //{
        //    moveSpeed = -moveSpeed;
        //}
        //transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        // B approach
        if (points.Length != 0)
        {
            Transform currentPoint = points[currentPointIndex];
            Transform targetPos = currentPoint.transform;
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);

            float distance = Vector3.Distance(targetPos.transform.position, transform.position);
            if (distance < marginOfError) { 
                if (currentPointIndex == (points.Length - 1) || currentPointIndex == 0)
                {
                    indexStep = -indexStep;
                }
                currentPointIndex += indexStep;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.tag == collision.gameObject.tag)
        {
            player.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (player.tag == collision.gameObject.tag)
        {
            player.transform.SetParent(null);
        }
    }
}
