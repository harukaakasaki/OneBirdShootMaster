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
        float angle = 60f; //角度
        moveDirection = (Quaternion.Euler(0, 0, angle) * Vector2.right).normalized; // 変更されないようにしている
    }

    // Update is called once per frame
    void Update()
    {
        // 移動させる関数
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // バウンドする関数
        ScreenBounds();

        if (Input.GetMouseButtonDown(0))
        {
            // 画面上のマウスの位置をカメラ内に変換
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // クリックした位置に判定させる
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("B1_RedBird"))
            {
                Debug.Log("レッド鳥、撃破！");
            }
        }
    }
    void ScreenBounds()// バウンドする
    {                                 // メインカメラ画面内
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // if x座標の画面端に当たったら
        if (viewPos.x < 0f || viewPos.x > 1f)
        {
            moveDirection.x *= -1; // 反射される
        }

        // if y座標の画面端に当たったら
        if (viewPos.y < 0f || viewPos.y > 1f)
        {
            moveDirection.y *= -1; // 反射される
        }
    }
}
