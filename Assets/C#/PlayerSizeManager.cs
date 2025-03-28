using UnityEngine;
using UnityEngine.UI;

public class PlayerSizeManager : MonoBehaviour
{
    public Transform player;
    public Button growBtn;
    public Button shrinkBtn;
    public float minSize = 0.5f;

    void Start()
    {
        growBtn.onClick.AddListener(Grow);
        shrinkBtn.onClick.AddListener(Shrink);
    }

    void Grow()
    {
        player.localScale *= 1.1f;
        FixPosition();
    }

    void Shrink()
    {
        if (player.localScale.x > minSize)
        {
            player.localScale *= 0.9f;
            FixPosition();
        }
    }

    void FixPosition()
    {
        if (player.position.y - player.localScale.y / 2 < 0)
        {
            player.position = new Vector3(
                player.position.x,
                player.localScale.y / 2,
                player.position.z);
        }
    }
}
