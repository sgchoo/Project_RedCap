using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Explosion;
    public float destroy = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion;
        explosion = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(explosion, destroy);
        transform.DetachChildren();
        Destroy(gameObject);

    }



}
