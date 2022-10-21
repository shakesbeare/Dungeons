using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Range(1, 4)]
    public int playerCount;
    public GameObject cameraPrefab;
    public Transform cameraControllerTransform;

    private List<Camera> cameras;  

    // Start is called before the first frame update
    void Start()
    {
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
