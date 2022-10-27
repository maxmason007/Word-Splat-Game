using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 28;
    private float maxSpeed = 36;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public int pointValue;
    public ParticleSystem explosionParticle;
    public bool targetHit = false;
    public int numberForWord;

    

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomXRange();

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameRunning)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MousePosition>().targetScript = gameObject;
            gameManager.UpdateScore(pointValue);
           
            Instantiate(explosionParticle, transform.position, transform.rotation);
            targetHit = true;
            gameManager.RecieveLetter(numberForWord);
            Destroy(gameObject);

        }
    }



    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomXRange()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

}