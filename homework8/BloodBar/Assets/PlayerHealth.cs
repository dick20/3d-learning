using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private float HP = 1000;
    private Camera camera;
    public GameObject player;
    public Texture2D blood_red_texture;
    public Texture2D blood_black_texture;

    void Start()
    {
        camera = Camera.main;
    }

    void OnGUI()
    {
        if (this.transform.position.z < 9)
        {
            HP--;
        }
        else
        {
            HP++;
        }
        if (HP > 1000f)
        {
            HP = 1000f;
        }
        if (HP < 0.0f)
        {
            HP = 0.0f;
        }
        //3D坐标换算成2D坐标
        Vector3 worldPosition = new Vector3(this.transform.position.x, this.transform.position.y , this.transform.position.z);
        Vector2 position = camera.WorldToScreenPoint(worldPosition);

        Debug.Log(position);
        //Player的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        //黑色血条的长宽
        Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red_texture));
        bloodSize.x -= 250;
        //红色血条宽度
        float blood_width = (bloodSize.x) * HP / 1000;
        //黑色血条
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y+420, bloodSize.x, 20), blood_black_texture);
        //红色血条,将黑色血条覆盖住
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - bloodSize.y+420, blood_width, 20), blood_red_texture);
    }
    }