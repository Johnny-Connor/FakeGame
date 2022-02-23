using UnityEngine;

public class FakeGameUI : MonoBehaviour
{

    private Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void PlayAnimation(int ID)
    {
        switch (ID)
        {
            case 0:
                anim.Play("GameStart");
                break;
            case 1:
                anim.Play("GameStartOver");
                break;
            default:
                Debug.Log("Animation " + ID + " not found!");
                break;
        }
    }

}
