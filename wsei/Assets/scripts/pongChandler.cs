using System;
using JetBrains.Annotations;
using Platformer;
using UnityEngine;

public class pongChandler : MonoBehaviour
{
    public GameObject ball;
    public GameObject mainCamera;
    public GameObject crane;
    public GameObject cranedown;
    public GameObject ramp;
    public GameObject rampBoll;
    public float moveSpeed = 1f;

    private Rigidbody rb;
    private bool pongOn;
    private bool pongOver;
    private PlayerController playerController;
    private float targetSpeed = 10;
    private Camera mCamera;
    private Transform cranet;
    private float moveInput;
    private bool used;
    private Rigidbody2D rbRamp;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        mCamera = mainCamera.GetComponent<Camera>();
        cranet = crane.GetComponent<Transform>();
        rbRamp = ramp.GetComponent<Rigidbody2D>();
        rbRamp.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
    }

    private void Update()
    {
        if (pongOver && Input.GetKeyDown(KeyCode.E))
        {
            pongOn = true;
            playerController.enabled = false;
        }
        else if(pongOn && Input.GetKeyDown(KeyCode.Escape))
        {
            pongOn= false;
            playerController.enabled = true;
        }
        if (pongOn)
        {
            mCamera.orthographicSize = Mathf.Lerp(mCamera.orthographicSize,19,Time.deltaTime*targetSpeed);
            mCamera.GetComponent<CameraController>().enabled = false;
            mCamera.transform.position = new Vector2(20,-5);
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = cranet.right * moveInput;
                cranet.position = Vector3.MoveTowards(cranet.position, cranet.position + direction, moveSpeed * Time.deltaTime);
                //animator.SetInteger("playerState", 1); // Turn on run animation
            }
            if (Input.GetKeyDown(KeyCode.Space) && !used)
            {
                cranedown.SetActive(false);
                used = true;
            } else if (used && Input.GetKeyDown(KeyCode.R))
            {
                cranedown.SetActive(true);
                used = false;
                ball.GetComponent<Transform>().position = new Vector2(cranet.position.x,(float)(cranet.position.y - 3.24));
                ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                rbRamp.angularVelocity = 0f;
                ramp.transform.rotation = Quaternion.Euler(0,0,0);
                rampBoll.transform.position = new Vector2(ramp.transform.position.x, (float)(ramp.transform.position.y+2.2));
                rampBoll.GetComponent<Rigidbody2D>().linearVelocity= Vector2.zero;
            }
        }
        else
        {
            mCamera.orthographicSize = Mathf.Lerp(mCamera.orthographicSize,5, Time.deltaTime * targetSpeed);
            mCamera.GetComponent<CameraController>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pong")
        {
            pongOver = true;
            //Debug.Log(collision.gameObject.tag);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pong")
        {
            pongOver = false;
        }
    }
}
