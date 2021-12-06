using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBlock : PowerUpBlock
{
    void Start() {
        gun = new Shotgun(Resources.Load("prefab/Projectile", typeof(GameObject)) as GameObject);
    }
}
