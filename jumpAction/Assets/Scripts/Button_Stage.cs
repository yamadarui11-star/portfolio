
using UnityEngine;

public class Button_Stage : MonoBehaviour
{
    StageClearDate stageClearDate;
    [SerializeField] StageData.Type stage;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    private void OnEnable()
    {
        stageClearDate = SavedateInstance.instance.GetStageClearData(stage);

        if (stageClearDate != null)
        {
            if (stageClearDate.bestclearStar == 3)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if (stageClearDate.bestclearStar == 2)
            {
                star1.SetActive(true);
                star3.SetActive(true);
            }
            else if (stageClearDate.bestclearStar == 1) star1.SetActive(true);
        }
    }

    public void UpdatePaperUI()
    {
        Director.instance.UpdateSelectedStage(stage);
        Director.instance.UpdatePaperText_Stage();
        Director.instance.UpdateBestScoreText();
        Director.instance.SetActiveStartButton();
        Director.instance.PaperAnima();
        AudioSE.instance.UI_decide();
    }

}