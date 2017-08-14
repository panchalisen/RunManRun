using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner2 : MonoBehaviour {

	public GameObject platform1;
	public GameObject platform2;
	public GameObject platform3;
	public GameObject platform4;


	public GameObject energyBalls1;
	public GameObject energyBalls2;
	public GameObject energyBalls3;



	//public GameObject diamonds;


	Vector3 lastPos;
	//public GameObject diamonds;
	float platform1SizeX;
	//float platform1SizeZ;
	float platform2SizeX;
	//float platform2SizeZ;
	float platform3SizeX;
	//float platform3SizeZ;
	float platform4SizeX;
	//float platform4SizeZ;

	public bool gameOver;
	public int platformCount;

	int rand;

	int level2StartCount,level3StartCount,level4StartCount;

	// Use this for initialization
	void Start () {

		level2StartCount = 3;
		level3StartCount = 5;
		level4StartCount = 8;


		platformCount = 1;


		lastPos = platform1.transform.position;




		platform1SizeX = platform1.transform.localScale.x;
		//platform1SizeZ = platform1.transform.localScale.z;


		platform2SizeX = platform2.transform.localScale.x;
		//platform2SizeZ = platform2.transform.localScale.z;

		platform3SizeX = platform3.transform.localScale.x;
		//platform3SizeZ = platform3.transform.localScale.z;

		platform4SizeX = platform4.transform.localScale.x;
		//platform4SizeZ = platform4.transform.localScale.z;



		/*
		platform1SizeX = platform1.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.x;
		platform1SizeZ = platform1.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.z;


		platform2SizeX = platform2.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.x;
		platform2SizeZ = platform2.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.z;

		platform3SizeX = platform3.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.x;
		platform3SizeZ = platform3.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.z;

		platform4SizeX = platform4.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.x;
		platform4SizeZ = platform4.transform.FindChild("Ground").GetComponent<BoxCollider>().bounds.size.z;
		*/

		for (int i = 0; i <= 30; i++) {
			SpawnPlatforms ();
		}


	}

	public void startSpawning()
	{

		InvokeRepeating ("SpawnPlatforms",0.1f,0.2f);
	}

	// Update is called once per frame
	void Update () {
		if (GameManager2.instance.gameOver==true)
			CancelInvoke ("SpawnPlatforms");;
	}


	void SpawnPlatforms () {



		rand= Random.Range (0, 6);
		if (rand < 3) {
			SpawnX ();

		} else if (rand >= 3) {
			SpawnZ ();

		}

		platformCount += 1;
	}



	void SpawnX()
	{
		//Vector3 pos = lastPos;

		Vector3 pos = new Vector3(lastPos.x-1,lastPos.y,lastPos.z);

		if (platformCount >= level4StartCount) {
			spawnLevel4X(pos);
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel4X(pos);
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel4X(pos);
		}
		else if (platformCount >= level3StartCount) {
			spawnLevel3X(pos);
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel3X(pos);
		}
		else if (platformCount >= level2StartCount) {
			spawnLevel2X(pos);
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel3X(pos);
		}
		else  {
			spawnLevel1X(pos);
		}

		//Quaternion spawnRotation = Quaternion.Euler(90,0,0);
		spawnEnergyBalls (pos);	



	}

	void spawnLevel1X(Vector3 pos)
	{
		pos.x += platform1SizeX;
		lastPos = pos;
		Instantiate (platform1, pos,  Quaternion.Euler(0,90,0));
	}
	void spawnLevel2X(Vector3 pos)
	{
		pos.x += platform2SizeX;
		lastPos = pos;
		Instantiate (platform2, pos, Quaternion.Euler(0,90,0));
	}
	void spawnLevel3X(Vector3 pos)
	{
		pos.x += platform3SizeX;
		lastPos = pos;
		Instantiate (platform3, pos,  Quaternion.Euler(0,90,0));
	}
	void spawnLevel4X(Vector3 pos)
	{
		pos.x += platform4SizeX;
		lastPos = pos;
		Instantiate (platform4, pos,  Quaternion.Euler(0,90,0));
	}




	void SpawnZ()
	{
		//Vector3 pos = lastPos;
		Vector3 pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);

		if (platformCount >= level4StartCount) {
			spawnLevel4Z (pos);	
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel4Z (pos);
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel4Z (pos);
		}
		else if (platformCount >= level3StartCount) {
			spawnLevel3Z (pos);	
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel3Z (pos);	

		}
		else if (platformCount >= level2StartCount) {
			spawnLevel2Z (pos);	
			pos = new Vector3(lastPos.x,lastPos.y,lastPos.z-1);
			spawnLevel2Z (pos);	
		}
		else {
			spawnLevel1Z (pos);	
		}

		spawnEnergyBalls (pos);

	}

	void spawnLevel1Z(Vector3 pos)
	{
		pos.z += platform1SizeX;
		lastPos = pos;
		Instantiate (platform1, pos,  Quaternion.Euler(0,90,0));
	}
	void spawnLevel2Z(Vector3 pos)
	{
		pos.z += platform2SizeX;
		lastPos = pos;
		Instantiate (platform2, pos,  Quaternion.Euler(0,90,0));
	}
	void spawnLevel3Z(Vector3 pos)
	{
		pos.z += platform3SizeX;
		lastPos = pos;
		Instantiate (platform3, pos,  Quaternion.Euler(0,90,0));
	}
	void spawnLevel4Z(Vector3 pos)
	{
		pos.z += platform4SizeX;
		lastPos = pos;
		Instantiate (platform4, pos,  Quaternion.Euler(0,90,0));
	}




	void spawnEnergyBalls(Vector3 pos)
	{
		if (platformCount <= level4StartCount) { 
			if (rand < 3) {
				Instantiate (energyBalls1, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			}
		}

		if (platformCount > level4StartCount) {
			if (rand < 2) {
				Instantiate (energyBalls3, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
			}
		}

		if(platformCount>= level2StartCount)
		{
			if (rand >3) 
				Instantiate (energyBalls2, new Vector3(pos.x,pos.y+4,pos.z), Quaternion.identity);
		}



	}

}
