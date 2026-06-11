using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Asteroid_S;
    public GameObject Asteroid_M;
    public GameObject Asteroid_L;
    public float spawnRate;
    private float timer = 0;
    private float xPos;
    private float yPos;
    private int edge;
    private AsteroidSize size;

    void Start()
    {

    }

    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnAsteroid();
            timer = 0;
        }
    }

    void SpawnAsteroid()
    {
        DeterminePosition();
        GameObject asteroidType = DetermineSize();
        GameObject asteroid = Instantiate(asteroidType, new Vector3(xPos, yPos, 0), Quaternion.identity);
        asteroid.GetComponent<AsteroidScript>().init(edge, size);
    }

    void DeterminePosition()
    {
        // Select random edge of screen (N, E, S, W) and set asteroid's x and y position
        edge = Random.Range(0,4);
        switch (edge)
        {
            case 0: // North
                xPos = Random.Range(-CameraScript.width, CameraScript.width);
                yPos = CameraScript.height;
                break;
            case 1: // East
                xPos = CameraScript.width;
                yPos = Random.Range(-CameraScript.height, CameraScript.height);
                break;
            case 2: // South
                xPos = Random.Range(-CameraScript.width, CameraScript.width);
                yPos = -CameraScript.height;
                break;
            case 3: // West
                xPos = -CameraScript.width;
                yPos = Random.Range(-CameraScript.height, CameraScript.height);
                break;
        }
    }

    GameObject DetermineSize()
    {
        float i = Random.Range(0f,1f);
        if (i <= 0.2) 
        {
            size = AsteroidSize.Small;
            return Asteroid_S;
        } 
        else if (i > 0.2 && i <= 0.8)
        {
            size = AsteroidSize.Medium;
            return Asteroid_M;
        } 
        else
        {
            size = AsteroidSize.Large;
            return Asteroid_L;
        }
    }

    public void SpawnFragments(Vector3 position, AsteroidSize size)
    {
        if (size == AsteroidSize.Small) return;

        GameObject prefab = (size == AsteroidSize.Large) ? Asteroid_M : Asteroid_S;

        for (int i = 0; i < 2; i++)
        {
            GameObject frag = Instantiate(prefab, position, Quaternion.identity);
            frag.GetComponent<AsteroidScript>().init(-1, (AsteroidSize)((int)size - 1), Random.insideUnitCircle.normalized * 3f);
        }
    }
}
