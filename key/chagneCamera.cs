using System.Data;
using Platformer;
using UnityEngine;

public class chagneCamera : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject Camera2;
    public GameObject rotable1;
    public GameObject rotable2;
    public GameObject ball1;
    public GameObject ball2;

    public float speed = 100f;

    private bool started = false;
    private Vector3 c1;
    private Vector3 c2;
    private Quaternion cc1;
    private Quaternion cc2;

    private void Start()
    {
        rotable1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        rotable2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        ball1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        ball2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        ball1.GetComponent<Transform>().GetPositionAndRotation(out c1,out cc1);
        ball2.GetComponent<Transform>().GetPositionAndRotation(out c2,out cc2);

        MainCamera.SetActive(true);
        Camera2.SetActive(false);
    }

    private void Update()
    {
        if (Player.GetComponent<PlayerController>().isOverc1 && Input.GetKeyDown(KeyCode.P))
        {
            MainCamera.SetActive(false);
            Camera2.SetActive(true);  
            Player.GetComponent<PlayerController>().enabled = false;
            started = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            MainCamera.SetActive(true);
            Camera2.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
            started = false;
        }

        if (started)
        {
            float horizontal = Input.GetAxis("Horizontal");

            float rotationAmount = horizontal * speed * Time.deltaTime;

            rotable1.GetComponent<Rigidbody2D>().transform.Rotate(0,0,-rotationAmount);
            rotable2.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, rotationAmount);

            if (Input.GetKeyDown(KeyCode.R))
            {
                ball1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                ball2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                ball1.transform.position = c1;
                ball2.transform.position = c2;
                rotable1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                rotable1.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);
                rotable2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                rotable2.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                ball1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                ball2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }
    }

}
