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

    public LayerMask hurtableLayerMask { get; set; }

    [SerializeField] private Animator myAnimator;

    private bool movingLeft = false;
    private static readonly int Attack = Animator.StringToHash("Attack");

    public GameObject aggressionAgainst { get; set; }

    public bool aggressive { get; set; } = false;

    private bool attacking = false;

    private GameBools gameBools;

    public AudioSource audioSource;

    public AudioClip attackSound;

    private void Start()
    {
        gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();

        if (aggressive)
        {
            if (gameBools.Level3PrincessTarget)
            {
                aggressionAgainst = GameObject.Find("Princess");
            }
            else
            {
                aggressionAgainst = GameObject.Find("Dragon");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aggressive && aggressionAgainst != null)
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
        if (aggressive && aggressionAgainst != null && (Mathf.Abs(gameObject.transform.position.x - aggressionAgainst.transform.position.x) <=
                           rangeToHit))
        {
            if (!attacking)
            {
                audioSource.PlayOneShot(attackSound);
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
        Debug.Log("Attacking");
        myAnimator.SetTrigger(Attack);

        if (!aggressionAgainst.name.Equals("Player"))
        {
            yield return new WaitForSeconds(1);
        }

        Collider2D[] damagedObjects =
            Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, hurtableLayerMask);

        if (damagedObjects.Length > 0)
        {
            foreach (var damagedObject in damagedObjects)
            {
                Hurtable hurtable = damagedObject.gameObject.GetComponent<Hurtable>();
                hurtable.reduceHealth();
            }
        }

        yield return new WaitForSeconds(1);

        attacking = false;
    }
}