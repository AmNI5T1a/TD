using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public struct Mob
    {
        public GameObject enemyPrefab;
        public Transform spawnpoint;

        public Mob(GameObject enemyPrefab, Transform spawnpoint)
        {
            this.enemyPrefab = enemyPrefab;
            this.spawnpoint = spawnpoint;
        }

        public void DisplayInfo()
        {
            Debug.Log($"1.Spawnpoint: {spawnpoint}\n");
        }
    }
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] public byte numberOfMobs;

        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private byte enemySpawnInterval;

        [SerializeField] public List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] public List<Transform> waypoints = new List<Transform>();
        [HideInInspector] public List<Mob> listofenemies = new List<Mob>();
        [HideInInspector] public byte currentNumberOfMobs;

        void Start()
        {
            StartCoroutine(routine: Spawner());
        }

        void Update()
        {

        }
        public void CreateMob()
        {
            currentNumberOfMobs++;
            Mob currentMob = new Mob(enemyPrefab: _enemyPrefab, spawnpoint: spawnPoints[Random.Range(0, spawnPoints.Count)]);
            listofenemies.Add(currentMob);
            SpawnAMob(ref currentMob);
        }
        void SpawnAMob(ref Mob mob)
        {
            GameObject.Instantiate(mob.enemyPrefab, mob.spawnpoint.position, Quaternion.identity);
        }
        private IEnumerator Spawner()
        {

            while (currentNumberOfMobs < numberOfMobs)
            {
                CreateMob();


                yield return new WaitForSeconds(enemySpawnInterval);
            }
        }
    }
}