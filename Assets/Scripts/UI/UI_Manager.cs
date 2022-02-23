using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] private GameObject _fakeGameUI;
    private Animation _fakeGameUIanim;

    private void Awake()
    {

    }

    private void Start()
    {
        _fakeGameUIanim = GetComponent<Animation>();
    }

}
