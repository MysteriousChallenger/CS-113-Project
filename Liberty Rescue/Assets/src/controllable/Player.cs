using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour, Controllable
{
    public MoveCurve moveCurve {get; set;} = new TopSpeedCurve(900f, 40f, 15f);
    [SerializeField] public float jumpForce {get; set;} = 900f;
    [SerializeField] public int extraJumpCount {get; set;} = 1;
    [SerializeField] public int extraJumpsRemaining {get; set;} = 0;
    public Vector2 facing {get; set;} = new Vector2(1,0);
    public Rigidbody2D body {get; set;}
    new public BoxCollider2D collider {get; set;} 
    public float HP {get; set;} = 100;
    public float HP_MAX {get; set;} = 100;

    public UnityEvent<float, float>  changeHP {get; set;} = new UnityEvent<float, float>();
    public Vector2? respawnPoint {get; set;} = null;

    public GameObject projectile;

    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = new Shotgun(projectile);
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

    public void Shoot(){
        gun.Shoot(this);
    }
}
