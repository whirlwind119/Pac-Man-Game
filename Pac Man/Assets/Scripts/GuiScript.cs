using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuiScript : MonoBehaviour {

    float native_width = 1920;
    float native_height = 1080;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    string calculateScore(int cur_score) {
        string temp = NewBehaviourScript.score.ToString();
        int temp_length = temp.Length;
        while(temp_length < 5) {
            temp = "0" + temp;
            temp_length++;
        }
        string to_return = temp[0] + "\n" + temp[1] + "\n" + temp[2] + "\n" + temp[3] + "\n" + temp[4];
        return to_return;
    }

    void OnGUI() {
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));

        GUI.Label(new Rect(native_width / 2, native_height / 2, 400, 150), "Game\nScore\n" + calculateScore(NewBehaviourScript.score));

    }
}
