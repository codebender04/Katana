using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb2D;
    private Vector3 moveDir = Vector2.zero;
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, vertical, 0).normalized;

        rb2D.velocity = moveDir * moveSpeed;
        if (IsRunning())
        {
            transform.localRotation = horizontal > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        }
    }
    public bool IsRunning()
    {
        return rb2D.velocity.sqrMagnitude > 0.01;
    }
}
