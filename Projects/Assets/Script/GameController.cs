using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fadeImage;
    public float fadeTime = 0.1f;
    

    // Update is called once per frame
    void Update()
    {
        // クリックされたら、黒背景を表示させる
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FlashDark());
            Debug.Log("暗転！");

           
        }

        

    }

    IEnumerator FlashDark()
    {
        // 画面を一気に真っ暗にする
        SetAlpha(1f);

        //fadeTimeだけ真っ暗な状態
        yield return new WaitForSeconds(fadeTime);

        float time = 0f;

        // だんだん透明にしていくループ
        while (time < fadeTime)
        {
            // 徐々にalphaを1から0に変化させる
            float alpha = Mathf.Lerp(1f, 0f, time / fadeTime);

            // 画像の透明度を更新
            SetAlpha(alpha);
            // 経過時間を加算
            time += Time.deltaTime;
            // 1フレーム待つ
            yield return null;
        }
        // 完全な透明
        SetAlpha(0f);
    }
    void SetAlpha(float alpha)
    {
        // 現在の色
        Color color = fadeImage.color;
        // アルファを更新
        color.a = alpha;
        // 更新した色を反映
        fadeImage.color = color;
    }

}