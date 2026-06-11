using TMPro;
using System.Collections.Generic;
using UnityEngine;
public class Slide_Script : MonoBehaviour
{
    float x;
    bool stopper=false;
    int slideNum_center;
    int max_slide;
    [SerializeField] List<GameObject> objects_slide = new List<GameObject>();
    [SerializeField] GameObject selectSlide;
    List<RectTransform> objects_rectTrans = new List<RectTransform>();
    List<TextMeshProUGUI> objects_textmeshPro = new List<TextMeshProUGUI>();
    float padding_objects;
    
    private void Awake()
    {
        padding_objects = (Screen.width * 2)/7;

        SetSlideObjComponentToList(objects_rectTrans);
        SetSlideObjComponentToList(objects_textmeshPro);

        gameObject.SetActive(false);
    }
    
    private void Update_SelectSlide()
    {
        slideNum_center = SavedataInstance.instance.savedata.selectedStage;
        selectSlide.GetComponent<TextMeshProUGUI>().text = slideNum_center.ToString();
    }
    private void OnEnable()
    {
        selectSlide.SetActive(false);
        max_slide = SavedataInstance.instance.savedata.maxStage;
        slideNum_center = SavedataInstance.instance.savedata.selectedStage;

        InitPos_Objects();
        InitText_StageNum();
    }
    private void OnDisable()
    {
        Update_SelectSlide();
        selectSlide.SetActive(true);
    }
    private void InitPos_Objects()
    {
        objects_rectTrans[2].localPosition = new Vector2(0, 0);
        objects_rectTrans[1].position = (Vector2)objects_rectTrans[2].position - new Vector2(padding_objects, 0);
        objects_rectTrans[0].position = (Vector2)objects_rectTrans[1].position - new Vector2(padding_objects, 0);
        objects_rectTrans[3].position = (Vector2)objects_rectTrans[2].position + new Vector2(padding_objects, 0);
        objects_rectTrans[4].position = (Vector2)objects_rectTrans[3].position + new Vector2(padding_objects, 0);
    }

    private void InitText_StageNum()
    {
        for (int i = -2; i <= 2; i++)
        {
            if ((slideNum_center + i > 0) && (slideNum_center + i <= max_slide))//Å‘å”ˆÈ‰º‚Æ1ˆÈã‚Ì”Žš
            {
                objects_textmeshPro[i+2].text = (slideNum_center+i).ToString();
            }
        }

    }
    
    private void SetSlideObjComponentToList<T>(List<T> list)
    {
        for (int i = 0; i < objects_slide.Count; i++)
        {
            list.Add(objects_slide[i].GetComponent<T>());
        }
    }
    private void UpdateFirstObjToLast()
    {
        if (slideNum_center + 3 <= max_slide)
        {
            slideNum_center++;

            MoveList_FirstToLast(objects_slide);
            MoveList_FirstToLast(objects_rectTrans);
            MoveList_FirstToLast(objects_textmeshPro);

            objects_rectTrans[4].position = (Vector2)objects_rectTrans[3].position + new Vector2(padding_objects, 0);
            objects_textmeshPro[4].text = (slideNum_center + 2).ToString();
        }
        else if (slideNum_center < max_slide)
        {
            slideNum_center++;

            MoveList_FirstToLast(objects_slide);
            MoveList_FirstToLast(objects_rectTrans);
            MoveList_FirstToLast(objects_textmeshPro);

            objects_rectTrans[4].position = (Vector2)objects_rectTrans[3].position + new Vector2(padding_objects, 0);
            objects_textmeshPro[4].text = "";
        }
        stopper = false;
    }
    private void MoveList_FirstToLast<T>(List<T> list)
    {
        list.Add(list[0]);
        list.RemoveAt(0);
    }
    private void UpdateLastObjToFirst()
    {
        if (slideNum_center > 3)
        {
            slideNum_center--;

            MoveList_LastToFirst(objects_slide);
            MoveList_LastToFirst(objects_rectTrans);
            MoveList_LastToFirst(objects_textmeshPro);
            objects_rectTrans[0].position = (Vector2)objects_rectTrans[1].position - new Vector2(padding_objects, 0);
            objects_textmeshPro[0].text = (slideNum_center - 2).ToString();
        }
        else if (1 < slideNum_center && slideNum_center <= 3)
        {
            slideNum_center--;

            MoveList_LastToFirst(objects_slide);
            MoveList_LastToFirst(objects_rectTrans);
            MoveList_LastToFirst(objects_textmeshPro);
            objects_rectTrans[0].position = (Vector2)objects_rectTrans[1].position - new Vector2(padding_objects, 0);
            objects_textmeshPro[0].text = "";
        }
        stopper = false;
    }
    
    private void MoveList_LastToFirst<T>(List<T> list)
    {
        list.Insert(0, list[4]);
        list.RemoveAt(5);
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            x = Input.GetAxis("Mouse X");

            for (int i = 0; i < objects_slide.Count; i++)
            {
                objects_rectTrans[i].position += new Vector3(x * 15, 0, 0);

            }
        }
        else
        {
            SavedataInstance.instance.savedata.selectedStage = slideNum_center;
            SavedataInstance.instance.Save();
            gameObject.SetActive(false);
        }

        if (slideNum_center <= 1 && objects_rectTrans[2].position.x > Screen.width / 2) InitPos_Objects();//¶§ŒÀ
        else if (slideNum_center >= max_slide && objects_rectTrans[2].position.x < Screen.width / 2) InitPos_Objects();//‰E§ŒÀ
        if (objects_rectTrans[0].position.x <= 0 - padding_objects)
        {

            if (!stopper)
            {
                stopper = true;

                UpdateFirstObjToLast();
            }
        }
        else if (objects_rectTrans[4].position.x >= Screen.width + padding_objects)
        {
            if (!stopper)
            {
                stopper = true;

                UpdateLastObjToFirst();
            }
        }
    }
}
