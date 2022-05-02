using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroids;
    public int _asteroid_count;
    // Start is called before the first frame update
    void Start()
    {
        this._asteroid_count = 200;
        float x,y,z;
        for(int i = 0; i<_asteroid_count; i++){
            x = Random.Range(-50.0f, 50.0f);
            y = Random.Range(-50.0f, 50.0f);
            z = Random.Range(-50.0f, 50.0f);
            Instantiate(asteroids[Random.Range(0,asteroids.Length)], new Vector3(x,y,z), this.transform.rotation);
        }
        
    }
}
