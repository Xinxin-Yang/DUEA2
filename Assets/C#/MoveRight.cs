using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MoveRight : MonoBehaviour
{
    public Transform player;
    public float moveDistance = 1f;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(MovePlayerRight);
    }

    void MovePlayerRight()
    {
        if (player != null)
            player.Translate(Vector3.right * moveDistance);
    }
}