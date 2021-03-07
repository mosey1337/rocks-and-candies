using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private GameObject _candyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    void Start() {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets() {
        while(true) {
            yield return new WaitForSeconds(1f);

            var spawnPoint = GetSpawnPoint();

            var prefab = IsStone() ? _stonePrefab : _candyPrefab;

            var gameObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

            Destroy(gameObject, 5f);
        }
    }

    bool IsStone() {
        return Random.Range(0, 8) == 2;
    }

    Transform GetSpawnPoint() {
        int index = Random.Range(0, _spawnPoints.Length - 1);

        return _spawnPoints[index];
    }
}
