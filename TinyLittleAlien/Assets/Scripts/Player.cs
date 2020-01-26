using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameOverScreen;
    public float speed;
    public int health;
    
    private float input;

    Rigidbody2D rb;
    Animator anim;

    public Text healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = health.ToString();
    }

    private void Update()
    {
        if (input != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        //player facing right (rotate the player)
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player input
        input = Input.GetAxisRaw("Horizontal");
        
        //moving the player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
