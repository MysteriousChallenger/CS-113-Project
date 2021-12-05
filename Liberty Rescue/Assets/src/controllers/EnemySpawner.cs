using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    private bool active = false;

    public GameObject spawnTarget;

    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        StartCoroutine(SpawnLoop());
    }


    IEnumerator SpawnLoop() {
        while (true) {
            yield return new WaitForSeconds(2f);
            if (active) {
                GameObject spawn = Instantiate(spawnTarget, transform.position, 
                                                        transform.rotation);
                spawn.GetComponent<EnemyController>().Initialize(this.transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("player").GetComponent<Transform>().position - transform.position).magnitude < 3000) {
            active = true;
        } else {
            active = false;
        }
    }
}
