using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour, Controllable
{
    public MoveCurve moveCurve {get; set;} = new TopSpeedCurve(15f, 40f, 20f);
    [SerializeField] public float jumpForce {get; set;} = 20f;
    [SerializeField] public int extraJumpCount {get; set;} = 1;
    [SerializeField] public int extraJumpsRemaining {get; set;} = 0;
    public Rigidbody2D body {get; set;}
    new public BoxCollider2D collider {get; set;} 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Awake is called when a GameObject is activated or loaded into a scene or instantiated
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
