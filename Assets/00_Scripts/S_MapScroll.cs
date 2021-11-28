using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_MapScroll : MonoBehaviour
{
    [SerializeField] S_UIManager ui;

    /*
    [SerializeField, Range(0f, 10f)] public float F_speed = 0f;
    [SerializeField, Range(0f, 10f)] public float M_speed = 0f;
    [SerializeField, Range(0f, 10f)] public float B_speed = 0f;
    */
    //0 = front, 1 = mid, 2 = back//

    [SerializeField] GameObject AllMap;
    [SerializeField] GameObject[] mapList = new GameObject[3];

    [SerializeField, Range(0f, 10f)] public float M_speed = 0f;

    [SerializeField] SO_Object so_Object;
    [SerializeField] SO_Player so_player;
    [SerializeField] SO_Setting so_Setting;

    //임시용
    [SerializeField] Sprite[] BackSprite;
    [SerializeField] GameObject[] BackImage;

    float A_speed = 1;
    Vector3 last_Position;
    int mapNum = 0;

    private void Awake()
    {
        A_speed = so_Setting.Game_Speed;
        last_Position = new Vector3(mapList[2].transform.position.x - 1.2f, 0f, 0f);
    }
    void Update()
    {
        if (so_Object.IsEnabled == false && so_player.IsMove)
        {
            /*
            mapList[0].transform.Translate(-F_speed * Time.deltaTime * A_speed, 0, 0);
            mapList[1].transform.Translate(-M_speed * Time.deltaTime * A_speed, 0, 0);
            mapList[2].transform.Translate(-B_speed * Time.deltaTime * A_speed, 0, 0);
            */
            AllMap.transform.Translate(-M_speed * Time.deltaTime * A_speed, 0, 0);
        }

        if(mapList[mapNum].transform.position.x <= -22f)
        {
            mapList[mapNum].transform.position = last_Position;
            last_Position = mapList[mapNum].transform.position;
            mapNum++;

            if (mapNum >= mapList.Length)
            {
                mapNum = 0;

                int dayCount = int.Parse(so_Object.DayCount) + 1;
                if(dayCount > 12)
                {
                    //엔딩
                }
                else
                {
                    if(dayCount < 4)
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[0];
                        }
                    }
                    else if(dayCount >= 4 && dayCount < 8)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[1];
                        }
                    }
                    else if(dayCount >= 8 && dayCount < 12)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[2];
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            BackImage[i].GetComponent<SpriteRenderer>().sprite = BackSprite[3];
                        }
                    }
                    so_Object.setDay(dayCount);
                }
            }
        }
    }

    public void SpeedSet(float _speed)
    {
        if(A_speed > 0.5f && _speed < 0)
        {
            A_speed -= 0.5f;
        }
        else if(A_speed < 5f && _speed > 0)
        {
            A_speed += 0.5f;
        }

        so_Setting.SpeedSet(A_speed);
        ui.SpeedText(so_Setting.Game_Speed);
    }
}
