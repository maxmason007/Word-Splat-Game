using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public ParticleSystem explosionParticle;
    public GameObject targetScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //targetScript = GameObject.Find("Target").GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {

        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
        if (Input.GetMouseButtonDown(0) && targetScript == null)
        {
            ShootExplosion();
        }
    }

    public void ShootExplosion()
    {
        
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Debug.Log("Button Clicked!!");
        
    }
}
