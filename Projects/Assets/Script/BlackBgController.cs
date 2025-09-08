using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBgController : MonoBehaviour
{
    // Start is called before the first frame update
    public  Image fadeImage;
    public float fadeTime = 0.1f;

    void Start()
    {
        SetAlpha(0f);
    }

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
        SetAlpha(1f);

        yield return new WaitForSeconds(fadeTime);

        float time = 0f;
        while (time < fadeTime)
        {
            float alpha = Mathf.Lerp(1f,0f, time/ fadeTime);

            SetAlpha(alpha);

            time += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0f);
    }
    void SetAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
    
}


