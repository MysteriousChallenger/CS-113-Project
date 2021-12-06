using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBlock : PowerUpBlock
{
    void Start() {
        gun = new Pistol(Resources.Load("prefab/Projectile", typeof(GameObject)) as GameObject);
    }
}
