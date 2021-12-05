using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Controllable character;
    private Vector2 screenCoords;


    public UnityEvent<int, int> changeScreenEvent;
    void Start()
    {
        character = GameObject.Find("player").GetComponent<Player>();
        screenCoords = ScreenCoords(character.collider.bounds.center);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterControls(character);
        UpdateScreenLocation(character);
        
    }

    void UpdateCharacterControls(Controllable character) {
        character.UpdateJumps();

        if (Input.GetKeyDown(KeyCode.Space)) {
            character.Jump();
        }

        character.MoveHorizontal(Input.GetAxisRaw("Horizontal"));
        character.EnforceMaxFallSpeed();
    }

    void UpdateScreenLocation(Controllable character) {
        if (screenCoords != ScreenCoords(character.collider.bounds.center)) {
            screenCoords = ScreenCoords(character.collider.bounds.center);
            changeScreenEvent.Invoke((int)screenCoords.x, (int)screenCoords.y);
        }
    }

    Vector2 ScreenCoords(Vector2 spaceCoords) {
        float x = spaceCoords.x;
        float y = spaceCoords.y;

        int screen_x = (int)Math.Floor((x / Constants.CAMERA_VIEWPORT_WIDTH) + 0.5);
        int screen_y = (int)Math.Floor((y / Constants.CAMERA_VIEWPORT_HEIGHT) + 0.5);

        return new Vector2(screen_x, screen_y);
    }
}
