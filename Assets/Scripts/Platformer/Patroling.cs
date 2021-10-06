using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;

    [SerializeField] private float speed;

    [SerializeField] private Transform pointLeft;
    [SerializeField] private Transform pointRight;

    private bool movingLeft = false;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= pointLeft.transform.position.x)
        {
            movingLeft = false;
        } else if (gameObject.transform.position.x >= pointRight.transform.position.x)
        {
            movingLeft = true;
        }
        
        float moveBy = movingLeft? -speed : speed;
        myRigidBody.velocity = new Vector2(moveBy, myRigidBody.velocity.y);
    }
}
