using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol: Gun {
    public GameObject projectile;

    public Pistol(GameObject projectile) {
        this.projectile = projectile;
    }
    public void Shoot(Controllable controllable) {
        GameObject bullet = MonoBehaviour.Instantiate(projectile, controllable.body.transform.position, 
                                                     controllable.body.transform.rotation);

        bullet.GetComponent<Projectile>().Initialize(controllable.body.position, controllable.facing.normalized * 54 * 30, controllable);
    }
}