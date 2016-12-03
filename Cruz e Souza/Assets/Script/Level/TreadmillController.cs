using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TreadmillPoolSystem))]
public class TreadmillController : MonoBehaviour {

    public Transform spawnPosition;

    private TreadmillPoolSystem poolSystem;
    private TileController lastTile;

    void Start () {
        poolSystem = GetComponent<TreadmillPoolSystem>();
        spawnPosition.transform.position = spawnPosition.transform.position + new Vector3(0, 0, poolSystem.GetTotalLenght());
        lastTile = poolSystem.Initialize(spawnPosition.position);        
    }

    public int NumberOfTiles()
    {
        return this.poolSystem.poolSize;
    }
	
	public void ResetTile(TileController tile)
    {
        tile.transform.position = lastTile.transform.position + new Vector3(0, 0, (lastTile.GetLenght() / 2) + tile.GetLenght()/2);
        lastTile = tile;
    }

    private void InitializePoolSystem(int poolSize)
    {
        this.poolSystem.ClearObject();
        this.poolSystem.poolSize = poolSize;
        spawnPosition.transform.position = new Vector3(0, 0, poolSystem.GetTotalLenght());
        lastTile = poolSystem.Initialize(spawnPosition.position);
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InitializePoolSystem(2);            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InitializePoolSystem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InitializePoolSystem(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InitializePoolSystem(12);
        }
    }
}
