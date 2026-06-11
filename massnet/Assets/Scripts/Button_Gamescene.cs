using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Button_Gamescene : MonoBehaviour
{
    [SerializeField] Animator animator_result;
    [SerializeField] Text_CountUP text_countUP;
    [SerializeField] GameObject fadePamel;
    Image fadePanelImage;

    private void Start()
    {
        fadePanelImage = fadePamel.GetComponent<Image>();
        fadePamel.SetActive(false);
    }
    public void ResultSkipOrBackToTitle()
    {
        if (text_countUP.end)
        {
            LoadTitleScene();
        }
        else
        {
            text_countUP.End();
            animator_result.Play("Panel_Result", 0, 1);
        }
    }
    public void LoadTitleScene()
    {
        SavedataInstance.instance.savedata.backToTitleNum++;
        SavedataInstance.instance.Save();
        Scenechange("TitleScene");
    }
    private void Scenechange(string scene)
    {
        StartCoroutine(SceneFadeChange(scene));
    }
    IEnumerator SceneFadeChange(string scene)
    {
        fadePamel.SetActive(true);
        float a = fadePanelImage.color.a;
        while (fadePanelImage.color.a <= 1)
        {
            a += 0.05f;
            fadePanelImage.color = new(default, default, default, a);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(scene);
    }

}
