using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CameraControl : MonoBehaviour
{
    Vector2 screenCoords;
    new Transform transform;
    void Start(){
        screenCoords = new Vector2(0,0);
        transform = GetComponent<Transform>();
        InitCameraAspectRatio();
        InitCameraPosition();
        HandleScreenChangeEvent();
    }

    void InitCameraAspectRatio() {

        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / Constants.CAMERA_ASPECT_RATIO;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        camera.orthographicSize = Constants.CAMERA_VIEWPORT_SIZE;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {  
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            
            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    void InitCameraPosition(){
        //transform.position = new Vector3(0,0,-10);
    }

    void HandleScreenChangeEvent() {
        PlayerController globalController = GameObject.Find("global").GetComponent<PlayerController>();
        globalController.changeScreenEvent.AddListener(OnNewScreen);
    }
    
    public void OnNewScreen(int x, int y){
        transform.position = new Vector3(x * Constants.CAMERA_VIEWPORT_WIDTH, y * Constants.CAMERA_VIEWPORT_HEIGHT, -10);
    }
}

