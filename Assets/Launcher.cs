using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bomb;
    Camera cam;
    public float launchForce = 1000f;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 1;
            Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
            GameObject b = Instantiate(bomb, worldPos, cam.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * launchForce);
        }
	}
}
