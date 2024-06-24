using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public int value;

    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandowForce(), ForceMode.Impulse);
        
        rb.AddTorque(RamdowTorque(), RamdowTorque(), RamdowTorque(), ForceMode.Impulse);
        transform.position = RandowSpawnPos();
    }
    Vector3 RandowForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RamdowTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandowSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);

            GameManager.instance.UpdateScore(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))
        {
            GameManager.instance.GameOver();
        }
    }
}
