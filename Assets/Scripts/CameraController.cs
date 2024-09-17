//Author: Josiah Ayres
//Date: 9/17/2024
//Set camera orientation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Place camera on player
        transform.position = player.transform.position + offset;
    }
}
