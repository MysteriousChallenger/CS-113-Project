using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun: Gun {
    public GameObject projectile;

    public float cooldown = 0.3f;

    public bool waitingForCooldown = false;

    public Shotgun(GameObject projectile) {
        this.projectile = projectile;
    }
    public void Shoot(Controllable controllable) {
        if (!waitingForCooldown) {
            for (int i = 0; i < 8; i++) {
                GameObject bullet = MonoBehaviour.Instantiate(projectile, controllable.body.transform.position, 
                                                        controllable.body.transform.rotation);

                bullet.GetComponent<Projectile>().Initialize(controllable.body.position, controllable.facing.normalized * 54 * 34 + RandomOffset() * 54 * 8, controllable, 0.2f);
            }
            waitingForCooldown = true;

            IEnumerator waitForCooldown() {
                yield return new WaitForSeconds(cooldown);
                waitingForCooldown = false;
            }
            CoroutineController.Start(waitForCooldown());
        }
    }

    private Vector2 RandomOffset() {
        return new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
    }
}