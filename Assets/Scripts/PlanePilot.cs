using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlanePilot : MonoBehaviourPunCallbacks
{
    public float speed = 90.0f;
    public float minSpeed = 35.0f;
    public float sensitivity = 0.3f;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pilot script added to " + gameObject.name);
        Cursor.lockState = CursorLockMode.Locked;

        if(!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update() {
        if (photonView.IsMine)
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 20.0f + Vector3.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime * 50f;

        speed = Mathf.Max(speed, minSpeed);

        transform.Rotate(Input.GetAxis("Vertical") * sensitivity, 0.0f, -Input.GetAxis("Horizontal") * sensitivity);
    }
}
