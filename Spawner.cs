using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Unity functions
    private void Start()
    {
        SpawnAtRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsIdle = SpawnCooldownTimer <= 0;
        if (IsIdle&&!hasObject){
            SpawnObject();
            SpawnAtRandomTime();
        }
        else if(!IsIdle&&hasObject)
        {
            Cooldown();
        }
        else
        {
            CheckSpawnedObject();
        }
    }
    #endregion

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
