using UnityEngine;
using System.Collections;

public class EnemyDamager : MonoBehaviour {

    public GameObject deathParticles;
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyControl>().TakeDamage(damage);
            Destroy(this.gameObject);   
        }
    }
}
