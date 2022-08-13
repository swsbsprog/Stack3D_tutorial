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
            // todo:�ִϸ����� ���ߴ� ��� ���� �ڽ� �ı��ϰ� ���ο� �ڽ� �����ؾ��Ѵ�.
            previousCubeTr.GetComponentInChildren<Animator>().enabled = false;
        }

        previousCubeTr = newCube.transform;
        level++;
    }


    // Level�� Ȧ�� �϶��� 0, ¦���϶��� 90
    private float GetRotation(int level) => level % 2 == 0 ? 90 : 0;
}
