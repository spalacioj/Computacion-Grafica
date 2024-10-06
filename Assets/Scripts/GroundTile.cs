using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit (Collider other){
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void spawnObstacle(){

        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < tallObstacleChance){
            obstacleToSpawn = tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn object
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);   
    }

    public void spawnCoins(){
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = getRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 getRandomPointInCollider(Collider collider){
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point)){
            point = getRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
