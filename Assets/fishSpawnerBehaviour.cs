using UnityEngine;

public class fishSpawnerBehaviour : MonoBehaviour
{
    public GameObject normalfish; //original fish object (its a prefab) used to make clones
    public GameObject pufferfish; // Puffer Fish
    public GameObject squid; // Squid
    public float fishSpawnInterval; //interval on which fish spawn
    private float fishNextSpawnTime; //nextSpawnTime of a fish


    void Start()
    {
        fishSpawnInterval = 2.0f; //interval on which fish spawn (equal to 2)
        fishNextSpawnTime = speedMultiplier.Instance.elapsedTime + fishSpawnInterval; //next spawn is the next time when we will spawn a fish
    }


    void Update()
    {
        if (speedMultiplier.Instance.elapsedTime >= fishNextSpawnTime) //if the time is more or equal to nextSpawnTime, we make a new fish
        {
            float adjChance = Random.Range(-1f, 1f); //random chance element to make the following spawnTime 1 second more or less
            SpawnFish(); //spawn a new fish
            fishNextSpawnTime = (speedMultiplier.Instance.elapsedTime + (fishSpawnInterval / speedMultiplier.Instance.speedMult) + adjChance / fishSpawnInterval / speedMultiplier.Instance.speedMult); //calculate nextSpawnTime
        }
    }


    void SpawnFish()
    {
        float xPosition = Random.Range(-13, 13); //xPosition of the next fish (random between -13, 13)
        float chance = Random.Range(0f, 100f); //will be used to determine if 1 or two fish spawn this time
        float chanceFishType = Random.Range(0f, 100f); //will be used to determine which fish type to spawn
        GameObject fishInstance1; //will hold a new fish instance gameobject, so we can get the sprite
        SpriteRenderer fishSprite1; //will hold the sprite of that gameobject
        GameObject fishInstance2; //will hold a new fish instance gameobject, so we can get the sprite
        SpriteRenderer fishSprite2; //will hold the sprite of that gameobject
        GameObject fish;

        if(chanceFishType <= 8f) //8% chance for squid
        {
            fish = squid;

        }
        else if(chanceFishType <= 23f) //15% chance for puffer fish
        {
            fish = pufferfish;
        }
        else //77% chance for normal fish
        {
            fish = normalfish;
        }
        if (chance <= 25f) //25% chance to spawn 2 fish at this time
        {
            fishInstance1 = Instantiate(fish, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new fish
            fishSprite1 = fishInstance1.GetComponent<SpriteRenderer>(); //get the fishes sprite
            fishSprite1.flipX = Random.Range(0, 2) == 0; //50% chance to spawn flipped

            xPosition = Random.Range(-13, 13); //recalculate a random xPosition forthe second fish
            fishInstance2 = Instantiate(fish, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new fish
            fishSprite2 = fishInstance2.GetComponent<SpriteRenderer>(); //get the fishes sprite
            fishSprite2.flipX = Random.Range(0, 2) == 0; //50% chance to spawn flipped
        }
        else //75% chance to spawn 1 fish at this time
        {
            fishInstance1 = Instantiate(fish, new Vector3(xPosition, -22, 0), Quaternion.identity); //create new fish
            fishSprite1 = fishInstance1.GetComponent<SpriteRenderer>(); //get the fishes sprite
            fishSprite1.flipX = Random.Range(0, 2) == 0; //50% chance to spawn flipped
        }
    }
}