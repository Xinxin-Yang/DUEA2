using UnityEngine;

public class ResetPlayerController : MonoBehaviour
{

    [Header("必须设置")]
    public Transform playerTransform;


    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;

    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("未分配Player对象！请检查脚本：" + gameObject.name);
            return;
        }


        initialPosition = playerTransform.position;
        initialScale = playerTransform.localScale;
        initialRotation = playerTransform.rotation;

        Debug.Log("已记录初始状态：位置=" + initialPosition);
    }


    public void ExecuteReset()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player对象丢失！");
            return;
        }

        playerTransform.position = initialPosition;
        playerTransform.localScale = initialScale;
        playerTransform.rotation = initialRotation;

        Debug.Log("Player已重置", playerTransform);
    }
}
