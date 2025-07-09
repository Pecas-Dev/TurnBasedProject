using UnityEngine;


public class Unit : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] float stoppingDistance = 0.1f;
    [SerializeField] float rotateSpeed = 10.0f;

    [Header("Animation")]
    [SerializeField] Animator unitAnimator;

    Vector3 targetPosition;

    void Awake()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("isWalking", true);
        }
        else
        {
            unitAnimator.SetBool("isWalking", false);
        }
    }

    public void Move(Vector3 targetPos)
    {
        this.targetPosition = targetPos;
    }
}
