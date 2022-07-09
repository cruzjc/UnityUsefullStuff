using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private void Start()
    {
        SpawnAtRandomTime();
    }


    // Update is called once per frame
    void Update()
    {
        if(SpawnCooldownTimer<=0&&!hasObject){
            SpawnObject();
            SpawnAtRandomTime();
        }
        else if(SpawnCooldownTimer>0&&hasObject)
        {
            Cooldown();
        }
        else
        {
            CheckSpawnedObject();
        }
    }

    [SerializeField]
    private float SpawnCooldown = 10;

    [SerializeField]
    private float SpawnCooldownTimer = 0;

    [SerializeField]
    private bool hasObject=false;

    public GameObject ObjectToSpawn;
    private GameObject SpawnedObject;
    void SpawnObject(){
        SpawnedObject=GameObject.Instantiate(ObjectToSpawn,this.transform.position,this.transform.rotation);
        SpawnCooldownTimer = SpawnCooldown;
        hasObject=true;
    }

    private void Cooldown(){
        if(SpawnCooldownTimer>0){
            SpawnCooldownTimer -= Time.deltaTime;
        }
    }

    private void CheckSpawnedObject()
    {
        if (SpawnedObject == null)
        {
            hasObject = false;
        }
    }

    public float SpawnRandomTimeMin=5;
    public float SpawnRandomTimeMax=10;
    private void SpawnAtRandomTime()
    {
        SpawnCooldown=Random.Range(SpawnRandomTimeMin, SpawnRandomTimeMax);

    }


}
