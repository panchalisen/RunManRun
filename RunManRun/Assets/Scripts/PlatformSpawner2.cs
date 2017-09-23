using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner2 : MonoBehaviour {

	//public GameObject platform1;
	//public GameObject platform2;
	//public GameObject platform3;
	//public GameObject platform4;
	public GameObject platform;
	public GameObject platformEnd;

	public GameObject energyBalls1;
	public GameObject energyBalls2;
	public GameObject energyBalls3;
	public GameObject energyBalls4;

	Vector3 lastPos;
	bool lastPosIsSpawnedZ;

	float platformSizeX;
	float platformSizeZ;


	public bool gameOver;
	public int platformCount;

	int rand;
	int level;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {

	
		platformCount = 0;
		level = UIManager2.instance.level;

		lastPos = platform.transform.position;
		lastPosIsSpawnedZ = true;

		platformSizeX = platform.transform.localScale.x;
		platformSizeZ = platform.transform.localScale.z;


		for (int i = 1; i <= 10; i++) {
			SpawnPlatforms ();
		}


	}

	public void startSpawning()
	{

		InvokeRepeating ("SpawnPlatforms",0.1f,0.2f);
	}

	// Update is called once per frame
	void Update () {
		if (GameManager2.instance.gameOver)
			stopSpawning ();
	}

	public void stopSpawning()
	{
		CancelInvoke ("SpawnPlatforms");
	}


	void SpawnPlatforms () {



		rand= Random.Range (0, 6);



		if (rand < 3) {
			SpawnX ();

		} else if (rand >= 3) {
			SpawnZ ();

		}


		platformCount += 1;


		switch (level) {
		//6:4:3:2 ..60
		case 1:
			if (platformCount == 10) 
				loadLastPlatform ();
			break;
		case 2:
			if (platformCount == 10) 
				loadLastPlatform ();
			break;
		case 3:
			if (platformCount == 10) 
				loadLastPlatform ();
			break;

		case 4:
			if (platformCount == 10) 
				loadLastPlatform ();
			break;

		}
			
	}

	public void loadLastPlatform()
	{
		Vector3 pos = new Vector3(lastPos.x-1,lastPos.y,lastPos.z);
		pos.x += platformSizeX;
		platformEnd.transform.position = pos;
		//Instantiate (platformEnd, pos,  Quaternion.Euler(0,90,0));
		CancelInvoke ("SpawnPlatforms");
	}



	void SpawnX()
	{
		//Vector3 pos = lastPos;

		Vector3 pos = new Vector3(lastPos.x,lastPos.y,lastPos.z);
		//pos.x += platformSizeX;

		if(lastPosIsSpawnedZ)
		{
			pos.x+=(platformSizeX/2)+(platformSizeZ/2);
			pos.z += (platformSizeZ / 2) - (platformSizeX / 2);
			lastPosIsSpawnedZ = false;
		}
		else
		{
			pos.x += platformSizeZ;
			lastPosIsSpawnedZ = false;
			
		}
			
		lastPos = pos;
		Instantiate (platform, pos,  Quaternion.Euler(0,90,0));
		spawnEnergyBalls (pos);	
	}


	void SpawnZ()
	{
		//Vector3 pos = lastPos;
		Vector3 pos = new Vector3(lastPos.x,lastPos.y,lastPos.z);

		if(lastPosIsSpawnedZ)
		{
			pos.z += platformSizeZ;
			lastPosIsSpawnedZ =true;
		}
		else
		{
			pos.x+=(platformSizeZ/2)-(platformSizeX/2);
			pos.z+=(platformSizeZ/2)+(platformSizeX/2);
			lastPosIsSpawnedZ = true;
		}



		lastPos = pos;
		Instantiate (platform, pos,  Quaternion.identity);
		spawnEnergyBalls (pos);

	}


	void spawnEnergyBalls(Vector3 pos)
	{


		if (level==1) {
			if (rand < 3) {
				Instantiate (energyBalls1, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			}
		}

		else if (level==2) {
			if (rand < 3) {
				Instantiate (energyBalls2, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			}
		}

		else if (level==3) {
			if (rand > 2) {
				Instantiate (energyBalls3, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			}
			//else if (rand == 1) {
			//	Instantiate (energyBalls1, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			//}
		}

		else if (level==4) {
			if (rand >3) 
				Instantiate (energyBalls4, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
		}



	}

}
