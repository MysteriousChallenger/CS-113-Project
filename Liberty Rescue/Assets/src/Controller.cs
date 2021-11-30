using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Controllable target;
    void Start()
    {
        target = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {


        target.UpdateJumps();
        if (Input.GetKeyDown(KeyCode.Space)) {
            target.Jump();
        }

        target.MoveHorizontal(Input.GetAxisRaw("Horizontal"));
    }
}
