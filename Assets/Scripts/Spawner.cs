using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Spawnable[] enemyPrefab;
    [SerializeField]
    private string EnemyTags;
    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float respawnRate = 10;

    [SerializeField]
    private int totalNumberToSpawn;

    [SerializeField]
    private int numberToSpawnEachTime = 1;
    [SerializeField]

    private float initialSpawnDelay;
    [SerializeField]
    private AudioClip combatMusic;
    [SerializeField]
    private GameObject spawnTrigger;

    private float spawnTimer;
    private int totalNumberSpawned;

    private int totalAlive;
    private Spawnable[] spawnedEnemies;

    

    public bool isTriggerSetOff;
    public bool IsSpawning { get; private set; }

    private void OnEnable()
    {
        spawnTimer = respawnRate - initialSpawnDelay;
        spawnedEnemies = new Spawnable[totalNumberToSpawn];
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (ShouldSpawn())
            Spawn();
        if (totalNumberToSpawn <= totalNumberSpawned )
        {
            CheckIfEnemiesActive();
        }
    }

    private void CheckIfEnemiesActive()
    {
        if (spawnedEnemies.Length == 0)
        {
            HandleEndFightSequence();
            return;
        }
        else
        {
            UpdateSpawnRoster();
        }
    }

    private void UpdateSpawnRoster()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy.gameObject.activeSelf == false)
                spawnedEnemies = spawnedEnemies.Where(e => e != enemy).ToArray();
        }
    }
    public void HandleStartFightSequence()
    {
        AudioManager.Instance.ChangeBGM(combatMusic);
    }

    private void HandleEndFightSequence()
    {
        spawnTrigger.SetActive(false);
        AudioManager.Instance.EndMusic();
        enabled = false;
    }

    private bool ShouldSpawn()
    {
        if (!isTriggerSetOff || (totalNumberToSpawn <= totalNumberSpawned && totalNumberToSpawn > 0) )
            return false;

        return spawnTimer >= respawnRate;
    }

    private void Spawn()
    {
        spawnTimer = 0;
        var availableSpawnPoints = spawnPoints.ToList();
        for (int i = 0; i < numberToSpawnEachTime; i++)
        {
            if (totalNumberToSpawn <= totalNumberSpawned && totalNumberToSpawn > 0)
                break;

            Spawnable prefab = ChooseRandomEnemyPrefab();
            if (prefab != null)
            {
                Transform spawnPoint = ChooseRandomSpawnPoint(availableSpawnPoints);
                if (availableSpawnPoints.Contains(spawnPoint))
                    availableSpawnPoints.Remove(spawnPoint);

               
                var enemy = prefab.Get<Spawnable>(spawnPoint.position, spawnPoint.rotation);
                totalNumberSpawned++;
                totalAlive ++;
                spawnedEnemies[totalAlive - 1] = enemy;

            }
        }
    }
        
    private Transform ChooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {

        if (availableSpawnPoints.Count == 0)
            return transform;
        if (availableSpawnPoints.Count == 1)
            return availableSpawnPoints[0];

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);

        return availableSpawnPoints[index];
    }

    private Spawnable ChooseRandomEnemyPrefab()
    {
        if (enemyPrefab.Length == 0)
            return null;
        if (enemyPrefab.Length == 1)
            return enemyPrefab[0];

        int index = UnityEngine.Random.Range(0, enemyPrefab.Length);

        return enemyPrefab[index];
    }

    public void ToggleSpawnedObjects()
    {
        
        foreach (var enemy in spawnedEnemies)
        {
            if(enemy != null)
                enemy.gameObject.SetActive(!enemy.gameObject.activeSelf); 
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
        foreach (var spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);
        }
    }
#endif
}
