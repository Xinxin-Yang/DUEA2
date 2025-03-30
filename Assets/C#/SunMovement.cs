using UnityEngine;

public class SunMovement : MonoBehaviour
{
    [Header("�˶�����")]
    [Tooltip("�����ٶȣ���/�룩")]
    public float rotationSpeed = 15f;

    [Tooltip("����뾶���ף�")]
    public float orbitRadius = 100f;

    [Tooltip("�Ƿ����ü�����б")]
    public bool useSeasonalTilt = false;
    [Range(-90f, 90f)]
    public float axialTilt = 23.5f;

    [Header("�������")]
    [Tooltip("�Զ��������ĵ㣨�������꣩")]
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
        // �޸���ת����㣨��ʱ����ת90�ȣ�
        float radian = currentAngle * Mathf.Deg2Rad;

        // �µ�λ�ü��㹫ʽ��Χ��X����ת��
        Vector3 basePosition = new Vector3(
            Mathf.Cos(radian) * orbitRadius,  // X�ᣨԭZ�ᣩ
            Mathf.Sin(radian) * orbitRadius,  // Y�ᣨԭY�ᣩ
            0f                                // Z�ᣨԭX�ᣩ
        );

        // ��ת��������ת 90��
        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
        basePosition = rotation * basePosition;

        // Ӧ����ת����б�����ڻ�Ӱ�첻ͬ����
        if (useSeasonalTilt)
        {
            basePosition = Quaternion.Euler(axialTilt, 0f, 0f) * basePosition;
        }

        // ��������λ�ã������Զ��������ģ�
        transform.position = orbitCenter + basePosition;

        // ��������������Ҫ���������ĵ�Y�᷽��
        transform.LookAt(orbitCenter + Vector3.up * 10f); // ������շ�����Ҫ���ִ�ֱ
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(orbitCenter, orbitRadius);
        Gizmos.DrawLine(orbitCenter, transform.position);
    }
}