using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Cube cube;
    public Vector3 cameraPoffset = new Vector3(20, 20, 20);
    public Transform cameraTr;
    private void Awake() =>cameraTr = Camera.main.transform;
    void Start()
    {
        previousCubeTr = cube;
        InitCamera();
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
    private void InitCamera()
    {
        var cubeTr = cube.transform;
        var newPos = cubeTr.position + cameraPoffset;
        cameraTr.position = newPos;
        cameraTr.LookAt(cubeTr);
    }
    void MoveCamera()=> cameraTr.Translate(0, cube.ChildScale.y, 0);

    Cube previousCubeTr;
    private void MakeCube()
    {
        var newRot = Quaternion.Euler(0, GetRotation(level), 0);
        var newPos = previousCubeTr.ChildPos;
        newPos.y += previousCubeTr.ChildScale.y;

        var newCube = Instantiate(previousCubeTr, newPos, newRot);

        if (previousCubeTr != null)
        {
            // todo:�ִϸ����� ���ߴ� ��� ���� �ڽ� �ı��ϰ� ���ο� �ڽ� �����ؾ��Ѵ�.
            previousCubeTr.GetComponentInChildren<Animator>().enabled = false;
        }

        previousCubeTr = newCube;
        level++;
    }


    // Level�� Ȧ�� �϶��� 0, ¦���϶��� 90
    private float GetRotation(int level) => level % 2 == 0 ? 90 : 0;
}
