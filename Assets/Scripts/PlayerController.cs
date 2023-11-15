using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
     [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] float horsePower = 0f;
    [SerializeField] float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    [SerializeField] float initialForce = 2000f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //if the vehicle is stopped an initial impulse force is initiated to get the vehicle moving
            if (speed==0)
            {
                playerRb.AddRelativeForce(Vector3.forward * initialForce * forwardInput, ForceMode.Impulse);
            }
            // Move the vehicle forward based on verticle input
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput); 
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
            // Calculate Speed and update GUI
            speed=Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");
            // Calculate RPM and update GUI 
            rpm=Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
        
     }
bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }

}
