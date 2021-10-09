using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 350f;
    [SerializeField] private MovementMethod movementMethod;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if(movementMethod == MovementMethod.AUTO)
        {
            Vector2 ballDir = RandomDir();
            PushBall(ballDir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get input keyboard
        Vector2 keyboardInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if(movementMethod == MovementMethod.KEYBOARD_CONTROLLER)
        {
            PushBall(keyboardInput);
        }

        if(movementMethod == MovementMethod.MOUSE_CONTROLLER)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 5 * Time.deltaTime);
        }
    }

    private void PushBall(Vector2 direction)
    {
        rigidbody2D.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private Vector2 RandomDir()
    {
        Vector2 randomDirection = new Vector2(Random.value, Random.value).normalized;
        return randomDirection;
    }
}

public enum MovementMethod
{
    AUTO,
    KEYBOARD_CONTROLLER,
    MOUSE_CONTROLLER
}
