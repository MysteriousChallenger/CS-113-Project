using UnityEngine;
public interface Controllable
{
    public Rigidbody2D body {get; set;}
    public BoxCollider2D collider {get; set;}
    public MoveCurve moveCurve {get; set;}
    public float jumpForce {get; set;}
    public int extraJumpCount {get; set;}
    public int extraJumpsRemaining {get; set;}

    public void Shoot();

}

public static class ControllableExtensions
{
    public static LayerMask GroundLayer = ~LayerMask.NameToLayer("ground");
    public static float MAX_FALL_SPEED = -54*20;

    public static void Jump(this Controllable controllable)
    {
        if (controllable.IsGrounded()) {
            controllable.body.velocity = new Vector2(controllable.body.velocity.x, controllable.jumpForce);
        }
        else if (controllable.extraJumpsRemaining > 0) {
            controllable.body.velocity = new Vector2(controllable.body.velocity.x, controllable.jumpForce);
            controllable.extraJumpsRemaining -= 1;
        }
    }

    public static void MoveHorizontal(this Controllable controllable, float x)
    {
        float acceleration = controllable.moveCurve.Acceleration(controllable.body.velocity.x, x);
        controllable.body.velocity += new Vector2(acceleration, 0);
    } 

    public static bool IsGrounded(this Controllable controllable) {
        RaycastHit2D raycast = Physics2D.BoxCast(
            origin: controllable.collider.bounds.center,  
            size: controllable.collider.bounds.size, 
            angle: 0, 
            direction: Vector2.down, 
            distance: 0.1f,
            layerMask: GroundLayer);
        return (raycast.collider != null);
    }

    public static void UpdateJumps(this Controllable controllable) {
        if (controllable.IsGrounded()) {
            controllable.extraJumpsRemaining = controllable.extraJumpCount;
        }
    }

    public static void EnforceMaxFallSpeed(this Controllable controllable) {
        controllable.body.velocity = new Vector2(controllable.body.velocity.x, Mathf.Max(controllable.body.velocity.y, MAX_FALL_SPEED));
    }

    public static void Respawn(this Controllable controllable, Vector2 respawnPoint) {
        controllable.body.velocity = new Vector2(0,0);
        controllable.body.transform.position = respawnPoint;
    }
} 