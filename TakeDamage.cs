using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health;
    public float dmgamout;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= dmgamout;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
        
    }
}
