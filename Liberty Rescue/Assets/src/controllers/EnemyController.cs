using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Controllable character;
    private Controllable player;
    private Vector2 screenCoords;

    private State state;

    public UnityEvent<int, int> changeScreenEvent;

    private bool awake = false;

    enum State {
        STATE_RUSHING,
        STATE_LEAPING_INIT,
        STATE_LEAPING,
    }
    void Start()
    {
        character = GetComponent<Controllable>();
        player = GameObject.Find("player").GetComponent<Player>();
    }

    public void Initialize(Vector2 position) {
        this.awake = true;
        this.gameObject.SetActive(true);
        character = GetComponent<Controllable>();
        player = GameObject.Find("player").GetComponent<Player>();
        this.character.body.position = position;
        this.character.facing = new Vector2(
            Math.Sign(
                (player.body.transform.position - character.body.transform.position).x
            ), 
            0
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (awake) {
            UpdateCharacterControls(character);
        }
    }

    void UpdateCharacterControls(Controllable character) {

        character.UpdateJumps();

        switch (this.state) {
            case State.STATE_RUSHING:
                if (UnityEngine.Random.Range(0f,1) < 1/15f ) {
                    character.MoveHorizontal(
                        Math.Sign(
                            (player.body.transform.position - character.body.transform.position).x
                        )
                    );
                } else if (UnityEngine.Random.Range(0f,1) < 1/20f ) {
                    this.state = State.STATE_LEAPING_INIT;
                    character.MoveHorizontal(Math.Sign(character.facing.x));
                } else {
                    character.MoveHorizontal(Math.Sign(character.facing.x));
                }
                break;
            
            case State.STATE_LEAPING:
                character.MoveHorizontal(Math.Sign(character.facing.x));
                // STATE_LEAPING_INIT triggers timers that change from STATE_LEAPING to STATE_RUSHING
                break;

            case State.STATE_LEAPING_INIT:
                IEnumerator JumpAgain() {
                    yield return new WaitForSeconds(0.3f);
                    character.Jump();
                    yield return new WaitForSeconds(0.7f);
                    state = State.STATE_RUSHING;
                }

                IEnumerator Land() {
                    yield return new WaitForSeconds(0.6f);
                    state = State.STATE_RUSHING;
                }

                state = State.STATE_LEAPING;
                character.Jump();
                if (UnityEngine.Random.Range(0f,1) < 1/3f ) {
                    StartCoroutine(JumpAgain());
                } else {
                    StartCoroutine(Land());
                }
                character.MoveHorizontal(Math.Sign(character.facing.x));
                break;

            default:
                break;
                
        }

        character.EnforceMaxFallSpeed();
    }

}