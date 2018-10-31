using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContents : MonoBehaviour {

    public string playerName;
    public int playerHp;
    public int playerMp;
    public float moveSpeed;
    public bool Invincible;
    

    private string allinformation;
    private GameObject pullme;
    private bool hurt=false;
    public TextMesh playercontent;
    Vector2 r ;
    Vector2 pos1;
    Vector3 pos2 ;

    private void Start()
    {
        Debug.Log("Player Name = " + playerName); //顯示玩家名字
        Debug.Log("Player Hp = " + playerHp); //顯示玩家血量
        Debug.Log("Player Mp = " + playerMp); //顯示玩家魔力
        Debug.Log("Invincible = " + Invincible); //顯示玩家是否死亡
        pullme = GameObject.FindWithTag("pullme");
        allinformation= "Player Name = " + playerName + "\n" +"Player Hp = " + playerHp + "\n" +"Player Mp = " + playerMp;
        playercontent.text = allinformation.ToString();
       // InvokeRepeating("CreateCube", 1f, 1f);
    }
    private void Update()
    {
        if (hurt)
        {
            playercontent.text = "Player Name = " + playerName + "\n" +
                    "Player Hp = " + playerHp + "\n" +
                    "Player Mp = " + playerMp;
            hurt = false;

        }
    }
    //碰撞器是否碰到物體
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag=="pullme")
        {
            Destroy(col.gameObject);
            playerHp -= 10;
            hurt = true;
        }
        if (col.collider.tag == "Bomb")
        {
            Destroy(col.gameObject);
            playerHp -= 30;
            hurt = true;
        }
    }
    
    //新增方塊
    public void CreateCube()
    {

        r = Random.insideUnitCircle * 7;//半徑0-7的圓
        pos1 = r.normalized * (3+ r.magnitude);//半徑3-10的圓
        pos2 = new Vector3(this.transform.position.x + pos1.x, 0.5f, this.transform.position.z + pos1.y);
        GameObject pull=  Instantiate(pullme, pos2, Quaternion.identity) as GameObject;
       
    }
    private void InstantiateClub()
    {
        
    }

}
