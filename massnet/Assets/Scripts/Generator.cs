using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator instance;
    [SerializeField]
    RectTransform canvasTransform;
    GameObject triangle;
    GameObject bomb;
    GameObject enemyBullet;
    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject enemy4;
    GameObject explosion;
    GameObject rock;
    GameObject rock_red;
    GameObject rock_gold;
    GameObject rock_dia;
    GameObject sun;
    GameObject earth;
    GameObject galaxy;
    GameObject scoreupText;
    GameObject magneticCircle;

    float probability1;
    float probability2;
    int generatenum = 0;
    int selectedStage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        rock = (GameObject)Resources.Load("rock");
        rock_red = (GameObject)Resources.Load("rock_red");
        rock_gold = (GameObject)Resources.Load("rock_gold");
        rock_dia = (GameObject)Resources.Load("rock_dia");
        sun=(GameObject)Resources.Load("sun");
        earth=(GameObject)Resources.Load("earth");
        galaxy = (GameObject)Resources.Load("galaxy");
        triangle = (GameObject)Resources.Load("Triangle");
        bomb = (GameObject)Resources.Load("Bomb");
        enemyBullet= (GameObject)Resources.Load("Enemybullet");
        enemy1 = (GameObject)Resources.Load("Enemy1");
        enemy2 = (GameObject)Resources.Load("Enemy2");
        enemy3= (GameObject)Resources.Load("Enemy3");
        enemy4 = (GameObject)Resources.Load("Enemy4");
        explosion = (GameObject)Resources.Load("Explosion_Particle");
        scoreupText = (GameObject)Resources.Load("scoreupText");
        magneticCircle= (GameObject)Resources.Load("Image_MagneticCircle");

    }
    private void Start()
    {

        selectedStage = SavedataInstance.instance.savedata.selectedStage;
        GenerateMassRandom(1000+selectedStage*30);
    }
    public GameObject GetRandomMass()
    {
        probability1 = 0;
        int rnd1 = Random.Range(0, 1000);
        switch (selectedStage)
        {
            case 1:
                probability1 += 40;
                if (rnd1 < probability1) return rock_red;
                probability1 += 200;
                if (rnd1 < probability1) return rock;
                return triangle;

            case 2:
                probability1 += 30;
                if (rnd1 < probability1) return rock_gold;
                probability1 += 100;
                if (rnd1 < probability1) return rock_red;
                probability1 += 300;
                if (rnd1 < probability1) return rock;
                return triangle;
            case 3:
                probability1 += 1;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 100;
                if (rnd1 < probability1) return rock_gold;
                probability1 += 300;
                if (rnd1 < probability1) return rock_red;
                probability1 += 500;
                if (rnd1 < probability1) return rock;
                return triangle;
            case 4:
                probability1 += 2;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 200;
                if (rnd1 < probability1) return rock_gold;
                probability1 += 400;
                if (rnd1 < probability1) return rock_red;
                probability1 += 200;
                if (rnd1 < probability1) return rock;
                return triangle;
            case 5:
                probability1 += 3;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 200;
                if (rnd1 < probability1) return rock_gold;
                probability1 += 400;
                if (rnd1 < probability1) return rock_red;
                probability1 += 200;
                if (rnd1 < probability1) return rock;
                return triangle;
            case 6:
                probability1 += 5;
                if (rnd1 < probability1) return earth;
                probability1 += 4;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 300;
                if (rnd1 < probability1) return rock_gold;
                probability1 += 450;
                if (rnd1 < probability1) return rock_red;
                return rock;
            case 7:
                probability1 += 5;
                if (rnd1 < probability1) return sun;
                probability1 += 30;
                if (rnd1 < probability1) return earth;
                probability1 += 10;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 450;
                if (rnd1 < probability1) return rock_gold;
                return rock_red;
            case 8:
                probability1 += 30;
                if (rnd1 < probability1) return sun;
                probability1 += 90;
                if (rnd1 < probability1) return earth;
                probability1 += 50;
                if (rnd1 < probability1) return rock_dia;
                probability1 += 300;
                if (rnd1 < probability1) return rock_gold;
                return rock_red;
            case 9:
                probability1 += 3;
                if (rnd1 < probability1) return galaxy;
                probability1 += 90;
                if (rnd1 < probability1) return sun;
                probability1 += 200;
                if (rnd1 < probability1) return earth;
                probability1 += 100;
                if (rnd1 < probability1) return rock_dia;
                return rock_gold;
            case 10:
                probability1 += 10;
                if (rnd1 < probability1) return galaxy;
                probability1 += 150;
                if (rnd1 < probability1) return sun;
                probability1 += 300;
                if (rnd1 < probability1) return earth;
                probability1 += 400;
                if (rnd1 < probability1) return rock_dia;
                return rock_gold;
            default:
                probability1 += 15;
                if (rnd1 < probability1) return galaxy;
                probability1 += 300;
                if (rnd1 < probability1) return sun;
                probability1 += 300;
                if (rnd1 < probability1) return earth;
                probability1 += 200;
                if (rnd1 < probability1) return rock_dia;
                return rock_gold;
        }
        
    }
    public GameObject GetRandomEnemy()
    {
        probability2 = 0;
        int rnd2 = Random.Range(0, 1000);
        probability2 += 25;
        if (rnd2 < probability2) return enemy4;
        probability2 += 75;
        if (rnd2 < probability2) return enemy3;
        probability2 += 175;
        if (rnd2 < probability2) return enemy2;
        probability2 +=225;
        if (rnd2 < probability2) return enemy1;
        return bomb;
    }

    
    public void GenerateEnemyBullet(Vector2 pos,Vector2 toPlayer,float speed)
    {
        Instantiate(enemyBullet, pos, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = toPlayer.normalized * speed;
    }
    public void GenerateMagneticCircle()
    {
        Instantiate(magneticCircle, canvasTransform);

    }
    public void GenerateScoreupText(int score)
    {
        Instantiate(scoreupText, canvasTransform).GetComponent<TextMeshProUGUI>().text = "+"+score.ToString();
    }
    public void GenerateMassRandom(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(GetRandomMass(), Director.instance.GenerateRandomPos(), Quaternion.identity);
            generatenum++;
        }
    }
    public void GenerateEnemyRandom(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(GetRandomEnemy(), Director.instance.GenerateRandomPos(), Quaternion.identity);
            generatenum++;
        }
    }
}