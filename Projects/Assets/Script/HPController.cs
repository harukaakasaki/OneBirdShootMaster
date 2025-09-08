using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    public GameObject[] HPIcons;
    public GameObject[] BirdHPIcons;

    private int HP = 3;
    private int BirdHP = 3;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    public AudioClip clip1;
    public AudioClip clip2;

    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && HP > 0)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // �������ɓ���������
            if (hit.collider != null)
            {
                audioSource1.PlayOneShot(clip1);
                Destroy(hit.collider.gameObject); // �����������
                BirdHP--;
                BirdHPIcons[BirdHP].SetActive(false);
                Debug.Log("����HP:" + BirdHP); // ���̎c��HP
                if (BirdHP <= 0) // ����HP��0�ɂȂ�����N���A�V�[���Ɉڍs
                {
                    SceneManager.LoadScene("ClearScene");
                }
                return;
            }
            
            HP--;
            if (HP >= 0 && HP < HPIcons.Length)
            {
                audioSource2.PlayOneShot(clip2);
                HPIcons[HP].SetActive(false);
                Debug.Log("�O���Ă���A�c�e:" + HP);
                
            }
            if (HP <= 0) //�����n�[�g��0�ɂȂ�����A�Q�[���I�[�o�[�V�[���Ɉڍs
            {
                SceneManager.LoadScene("GameOverScene");
                Debug.Log("�Q�[���I�[�o�[��Ȃ�����");
            }
        }
    }

}
