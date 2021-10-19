using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class PatrolingAndAttacking : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;

    [SerializeField] private float speed;

    [SerializeField] private float rangeToHit;

    [SerializeField] private Transform pointLeft;
    [SerializeField] private Transform pointRight;
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private float attackRadius;
    public int hurtableLayerMask { get; set; }

    [SerializeField] private Animator myAnimator;

    private bool movingLeft = false;
    private static readonly int Attack = Animator.StringToHash("Attack");

    public GameObject aggressionAgainst { get; set; }

    public bool aggressive { get; set; }

    private bool attacking = false;

    private void Start()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (aggressive)
        {
            if (gameObject.transform.position.x <= aggressionAgainst.transform.position.x)
            {
                movingLeft = false;
            }
            else if (gameObject.transform.position.x >= aggressionAgainst.transform.position.x)
            {
                movingLeft = true;
            }
        }
        else
        {
            if (gameObject.transform.position.x <= pointLeft.transform.position.x)
            {
                movingLeft = false;
            }
            else if (gameObject.transform.position.x >= pointRight.transform.position.x)
            {
                movingLeft = true;
            }
        }

        // ATTACK
        if (Mathf.Abs(gameObject.transform.position.x - aggressionAgainst.transform.position.x) <= rangeToHit)
        {
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(attack());
            }
        }
        // MOVE
        else
        {
            float moveBy = movingLeft ? -speed : speed;
            myRigidBody.velocity = new Vector2(moveBy, myRigidBody.velocity.y);
        }
    }

    private IEnumerator attack()
    {
        myAnimator.SetTrigger(Attack);
        
        Collider2D[] damagedObjects =
            Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, hurtableLayerMask);

        foreach (var damagedObject in damagedObjects)
        {
            Hurtable hurtable = damagedObject.GetComponent<Hurtable>();
            hurtable.reduceHealth();
        }
        
        yield return new WaitForSeconds(1);
        
        attacking = false;
    }
}