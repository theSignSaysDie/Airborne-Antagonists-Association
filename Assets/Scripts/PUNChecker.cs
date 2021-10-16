using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PUNChecker : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
