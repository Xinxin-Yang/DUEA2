using UnityEngine;

public class TreeSway : MonoBehaviour
{
    // 摇摆的速度
    public float swaySpeed = 2f;
    // 摇摆的幅度
    public float swayAmount = 10f;
    // 随机种子，用于让每棵树的摇摆有差异
    private float randomSeed;

    void Start()
    {
        // 初始化随机种子
        randomSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        // 计算当前的摇摆角度
        float swayAngle = Mathf.Sin(Time.time * swaySpeed + randomSeed) * swayAmount;
        // 应用摇摆角度到树的旋转上
        transform.rotation = Quaternion.Euler(0f, swayAngle, 0f);
    }
}
