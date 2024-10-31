using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHW2 : MonoBehaviour
{
    
    Rigidbody myRigidbody;
    public float moveSpeed = 1.0f;
    public float jumpPower = 1.0f;
    public float chargeSpeed = 1.0f;
    public float sand = 1.0f;
    float totalJump;
    public float sprintSpeed = 1.0f;
    float Sprint;
    public Vector3 startingPlayerPosition;
    Vector3 Forward = new Vector3(0f, 0f, 1f);
    Vector3 Backward = new Vector3(0f, 0f, -1f);
    Vector3 Right = new Vector3(1f, 0f, 0f);
    Vector3 Left = new Vector3(-1f, 0f, 0f);
    Vector3 Up = new Vector3(0f, 1f, 0f);
    bool isWPressed = false;
    bool isSPressed = false;
    bool isDPressed = false;
    bool isAPressed = false;
    bool isSpacePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        totalJump = jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0f, 0f, 0f);
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isDPressed = Input.GetKey(KeyCode.D);
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isSpacePressed = Input.GetKeyDown(KeyCode.Space);
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        bool isPPressed = Input.GetKey(KeyCode.P);
        bool isFPressed = Input.GetKeyDown(KeyCode.F);

        if (isWPressed == true) {
            moveDirection = moveDirection + Forward;
        }
        if (isSPressed == true)
        {
            moveDirection = moveDirection + Backward;
        }
        if (isDPressed == true)
        {
            moveDirection = moveDirection + Right;
        }
        if (isAPressed == true)
        {
            moveDirection = moveDirection + Left;
        }
        moveDirection = moveDirection.normalized;
        if (isSpacePressed == true)
        {
            Rigidbody myRigidbody = GetComponent<Rigidbody>();
            myRigidbody.AddForce(Up * totalJump * sand, ForceMode.Impulse);
            totalJump = jumpPower;
        }
        if (isShiftPressed == true)
        {
            Sprint = sprintSpeed;
        }
        else
        {
            Sprint = 1.0f;
        }
        if (isPPressed == true)
        {
            totalJump = totalJump + chargeSpeed;
        }
        if (totalJump >= 3 * jumpPower)
        {
            totalJump = 3 * jumpPower;
        }
        if (isFPressed == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        transform.position = transform.position + moveDirection * moveSpeed * Sprint * Time.deltaTime * sand;
    }

        private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            transform.position = new Vector3(7f, 19f, -11f);
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            Debug.Log("why?");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sand"))
        {
            sand = 0.4f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boing"))
        {
            Rigidbody myRigidbody = GetComponent<Rigidbody>();
            myRigidbody.AddForce(Up * 10, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Sand"))
        {
            sand = 1.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
            {
                transform.position = startingPlayerPosition;
                Debug.LogWarning("There is no escape");
            }
        if (other.gameObject.CompareTag("PersonalSpace"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("NoPass"))
        {
            Rigidbody myRigidbody = GetComponent<Rigidbody>();
            myRigidbody.AddForce(Right * 3, ForceMode.Impulse);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            Destroy(other.gameObject);
        }
    }
}

