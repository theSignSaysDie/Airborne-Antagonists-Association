using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePhysics : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        airplane.position = transform.localPosition;
    }

    public Airplane airplane;
    public Vector3 rotation = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        NormalizeRotation();

        UpdateSpeed();
        UpdateRoll();
        UpdatePitch();
        UpdateYaw();

        UpdateVelocity();
        UpdatePosition();
        UpdateRotation();
    }

    void UpdateSpeed() {
        airplane.speed = Utils.UpdateValue(airplane.speed, airplane.desiredSpeed, airplane.acceleration);
        airplane.speed = Utils.Clamp(airplane.speed, airplane.minSpeed, airplane.maxSpeed);
    }

    void UpdateRoll() {
        airplane.roll = Utils.UpdateValue(airplane.roll, airplane.desiredRoll, airplane.rollSpeed);
        airplane.roll = Utils.Clamp(airplane.roll, airplane.minRoll, airplane.maxRoll);
    }

    void UpdatePitch() {
        airplane.pitch = Utils.UpdateValue(airplane.pitch, airplane.desiredPitch, airplane.pitchSpeed);
        airplane.pitch = Utils.Clamp(airplane.pitch, airplane.minPitch, airplane.maxPitch);
    }

    void UpdateYaw() {
        airplane.yaw = Utils.UpdateValue(airplane.yaw, airplane.desiredYaw, airplane.yawSpeed);
    }

    void UpdateVelocity() {
        airplane.velocity.x = airplane.speed * Mathf.Sin(airplane.yaw * Mathf.Deg2Rad);
        airplane.velocity.y = 0;
        airplane.velocity.z = airplane.speed * Mathf.Cos(airplane.yaw * Mathf.Deg2Rad);
        // TODO Update with glider physics
    }

    void UpdatePosition() {
        airplane.position += airplane.velocity * Time.deltaTime;
        transform.localPosition = airplane.position;
    }

    void UpdateRotation() {
        rotation.x = airplane.roll;
        rotation.y = airplane.yaw;
        rotation.z = airplane.pitch;
        transform.localEulerAngles = rotation;
    }

    void NormalizeRotation() {
        airplane.roll %= 360;
        airplane.desiredRoll %= 360;
        airplane.pitch %= 360;
        airplane.desiredPitch %= 360;
        airplane.yaw %= 360;
        airplane.desiredYaw %= 360;
    }

}
