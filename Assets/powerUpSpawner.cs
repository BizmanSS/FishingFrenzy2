using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    public GameObject powerUp;
    public float powerUpSpawnInterval;
    private float powerUpNextSpawnTime;


    void Start()
    {
        powerUpSpawnInterval = 20.0f;
        powerUpNextSpawnTime = Time.time + powerUpSpawnInterval;
    }


    void Update()
    {
        if (Time.time >= powerUpNextSpawnTime)
        {
            SpawnPowerUp();
            powerUpNextSpawnTime = Time.time + powerUpSpawnInterval;
        }
    }


    void SpawnPowerUp()
    {
        float xPosition = Random.Range(-13, 13);
        float chance = Random.Range(0f, 100f);

        if (chance <= 50f)
        {
            Instantiate(powerUp, new Vector3(xPosition, -22, 0), Quaternion.identity);
        }
    }
}