using UnityEngine;

public class Word : MonoBehaviour
{

    [Tooltip("0 - Enemy | 1 - Friend")] [SerializeField] private int _wordTypeID;
    private static int DMG;
    // Static variables resets do 0 after Awake() and Start().
    private static float SPD;
    private static float SPDIncreaseValue = 25;
    private static float canIncreaseDifficulty = -1;
    private static float difficultyIncreaseRate = 5;

    private void Update()
    {
        IncreaseDifficulty();
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 0)
        {
            Player aux = FindObjectOfType<Player>();
            aux.TakeDamage(DMG);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 1)
        {
            Player aux = FindObjectOfType<Player>();
            if (Input.GetMouseButton(0))
            {
                aux.TakeBuff();
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player" && _wordTypeID == 1)
        {
            Player aux = FindObjectOfType<Player>();
            aux.ChangeIcon(0);
        }
    }

    private void IncreaseDifficulty()
    {
        RealGameUI aux = FindObjectOfType<RealGameUI>();
        if (aux.GetIsGameRunning == true)
        {
            if (Time.time > canIncreaseDifficulty)
            {
                SPD += SPDIncreaseValue;
                canIncreaseDifficulty = Time.time + difficultyIncreaseRate;
                Debug.Log("SPD increased to: " + SPD);
            }
        }
        else
        {
            SPD = 0;
            canIncreaseDifficulty = -1;
        }
    }

    private void Movement()
    {
        transform.Translate(0, Time.deltaTime * SPD * -1, 0);
    }

}
