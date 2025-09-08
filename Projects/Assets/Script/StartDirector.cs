using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        // �}�E�X�N���b�N�ŃQ�[���V�[���ֈڍs
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            SceneManager.LoadScene("GameScene");
        }
    }
}
