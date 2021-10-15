using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;

    private void Awake() {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Airplane airplane;

    public float deltaSpeed = 5;
    public float deltaPitch = 1;
    public float deltaRoll = 1;
    public float deltaYaw = 60;
    public float timeAdjustment = 100f;
    public float mouseAdjustment = 10f;

    public float yawChange, pitchChange;

   
    void FixedUpdate()
    {
        HandleKeyboardInput();
        HandleMouseInput();
        UpdateElytraPhysics();
        UpdateProperties();
    }

    void HandleKeyboardInput() {
        if (Input.GetKey(KeyCode.Space)) {
            airplane.desiredSpeed += deltaSpeed * Time.deltaTime * timeAdjustment;
        }
    }

    void HandleMouseInput() {

        
        /*
        yawChange = Input.GetAxis("Mouse X");
        pitchChange = Input.GetAxis("Mouse Y");

        airplane.desiredYaw += yawChange * mouseAdjustment;
        airplane.desiredPitch += pitchChange * mouseAdjustment;
        */
    }

    void UpdateElytraPhysics() {
        Rigidbody airplaneRB = airplane.GetComponent<Rigidbody>();
        Vector3 vel = airplaneRB.velocity;

        float yawCos = Mathf.Cos(-airplane.yaw - Mathf.PI);
        float yawSin = Mathf.Sin(-airplane.yaw - Mathf.PI);
        float pitchCos = Mathf.Cos(airplane.pitch);
        float pitchSin = Mathf.Sin(airplane.pitch);

        float lookX = yawSin * -pitchCos;
        float lookY = -pitchSin;
        float lookZ = yawCos * -pitchCos;

        float hvel = Mathf.Sqrt(vel.x * vel.x + vel.z * vel.z);
        float hlook = pitchCos;
        float sqrPitchCos = pitchCos * pitchCos;

        vel.y += (-0.08f + sqrPitchCos * 0.06f);

        if (vel.y < 0 && hlook > 0) {
            float yacc = vel.y * -0.1f * sqrPitchCos;
            vel.y += yacc;
            vel.x += lookX * yacc / hlook;
            vel.z += lookZ * yacc / hlook;
        }

        if (pitchCos < 0) {
            float yacc = hvel * -pitchSin * 0.04f;
            vel.y += yacc * 3.5f;
            vel.x -= lookX * yacc / hlook;
            vel.z -= lookZ * yacc / hlook;
        }

        if (hlook > 0) {
            vel.x += (lookX / hlook * hvel - vel.x) * 0.1f;
            vel.z += (lookZ / hlook * hvel - vel.z) * 0.1f;
        }

        vel.x *= 0.99f;
        vel.y *= 0.98f;
        vel.z *= 0.99f;

        airplaneRB.velocity = vel;
    }

    void UpdateProperties() {
        airplane.desiredSpeed = Utils.Clamp(airplane.desiredSpeed, airplane.minSpeed, airplane.maxSpeed);
        airplane.yaw %= 360;
    }
}
