using UnityEngine;

public class SunMovement : MonoBehaviour
{
    [Header("运动参数")]
    [Tooltip("绕行速度（度/秒）")]
    public float rotationSpeed = 15f;

    [Tooltip("轨道半径（米）")]
    public float orbitRadius = 100f;

    [Tooltip("是否启用季节倾斜")]
    public bool useSeasonalTilt = false;
    [Range(-90f, 90f)]
    public float axialTilt = 23.5f;

    [Header("轨道设置")]
    [Tooltip("自定义轨道中心点（世界坐标）")]
    public Vector3 orbitCenter = Vector3.zero;

    private float currentAngle;

    void Update()
    {
        currentAngle += rotationSpeed * Time.deltaTime;
        if (currentAngle >= 360f) currentAngle -= 360f;
        UpdatePosition();
    }

    void UpdatePosition()
    {
        // 修改旋转轴计算（逆时针旋转90度）
        float radian = currentAngle * Mathf.Deg2Rad;

        // 新的位置计算公式（围绕X轴旋转）
        Vector3 basePosition = new Vector3(
            Mathf.Cos(radian) * orbitRadius,  // X轴（原Z轴）
            Mathf.Sin(radian) * orbitRadius,  // Y轴（原Y轴）
            0f                                // Z轴（原X轴）
        );

        // 绕转动中心旋转 90°
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
        basePosition = rotation * basePosition;

        // 应用自转轴倾斜（现在会影响不同轴向）
        if (useSeasonalTilt)
        {
            basePosition = Quaternion.Euler(axialTilt, 0f, 0f) * basePosition;
        }

        // 设置最终位置（保持自定义轨道中心）
        transform.position = orbitCenter + basePosition;

        // 调整朝向（现在需要朝向轨道中心的Y轴方向）
        transform.LookAt(orbitCenter + Vector3.up * 10f); // 假设光照方向需要保持垂直
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(orbitCenter, orbitRadius);
        Gizmos.DrawLine(orbitCenter, transform.position);
    }
}