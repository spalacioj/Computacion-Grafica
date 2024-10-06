using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 NextSpawnPoint;

    public void SpawnTile(bool spawnItem){
        GameObject temp = Instantiate(groundTile, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItem){
            temp.GetComponent<GroundTile>().spawnObstacle();
            temp.GetComponent<GroundTile>().spawnCoins();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 15; i++)
        {
           if(i < 3){
            SpawnTile(false);
           } else {
            SpawnTile(true);
           }
        }
    }

}
