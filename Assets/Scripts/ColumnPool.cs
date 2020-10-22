using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 1;
    public GameObject columnPrefab;
    public GameObject column2Prefab;
    public float columnMin = -2.9f;
    public float columnMax = 1.4f;
    private float spawnXPosition = 10f;
	int i,num;
    private GameObject[] columns;
    private Vector3 objectPoolPosition = new Vector3(-14, 0,0.8f);

    private float timeSinceLastSpawned;
    public float spawRate;
    private int currentColumn;

	// Use this for initialization
	void Start () {
		
        columns = new GameObject[columnPoolSize];
        
		for(;i<columnPoolSize; i++)
		{
			columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            num++;
		}

        SpawnColumn();
    }
	
	// Update is called once per frame
	void Update () {
			
		timeSinceLastSpawned += Time.deltaTime;	
		if(!GameController.instance.gameOver && timeSinceLastSpawned >= spawRate)
		{
			timeSinceLastSpawned = 0;
			SpawnColumn();
		}
		for(;i<columnPoolSize; i++)
		{
            if (num != 6)
            {
                columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
                num++;
            }
            else
            {
                num = 0;
                columns[i] = Instantiate(column2Prefab, objectPoolPosition, Quaternion.identity);
                
            }
        }

        

	}

    void SpawnColumn()
    {
        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector3(spawnXPosition, spawnYPosition,0.8f);

        currentColumn++;
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
			i = 0;
        }
    }
}
