using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BasicEnemy : MonoBehaviour, Controllable
{
    public MoveCurve moveCurve {get; set;} = new TopSpeedCurve(600f, 40f, 15f);
    [SerializeField] public float jumpForce {get; set;} = 900f;
    [SerializeField] public int extraJumpCount {get; set;} = 1;
    [SerializeField] public int extraJumpsRemaining {get; set;} = 0;
    public Vector2 facing {get; set;} = new Vector2(1,0);
    public Rigidbody2D body {get; set;}
    new public BoxCollider2D collider {get; set;} 

    public float HP {get; set;} = 100;
    public float HP_MAX {get; set;} = 100;

    public UnityEvent<float, float>  changeHP {get; set;} = new UnityEvent<float, float>();

    public GameObject projectile;

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

    public void Shoot(){
        // GameObject bullet = Instantiate(projectile, transform.position, 
        //                                              transform.rotation);

        // bullet.GetComponent<Projectile>().Initialize(body.position, this.facing.normalized * 54 * 30);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Controllable controllable = collision.gameObject.GetComponent<Controllable>();
        if (controllable == null) {
            return;
        }

        if (controllable == GameObject.Find("player").GetComponent<Player>()) {

            controllable.SetHP(controllable.HP - 1);
            Vector2 direction = (this.body.position - controllable.body.position).normalized;
            direction += new Vector2(0,0.3f);
            this.body.velocity += direction * 2000;
            if (controllable.HP == 0) {
                Destroy(collision.gameObject);
            }
        }
    }
}
