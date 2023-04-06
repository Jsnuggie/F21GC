using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMose : MonoBehaviour
{
   
    //�����
    [Header("�����")]
    public GameObject playerView;

    //�ٶȣ�ÿ���ƶ�5����λ����
    [Header("�ƶ��ٶ�")]
    public float moveSpeed = 5;
    [Header("�Ӷ��ٶ�")]
    public float maxMoveSpeed = 10;
    //���ٶȣ�ÿ����ת135��
    [Header("��ת�ٶ�")]
    public float angularSpeed = 135;
    //��Ծ����
    [Header("��Ծ�ٶ�")]
    public float jumpForce = 200f;

    //ˮƽ�ӽ�������
    [Header("ˮƽ�ӽ�������")]
    public float horizontalRotateSensitivity = 5;
    //��ֱ�ӽ�������
    [Header("��ֱ")]
    public float verticalRotateSensitivity = 2.5f;

    //��󸩽�
    [Header("��󸮽�")]
    public float maxDepressionAngle = 90;

    //�������
    [Header("�������")]
    public float maxElevationAngle = 25;

    //��ɫ�ĸ���
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        View();
        Jump();
    }

    void Move()
    {
        //ͨ�����̻�ȡ��ֱ��ˮƽ���ֵ����Χ��-1��1
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        var Speed = moveSpeed;

       
        if (Input.GetKey(KeyCode.LeftShift))//����Shift �ı��ٶ�
        {
            moveSpeed = maxMoveSpeed;
        } //����ʸ���ƶ�һ�ξ���
        transform.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.right * h * Time.deltaTime * moveSpeed);
        moveSpeed = Speed;
    }

    void View()
    {
        //������굽��Ļ����
        SetCursorToCentre();

        //��ǰ��ֱ�Ƕ�
        double VerticalAngle = playerView.transform.eulerAngles.x;

        //ͨ������ȡ��ֱ��ˮƽ���ֵ����Χ��-1��1
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y") * -1;

        //��ɫˮƽ��ת
        transform.Rotate(Vector3.up * h * Time.deltaTime * angularSpeed * horizontalRotateSensitivity);

        //���㱾����ת����ֱ�����ϵ�ŷ����
        double targetAngle = VerticalAngle + v * Time.deltaTime * angularSpeed * verticalRotateSensitivity;

        //��ֱ�����ӽ�����
        if (targetAngle > maxDepressionAngle && targetAngle < 360 - maxElevationAngle) return;

        //�������ֱ��������ת
        playerView.transform.Rotate(Vector3.right * v * Time.deltaTime * angularSpeed * verticalRotateSensitivity);
    }

    void SetCursorToCentre()
    {
        //���������ٽ�������꽫�Զ��ص���Ļ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        //�������
        Cursor.visible = false;
    }
    //�ж��Ƿ�����Ծ״̬
    public float  jumpTime;
    void Jump()
    {
        jumpTime += Time.deltaTime;
        print(jumpTime);
        if (Input.GetKeyDown(KeyCode.Space) && jumpTime > 0.5)
        {
            rigidbody.AddForce (Vector3.up * jumpForce,ForceMode.Impulse);
            jumpTime = 0;

        }

    }
}

