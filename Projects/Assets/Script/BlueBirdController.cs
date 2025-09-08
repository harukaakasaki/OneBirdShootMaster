using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdController : MonoBehaviour
{
    public float speed = 0f;
    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        float angle = 60f;
        moveDirection = (Quaternion.Euler(0, 0, angle) * Vector2.right).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(moveDirection * speed * Time.deltaTime);

        ScreenBounds();

        if (Input.GetMouseButtonDown(0))
        {
            // ��ʏ�̃}�E�X�̈ʒu���J�������ɕϊ�
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �N���b�N�����ʒu�ɔ��肳����
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("B2_BlueBird"))
            {
                Debug.Log("�u���[���A���j�I");
            }



        }
    }
    void ScreenBounds()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0f || viewPos.x > 1f)
        {
            moveDirection.x *= -1;
        }

        if (viewPos.y < 0f || viewPos.y > 1f)
        {
            moveDirection.y *= -1;
        }
    }
}
