using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Vector3 position = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    public Rigidbody rb;

    // VARIABLE
    public float speed;
    public float desiredSpeed;
    public float roll = 0;
    public float desiredRoll = 0;
    public float yaw;
    public float desiredYaw;
    public float pitch;
    public float desiredPitch;

    // CONST
    public float acceleration = 5;
    public float rollSpeed = 5;     // Side-to-side         ROLL
    public float pitchSpeed = 10;    // Up and down          PITCH
    public float yawSpeed = 120;      // Turning left/right   YAW
    public float maxSpeed = 5;
    public float minSpeed = 0;
    public float minRoll = -5;
    public float maxRoll = 365;
    public float minPitch = -180;
    public float maxPitch = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
