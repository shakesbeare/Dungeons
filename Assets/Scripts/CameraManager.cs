using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject cameraPrefab;
    public Transform cameraControllerTransform;

    private List<Camera> cameras;  
    private int playerCount;
    private PlayerManager playerManager;

    void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerManager.onCreatePlayers += OnCreatePlayers;

    }

    void OnCreatePlayers(object sender, PlayerManager.OnCreatePlayersArgs e) 
    {
        playerCount = e.playerCount;

        cameras = new List<Camera>();
        float cameraViewportX = 0f;
        float cameraViewportWidth = 1 / (float)playerCount;

        // Instantiate the cameras
        for (int i = 1; i <= playerCount; i++ )
        {
            GameObject cameraObject = Instantiate(cameraPrefab, Vector2.zero, Quaternion.identity);
            cameraObject.transform.parent = cameraControllerTransform;

            Camera camera = cameraObject.GetComponent<Camera>();
            camera.transform.position = new Vector3(0, 0, -1);
            
            // Viewport stuff
            camera.rect = new Rect(cameraViewportX, 0, cameraViewportWidth, 1);

            cameraViewportX += cameraViewportWidth;

            cameras.Add(camera);

            AudioListener audio = cameraObject.GetComponent<AudioListener>();
            if (i > 1)
            {
                audio.enabled = false;
            }
        }
    }

}
