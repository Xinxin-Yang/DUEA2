using UnityEngine;

public class TreeSway : MonoBehaviour
{
    // ҡ�ڵ��ٶ�
    public float swaySpeed = 2f;
    // ҡ�ڵķ���
    public float swayAmount = 10f;
    // ������ӣ�������ÿ������ҡ���в���
    private float randomSeed;

    void Start()
    {
        // ��ʼ���������
        randomSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        // ���㵱ǰ��ҡ�ڽǶ�
        float swayAngle = Mathf.Sin(Time.time * swaySpeed + randomSeed) * swayAmount;
        // Ӧ��ҡ�ڽǶȵ�������ת��
        transform.rotation = Quaternion.Euler(0f, swayAngle, 0f);
    }
}
