using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravity;
    public bool onGround;
    private Animator playerAnim;
    public bool gameOver = false;
    public AudioClip jump;
    public AudioClip crash;
    private float speed_f;
    private float speed = 2;
    public bool run;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim.SetFloat("Speed_f", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.5 ||horizontalInput<0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                MoveChar(horizontalInput, true);
            }
            else
            {
                MoveChar(horizontalInput);
            }
        } else
        {
            playerAnim.SetFloat("Speed_f", 0f);
        }
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&horizontalInput==0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && horizontalInput == 0)
        {
            transform.rotation = Quaternion.Euler(0,-180, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jump, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("game Over des");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crash, 1.0f);
        }
    }
    private void MoveChar(float input)
    {
        speed = 4;
        transform.rotation = Quaternion.Euler(0, 90, 0);
        playerAnim.SetFloat("Speed_f", 0.3f);
        playerRb.transform.Translate(Vector3.forward * speed * input * Time.deltaTime);
    }
    private void MoveChar(float input,bool run)
    {
        speed = 6;
        transform.rotation = Quaternion.Euler(0, 90, 0);
        playerAnim.SetFloat("Speed_f", 0.6f);
        playerRb.transform.Translate(Vector3.forward * speed * input * Time.deltaTime);
    }
}
