﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(0);

            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;
            Debug.LogFormat("{0} - x:{1}, y:{2}", id, pos.x, pos.y);
            if (id >= 0)
            {
                //指１本の場合
                if ((pos.x <= Screen.width / 2) && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                else if((pos.x >= Screen.width / 2) && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else
            {
                //同時に押されたか？
            }
            if (touch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
                //Debug.LogFormat("{0}:いま離された", id);
                //指１本の場合
                if ((pos.x <= Screen.width / 2) && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                else if ((pos.x >= Screen.width / 2) && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
                  
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
