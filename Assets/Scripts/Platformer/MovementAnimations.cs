using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody.velocity.x) <= 0.05)
        {
            animator.SetBool(IsWalking, false);
        } 
        else if (rigidbody.velocity.x > 0.05)
        {
            spriteRenderer.flipX = false;
            animator.SetBool(IsWalking, true);
        }
        else
        {
            spriteRenderer.flipX = true;
            animator.SetBool(IsWalking, true);
        }
    }
}