using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        public GameObject GM;
        private float moveInput;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        public bool isGrounded;
        public bool isOverLadder = false;
        public Transform groundCheck;
        [SerializeField] private string groundTag = "Ground"; //Tag pod³ogi

        private Rigidbody2D rigidbody;
        public Animator animator;
        private GameManager gameManager;
        

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GM.GetComponent<GameManager>();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetTrigger("move"); // Turn on run animation
                
            }
            else
            {
                animator.ResetTrigger("move"); // Turn on idle animation
            }
            if (Input.GetButton("Vertical") && isOverLadder)
            {
                moveInput = Input.GetAxis("Vertical");
                Vector3 direction = transform.up * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isOverLadder)
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                if (!isGrounded)
                {
                    animator.SetTrigger("jump");
                }
                else if (isGrounded)
                {
                    animator.ResetTrigger("jump");
                }
                if (facingRight == false && moveInput > 0)
                {
                    Flip();
                }
                else if (facingRight == true && moveInput < 0)
                {
                    Flip();
                }
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }else{
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }else if (other.gameObject.tag == "ladder")
            {
                isOverLadder = true;
                rigidbody.linearVelocity = Vector2.zero; 
            }
            else if (other.CompareTag(groundTag))
            {
                isGrounded = true;  // Resetujemy licznik skoków, gdy gracz dotknie ziemi
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "ladder")
            {
                isOverLadder = false;
                rigidbody.linearVelocity = Vector2.zero;

            }
            else if (other.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}
