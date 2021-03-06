﻿using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class CameraMultiFollow : MonoBehaviour {

    // TODO: Implement two more players, inspiration: http://nielson.io/2014/03/making-a-target-tracking-orthographic-camera-in-unity/
    // TODO: Implement camera bounds adjusting to viewport 

    public Transform[] players;
    public float distanceBeforeMoving;
    public float distanceBeforeZooming; 
    public float maxBend;
    public float minZoom = 10.0f; 
    public float maxZoom = 140.0f;
    public float defaultZoom = 60.0f;
    public Vector3 offset = Vector3.up; 

    private Vector3 m_middlePos; 
	
	void Update () {
        UpdateCameraPosition();
        UpdateCameraZoom(); 
	}

    void UpdateCameraPosition()
    {
        if (players[1] == null)
        {
            m_middlePos = players[0].position;
        }
        else
        {
            m_middlePos = (players[0].position + players[1].position) / 2.0f;
        }

        Vector3 nextCamPos = Vector3.Lerp(transform.position, m_middlePos + offset, Time.deltaTime);
        nextCamPos.z = -10.0f; 
        transform.position = nextCamPos; 
    }

    void UpdateCameraZoom()
    {

        if (players[1] == null)
        {
            Camera.main.fieldOfView = defaultZoom;
            return; 
        }

        float distanceBetweenPlayers = Vector3.Distance(players[0].position, players[1].position);

        if (distanceBetweenPlayers > distanceBeforeZooming)
        {
            float newFOV = distanceBetweenPlayers * 3;
            newFOV = Mathf.Clamp(newFOV, minZoom, maxZoom); 
            //Debug.Log(distanceBetweenPlayers + " , maxZoom: " + maxZoom);

            Camera.main.fieldOfView = newFOV; 
        }
    }

}
