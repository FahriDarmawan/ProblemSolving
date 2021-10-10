using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 350f;
    [SerializeField] private MovementMethod movementMethod;
    [SerializeField] private Scene scene;

    public Text bulletText;

    public GameObject bulletObj;
    public GameObject GameOverPanel;

    int totalBullet;

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

        //shoot bullet
        if(Input.GetMouseButtonDown(0))
        {
            if(totalBullet > 0)
            {
                Instantiate(bulletObj, transform.position, Quaternion.identity);
                totalBullet--;
            }
        }

        if(scene == Scene.NINE)
        {
            bulletText.text = totalBullet.ToString();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            totalBullet++;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameOverPanel.SetActive(true);
        }
    }
}

public enum MovementMethod
{
    AUTO,
    KEYBOARD_CONTROLLER,
    MOUSE_CONTROLLER
}
