using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Spawner Related")]
    [SerializeField] private bool _isActive;
    [SerializeField] private GameObject[] _enemiesList = new GameObject[27];
    [SerializeField] private GameObject[] _friendsList = new GameObject[4];
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _friendContainer;

    [Header("Enemy Related")]
    private float _canSpawnEnemy = -1;
    private float _enemySpawnFreq = 0.5f;
    private float _enemySpawnFreqDivideValue = 1.25f;
    private float _canIncreaseDifficulty = -1;
    private float _difficultyIncreaseFreq = 10f;

    [Header("Friend Related")]
    private float _spawnTimeMin = 15f; //15
    private float _spawnTimeMax = 25f; //30
    private float _canSpawnFriend;

    private void Update()
    {
        GameStatusCheck();
        IncreaseDifficulty();
        SpawnEnemy();
        SpawnFriend();
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

    private void IncreaseDifficulty()
    {
        if (_isActive && Time.time > _canIncreaseDifficulty)
        {
            _enemySpawnFreq /= _enemySpawnFreqDivideValue;
            _canIncreaseDifficulty = Time.time + _difficultyIncreaseFreq;
        }
        else if (_isActive == false)
        {
            _enemySpawnFreq = 0.5f;
            _canIncreaseDifficulty = -1;
        }
    }

    private void SpawnEnemy()
    {
        if (_isActive && Time.time > _canSpawnEnemy)
        {
            int rnd = Random.Range(0, _enemiesList.Length);
            int rndPosX = Random.Range(0, 1930);
            GameObject newEnemy = Instantiate(_enemiesList[rnd], new Vector2(rndPosX, 1150), Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            _canSpawnEnemy = Time.time + _enemySpawnFreq;
        }
        else if (_isActive == false)
        {
            _canSpawnEnemy = -1;
        }
    }

    private void SpawnFriend()
    {
        if (_isActive && Time.time > _canSpawnFriend)
        {
            int rnd = Random.Range(0, _friendsList.Length);
            int rndPosX = Random.Range(0, 1930);
            GameObject newFriend = Instantiate(_friendsList[rnd], new Vector2(rndPosX, 1150), Quaternion.identity);
            newFriend.transform.SetParent(_friendContainer.transform);
            _canSpawnFriend = Time.time + Random.Range(_spawnTimeMin, _spawnTimeMax);
        }
        else if (_isActive == false)
        {
            _canSpawnFriend = Random.Range(_spawnTimeMin, _spawnTimeMax);
        }
    }

}