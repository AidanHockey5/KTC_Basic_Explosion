using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float boomTime = 5f;
    public float power = 10f;
    public float radius = 10f;
    public GameObject explosionPtc;
    public AudioClip explosionSound;
	// Use this for initialization
	void Start ()
    {
        Invoke("Explosion", boomTime);
	}
	
    void Explosion()
    {
        Vector3 expPosition = transform.position;
        Collider[] cols = Physics.OverlapSphere(expPosition, radius);
        foreach (Collider hit in cols)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, expPosition, radius, 3.0F);
        }
        GameObject ptc = Instantiate(explosionPtc, gameObject.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, gameObject.transform.position);
        Destroy(ptc, 10f);
        Destroy(gameObject);
    }
}
