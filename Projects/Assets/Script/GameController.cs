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
        // �N���b�N���ꂽ��A���w�i��\��������
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FlashDark());
            Debug.Log("�Ó]�I");

           
        }

        

    }

    IEnumerator FlashDark()
    {
        // ��ʂ���C�ɐ^���Âɂ���
        SetAlpha(1f);

        //fadeTime�����^���Âȏ��
        yield return new WaitForSeconds(fadeTime);

        float time = 0f;

        // ���񂾂񓧖��ɂ��Ă������[�v
        while (time < fadeTime)
        {
            // ���X��alpha��1����0�ɕω�������
            float alpha = Mathf.Lerp(1f, 0f, time / fadeTime);

            // �摜�̓����x���X�V
            SetAlpha(alpha);
            // �o�ߎ��Ԃ����Z
            time += Time.deltaTime;
            // 1�t���[���҂�
            yield return null;
        }
        // ���S�ȓ���
        SetAlpha(0f);
    }
    void SetAlpha(float alpha)
    {
        // ���݂̐F
        Color color = fadeImage.color;
        // �A���t�@���X�V
        color.a = alpha;
        // �X�V�����F�𔽉f
        fadeImage.color = color;
    }

}