using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSelect : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D body;
    BoxCollider2D collider;

    LevelTrigger? level = null;


    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 54 * 10, Input.GetAxisRaw("Vertical") * 54 * 10);

        if (level is LevelTrigger realLevel && Input.GetKeyDown(KeyCode.C)) {
            realLevel.ChooseLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        LevelTrigger level = collision.gameObject.GetComponent<LevelTrigger>();
        if (level != null) {
            this.level = level;
        }
        ShowText text = collision.gameObject.GetComponent<ShowText>();
        if (text != null) {
            text.ToggleText();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        LevelTrigger level = collision.gameObject.GetComponent<LevelTrigger>();
        if (level != null) {
            this.level = null;
        }
        ShowText text = collision.gameObject.GetComponent<ShowText>();
        if (text != null) {
            text.ToggleText();
        }
    }
}
