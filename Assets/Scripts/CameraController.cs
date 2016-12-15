﻿using UnityEngine;
using System.Collections;

/**
 * this CameraController class handles the camera movement 
 * the camera follows the player from a set distance called an offset
 * @Author: Jonathan Fils-Aime, Steve Hogue
 */
public class CameraController : MonoBehaviour 
{
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // called after update in each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
