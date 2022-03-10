using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHelicopter : MonoBehaviour
{   [SerializeField]
    public GameObject helicoptertoSpawn;
    Vector3 spawnlocation;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 3f);
        
    }

    void Spawn()
    {
        spawnlocation = Camera.main.transform.position + new Vector3(0, -10, 10);
        GameObject go = Instantiate(helicoptertoSpawn, spawnlocation, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
