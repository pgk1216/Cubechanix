using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce;
    public float sidewaysForce;
    public float jumpForce;

    public float jumpCoolDown = 5f;
    public bool jumpIsOnCD = false;

    public float flashCoolDown = 5f;
    public bool flashIsOnCD = false;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool jump = false;
    private bool flashLeft = false;
    private bool flashRight = false;

    private bool isOnGround = false;

    private Vector3 forwardVector;

    void Start() {
        Debug.Log("Hello world!");
        rb = GetComponent<Rigidbody>();

        isOnGround = true;

        forwardVector = new Vector3(0, 0, forwardForce);
    }

    private void Update()
    {
        isMovingLeft = Input.GetKey("a");
        isMovingRight = Input.GetKey("d");
        jump = Input.GetKey("space");
        flashLeft = Input.GetKey("j");
        flashRight = Input.GetKey("l");
    }

    void FixedUpdate() {
        rb.AddForce(forwardVector);

        if (jumpIsOnCD) {
            jumpCoolDown -= Time.deltaTime;
            if (jumpCoolDown <= 0f) jumpIsOnCD = false;
        }
        if (jump && isOnGround) {
            if (!jumpIsOnCD) {
                rb.velocity = new Vector3(0, jumpForce, forwardForce / 3);
                isOnGround = false;

                // Jump cooldown
                jumpIsOnCD = true;
                jumpCoolDown = 5f;
            }
            else {
                Debug.Log("on cooldown");
            }
        }

        if (flashIsOnCD) {
            flashCoolDown -= Time.deltaTime;
            if (flashCoolDown <= 0f) flashIsOnCD = false;
        }
        if(flashLeft || flashRight) {
            if(!flashIsOnCD) {
                if(flashLeft) {
                    rb.position = new Vector3(rb.position.x - 5, rb.position.y, rb.position.z);
                }
                else if(flashRight) {
                    rb.position = new Vector3(rb.position.x + 5, rb.position.y, rb.position.z);
                }

                flashIsOnCD = true;
                flashCoolDown = 5f;
            }
        }

        if (isMovingLeft) {
            this.transform.Translate(-sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (isMovingRight) {
            this.transform.Translate(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }

    }
}
