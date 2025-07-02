using UnityEngine;


public class Unit : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] float stoppingDistance = 0.1f;

    Vector3 targetPosition;


    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;  
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));
        }
    }

    void Move(Vector3 targetPos)
    {
        this.targetPosition = targetPos;
    }
}
