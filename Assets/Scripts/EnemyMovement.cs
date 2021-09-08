using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    bool isFacingRight = true;
    int direction;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (isFacingRight ? 1 : -1);
        Move();
    }

    private void Move()
    {
        transform.localScale = new Vector2(direction, transform.localScale.y);
        float velX = direction * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + velX, transform.position.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFacingRight = !isFacingRight;
    }
}
