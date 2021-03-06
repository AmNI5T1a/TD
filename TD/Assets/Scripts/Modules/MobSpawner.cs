#pragma warning disable 0649

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
        [Header("References: ")]
        [SerializeField] private GameObject _enemyPrefab;

        [Header("Stats: ")]
        [Tooltip("Max number of mobs on scene")] [SerializeField] private byte maxNumberOfMobsOnScene;

        [Tooltip("Delay in seconds(float)")] [SerializeField] private float enemySpawnInterval = 1f;

        [SerializeField] public List<Transform> spawnPoints = new List<Transform>();
        [HideInInspector] public List<Mob> listofenemies = new List<Mob>();
        [Header("In game stats: ")]
        [Tooltip("Shows current number of mobs on scene in play mode")] [SerializeField] public byte currentNumberOfMobs = 0;


        void Start()
        {
            StartCoroutine(Spawner());
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
            Vector3 randomSpawnPosition = new Vector3(mob.spawnpoint.position.x + Random.Range(-5f, 5f), mob.spawnpoint.position.y, mob.spawnpoint.position.z + Random.Range(-5f, 5f));

            GameObject.Instantiate(mob.enemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
        private IEnumerator Spawner()
        {
            while (true)
            {
                if (currentNumberOfMobs < maxNumberOfMobsOnScene)
                {
                    CreateMob();

                    yield return new WaitForSeconds(enemySpawnInterval);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}