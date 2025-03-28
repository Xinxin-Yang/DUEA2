using UnityEngine;

public class ResetPlayerController : MonoBehaviour
{

    [Header("��������")]
    public Transform playerTransform;


    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;

    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("δ����Player��������ű���" + gameObject.name);
            return;
        }


        initialPosition = playerTransform.position;
        initialScale = playerTransform.localScale;
        initialRotation = playerTransform.rotation;

        Debug.Log("�Ѽ�¼��ʼ״̬��λ��=" + initialPosition);
    }


    public void ExecuteReset()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player����ʧ��");
            return;
        }

        playerTransform.position = initialPosition;
        playerTransform.localScale = initialScale;
        playerTransform.rotation = initialRotation;

        Debug.Log("Player������", playerTransform);
    }
}
