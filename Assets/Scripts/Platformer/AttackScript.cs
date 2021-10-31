using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private float attackRadius;
    public LayerMask hurtableLayerMask { get; set; }
    [SerializeField] private Animator animator;
    private static readonly int Attack = Animator.StringToHash("Attack");

    public bool canAttack = false;

    public AudioSource AudioSource;
    public AudioClip swordAttack;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canAttack)
        {
            AudioSource.PlayOneShot(swordAttack);
            animator.SetTrigger(Attack);
            Collider2D[] damagedObjects =
                Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, hurtableLayerMask);

            if (damagedObjects.Length > 0)
            {
                foreach (var damagedObject in damagedObjects)
                {
                    Hurtable hurtable = damagedObject.GetComponent<Hurtable>();
                    hurtable.reduceHealth();
                }
            }
        }
    }
}