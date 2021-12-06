using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    private Controllable parent;
    void Start()
    {
    }

    public void Initialize(Vector2 position, Vector2 velocity, Controllable parent, float lifetime = 2f) {
        this.gameObject.SetActive(true);
        this.body = GetComponent<Rigidbody2D>();
        this.body.position = position;
        this.body.velocity = velocity;
        this.parent = parent;
        GetComponent<Transform>().parent = null;
        Destroy(this.gameObject, lifetime);
        Physics2D.IgnoreCollision(parent.collider, GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Controllable controllable = collision.gameObject.GetComponent<Controllable>();
        if (controllable == null) {
            Destroy(this.gameObject); 
            return;
        }

        controllable.SetHP(controllable.HP - 40);
        if (controllable.HP == 0) {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
