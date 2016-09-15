using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpHeight; 
    public Text countText;
    public Text winText;
    public bool gameStart;
    public int playerType; 

    private Rigidbody rb;
    private int count;
    private bool shouldJump; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = ""; 
    }
    void FixedUpdate()
    {
        if (playerType == 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            shouldJump = true;
            if (this.gameObject.transform.position.y > 0.5)
            {
                shouldJump = false;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 jump = new Vector3(0, 1, 0);

            rb.AddForce(movement * speed);


            if (Input.GetKeyDown("space") && shouldJump)
            {
                rb.AddForce(jump * jumpHeight);
            }
        }

        if (playerType == 1)
        {
            float moveHorizontal = 0;
            float moveVertical = 0;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveHorizontal = 1;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveHorizontal = -1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 1;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -1;
            }

            shouldJump = true;
            if (this.gameObject.transform.position.y > 0.5)
            {
                shouldJump = false;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 jump = new Vector3(0, 1, 0);

            rb.AddForce(movement * speed);


            if (Input.GetKeyDown(KeyCode.RightShift) && shouldJump)
            {
                rb.AddForce(jump * jumpHeight);
            }
        }

        if (playerType == 2)
        {
            float moveHorizontal = 0;
            float moveVertical = 0;

            if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal = 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal = -1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveVertical = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveVertical = -1;
            }

            shouldJump = true;
            if (this.gameObject.transform.position.y > 0.5)
            {
                shouldJump = false;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 jump = new Vector3(0, 1, 0);

            rb.AddForce(movement * speed);


            if (Input.GetKeyDown(KeyCode.LeftShift) && shouldJump)
            {
                rb.AddForce(jump * jumpHeight);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText(); 
        }

        if (other.gameObject.CompareTag("Outside"))
        {
            SceneManager.LoadScene("roll-a-ball");
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "You Win!"; 
        }
    }
    
}
