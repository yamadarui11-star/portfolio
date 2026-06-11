using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeinout : MonoBehaviour
{
    public static fadeinout fadeinoutinstance;
    Image fadeinoutpanelimage;
    SoundManager soundManager;
    private void Awake()
    {
        single();
    }
    

    void single()
    {
        if (fadeinoutinstance == null)
        {
            fadeinoutinstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        fadeinoutpanelimage = gameObject.GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void Resetgame(string fadeinscene)
    {
        Time.timeScale = 1;
        gameObject.SetActive(true);
        soundManager.Decide();
        StartCoroutine( Fadeinoutupdate(fadeinscene));
        Debug.Log("start fade");
    }

    IEnumerator Fadeinoutupdate(string fadeinscene)
    {
        while (fadeinoutpanelimage.color.a <= 1)
        {
            fadeinoutpanelimage.color += new Color(0, 0, 0, 0.03f);
            yield return new WaitForSeconds(0.03f);
        }
        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(fadeinscene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        while (fadeinoutpanelimage.color.a >= 0)
        {
            fadeinoutpanelimage.color -= new Color(0, 0, 0, 0.03f);
            yield return new WaitForSeconds(0.03f);
        }

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();//�V�[���J�ڌ�̐V�����T�E���h�}�l�[�W���[�I�u�W�F�N�g�擾
        gameObject.SetActive(false);
    }
    

    
}
