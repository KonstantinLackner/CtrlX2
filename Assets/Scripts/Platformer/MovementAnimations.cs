using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsHero = Animator.StringToHash("IsHero");

    public GameBools gameBools;

    public PatrolingAndAttacking PatrolingAndAttacking;

    private void Start()
    {
        if (gameBools.Level2Hero)
        {
            animator.SetBool(IsHero, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PatrolingAndAttacking.aggressive && PatrolingAndAttacking.aggressionAgainst != null)
        {
            if (PatrolingAndAttacking.aggressionAgainst.transform.position.x < transform.position.x)
            {
                Vector3 newScale = transform.localScale;
                newScale.x = -1;
                transform.localScale = newScale;
            }
            else
            {
                Vector3 newScale = transform.localScale;
                newScale.x = 1;
                transform.localScale = newScale; 
            }
        }
        else if (rigidbody.velocity.x > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 1;
            transform.localScale = newScale;
        } 
        else if (rigidbody.velocity.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -1;
            transform.localScale = newScale;
        }
        if (Mathf.Abs(rigidbody.velocity.x) <= 0.05)
        {
            animator.SetBool(IsWalking, false);
        } 
        else if (rigidbody.velocity.x > 0.05)
        {
            animator.SetBool(IsWalking, true);
        }
        else
        {
            animator.SetBool(IsWalking, true);
        }
    }
}
