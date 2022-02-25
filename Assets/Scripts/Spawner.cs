using UnityEngine;

public class Spawner : MonoBehaviour
{

    private bool _isActive;
    private float _canSpawnEnemy = -1;
    private float _enemySpawnFreq = 2.5f;
    [SerializeField] private GameObject[] _enemiesList = new GameObject[1];
    [SerializeField] private GameObject[] _friendsList = new GameObject[1];

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
        if (_isActive && Time.time > _canSpawnEnemy)
        {
            int aux = Random.Range(0, _enemiesList.Length - 1);
            Instantiate(_enemiesList[2], transform.position, Quaternion.identity);
            _canSpawnEnemy = Time.time + _enemySpawnFreq;
        }
    }

    private void SpawnFriend()
    {

    }

    // function to decrease _enemySpawnFreq as time passes.

}
