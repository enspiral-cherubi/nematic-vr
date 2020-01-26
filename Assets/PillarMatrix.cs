using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMatrix : MonoBehaviour
{

    static int iwidth = 1000;
    static int jwidth = 1000;
    public GameObject[][] pillars = new GameObject[iwidth][];

    public float ixrot = 1f;
    public float iyrot = 1f;
    public float izrot = 1f;
    public float jxrot = 1f;
    public float jyrot = 1f;
    public float jzrot = 1f;
    public Vector3 origin = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {

      for (int i = 0; i < iwidth; i++) {
        pillars[i] = new GameObject[jwidth];
        for (int j = 0; j < jwidth; j++) {
          pillars[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
          pillars[i][j].transform.parent = transform;
          pillars[i][j].transform.position = new Vector3(i-iwidth/2,j-jwidth/2,0);
          pillars[i][j].transform.localScale = new Vector3(0.1f,0.1f,2f);
        }
      }

    }

    // Update is called once per frame
    void Update()
    {
      for (int i = 0; i < iwidth; i++) {
        for (int j = 0; j < jwidth; j++) {
          pillars[i][j].transform.RotateAround(origin, Vector3.forward, (i-iwidth/2)*ixrot * Time.deltaTime*0.01f + (j-jwidth/2)*jxrot * Time.deltaTime*0.01f);
          pillars[i][j].transform.RotateAround(origin, Vector3.up, (i-iwidth/2)*iyrot * Time.deltaTime*0.01f + (j-jwidth/2)*jyrot * Time.deltaTime*0.01f);
          pillars[i][j].transform.RotateAround(origin, Vector3.right, (i-iwidth/2)*izrot * Time.deltaTime*0.01f + (j-jwidth/2)*jzrot * Time.deltaTime*0.01f);
        }
      }
    }
}
