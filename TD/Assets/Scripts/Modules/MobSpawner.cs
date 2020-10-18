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
        [SerializeField] private byte maxNumberOfMobsOnScene;

        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private float enemySpawnInterval = 0.75f;

        [SerializeField] public List<Transform> spawnPoints = new List<Transform>();
        [HideInInspector] public List<Mob> listofenemies = new List<Mob>();
        [SerializeField] public byte currentNumberOfMobs = 0;

        void Start()
        {
            StartCoroutine(routine: Spawner());
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

            while (currentNumberOfMobs < maxNumberOfMobsOnScene)
            {
                CreateMob();

                yield return new WaitForSeconds(enemySpawnInterval);
            }
        }
    }
}