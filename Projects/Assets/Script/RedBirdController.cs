using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBirdController : MonoBehaviour
{
    public float speed = 0f;
    private Vector2 moveDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        float angle = 60f; //�p�x
        moveDirection = (Quaternion.Euler(0, 0, angle) * Vector2.right).normalized; // �ύX����Ȃ��悤�ɂ��Ă���
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�������֐�
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // �o�E���h����֐�
        ScreenBounds();

        if (Input.GetMouseButtonDown(0))
        {
            // ��ʏ�̃}�E�X�̈ʒu���J�������ɕϊ�
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �N���b�N�����ʒu�ɔ��肳����
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("B1_RedBird"))
            {
                Debug.Log("���b�h���A���j�I");
            }
        }
    }
    void ScreenBounds()// �o�E���h����
    {                                 // ���C���J������ʓ�
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // if x���W�̉�ʒ[�ɓ���������
        if (viewPos.x < 0f || viewPos.x > 1f)
        {
            moveDirection.x *= -1; // ���˂����
        }

        // if y���W�̉�ʒ[�ɓ���������
        if (viewPos.y < 0f || viewPos.y > 1f)
        {
            moveDirection.y *= -1; // ���˂����
        }
    }
}
