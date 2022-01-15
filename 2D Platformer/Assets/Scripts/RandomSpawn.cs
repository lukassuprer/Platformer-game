using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour
{
    /*public GameObject enemy;
    public float radius = 5f;
    public float timeOut = 1f;
    public float lastSpawn;
    public ParticleSystem enemySpawn;

    private void Update()
    {
        transform.position = Random.insideUnitSphere * radius;
        if (Time.time >= lastSpawn + timeOut)
        {

            Instantiate(enemy, transform.position, transform.rotation);
            lastSpawn = Time.time;
        }
    }

    /*private void OnParticleSystemStopped()
    {
        transform.position = Random.insideUnitSphere * radius;
        if (Time.time >= lastSpawn + timeOut)
        {
            
            Instantiate(enemy, transform.position, transform.rotation);
            lastSpawn = Time.time;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void EnemySpawn()
    {
        enemySpawn.Play();
    }
    */

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float timeOut;
    public float lastSpawn;
    public ParticleSystem enemySpawn;

    private void Update()
    {
        if (Time.time >= lastSpawn + timeOut)
        {
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Invoke("Spawn", 3f);
            lastSpawn = Time.time;
            StartCoroutine(FasterSpawn());
            if(timeOut <= 1){
                StopAllCoroutines();
            }
        }
    }

    public void Spawn()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }

    IEnumerator FasterSpawn(){
        yield return new WaitForSeconds(10);
        timeOut -= 1;
    }
}
