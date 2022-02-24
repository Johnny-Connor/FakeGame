using UnityEngine;

public class Spawner : MonoBehaviour
{

    private bool _isActive;
    private float _canSpawn = -1;
    private float _spawnFreq;
    [SerializeField] private EnemyWord[] _enemiesList = new EnemyWord[2];

    private void Update()
    {
        GameStatusCheck();
        SpawnEnemy();
    }

    private void GameStatusCheck()
    {
        RealGameUI aux = FindObjectOfType<RealGameUI>();
        if (aux.GetIsGameRunning == true)
        {
            _isActive = true;
        }
        else
        {
            _isActive = false;
        }
    }

    private void SpawnEnemy()
    {
        if (_isActive && Time.time > _canSpawn)
        {
            int aux = Random.Range(0, _enemiesList.Length - 1);
            Instantiate(_enemiesList[2], transform.position, Quaternion.identity);
        }
    }

}
