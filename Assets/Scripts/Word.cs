using UnityEngine;

public class Word : MonoBehaviour
{

    [Tooltip("0 - Enemy | 1 - Friend")] [SerializeField] private int _wordTypeID;
    private static int _dmg;
    // Static variables resets to 0 after Awake() and Start().
    private static float _friendSpd;
    private static float _spd;
    private float _initialSpd = 250;
    private static float _spdIncreaseValue = 10;
    private static float _canIncreaseSpd = -1;
    private static float _spdIncreaseRate = 1f;

    private void Update()
    {
        IncreaseSpd();
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 0)
        {
            Player aux = FindObjectOfType<Player>();
            aux.TakeDamage(_dmg);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 1)
        {
            Player aux = FindObjectOfType<Player>();
            aux.ChangeIcon(1);
            if (Input.GetMouseButton(0))
            {
                aux.TakeBuff();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 1)
        {
            Player aux = FindObjectOfType<Player>();
            aux.ChangeIcon(0);
        }
    }

    #region Custom Functions
    private void IncreaseSpd()
    {
        RealGameUI aux = FindObjectOfType<RealGameUI>();
        if (aux.GetIsGameRunning == true)
        {
            if (Time.time > _canIncreaseSpd)
            {
                _spd += _spdIncreaseValue;
                _canIncreaseSpd = Time.time + _spdIncreaseRate;
            }
        }
        else
        {
            // Not in "Start()" or "Awake()" because static variables resets after these.
            InitializeStaticVariables();
        }
    }

    private void InitializeStaticVariables()
    {
        _dmg = 1;
        _spd = _initialSpd;
        _friendSpd = _initialSpd;
        _canIncreaseSpd = -1;
    }

    private void Movement()
    {
        switch (_wordTypeID)
        {
            case 0:
                transform.Translate(0, Time.deltaTime * _spd * -1, 0);
                break;
            case 1:
                transform.Translate(0, Time.deltaTime * _friendSpd * -1, 0);
                break;
            default:
                break;
        }
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion CustomFunction

}