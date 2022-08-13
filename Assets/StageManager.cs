using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject cube;
    public Vector3 cameraPoffset = new Vector3(20, 20, 20);
    void Start()
    {
        previousCubeTr = cube.transform;
        MoveCamera();
    }

    public int level;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakeCube();
            MoveCamera();
        }
    }

    [ContextMenu("Set Camera")]
    private void MoveCamera()
    {
        var cubeTr = previousCubeTr != null ? previousCubeTr : cube.transform;
        var newPos = cubeTr.position + cameraPoffset;
        Camera.main.transform.position = newPos;
        Camera.main.transform.LookAt(cubeTr);
    }

    Transform previousCubeTr;
    private void MakeCube()
    {
        var newRot = Quaternion.Euler(0, GetRotation(level), 0);
        var newPos = previousCubeTr.position;
        newPos.y += previousCubeTr.localScale.y;

        var newCube = Instantiate(previousCubeTr, newPos, newRot);

        if (previousCubeTr != null)
        {
            // todo:애니메이터 멈추는 대신 기존 박스 파괴하고 새로운 박스 생성해야한다.
            previousCubeTr.GetComponentInChildren<Animator>().enabled = false;
        }

        previousCubeTr = newCube.transform;
        level++;
    }


    // Level이 홀수 일때는 0, 짝수일때는 90
    private float GetRotation(int level) => level % 2 == 0 ? 90 : 0;
}
