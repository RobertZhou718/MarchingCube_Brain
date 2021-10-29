using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    Vector3 GridSize;
    public Material material = null;
    private Mesh mesh = null;
    // Start is called before the first frame update
    void Start()
    {
        GridSize = new Vector3(Load.Brain.GetLength(0), Load.Brain.GetLength(1), Load.Brain.GetLength(2));
        MakeGrid();
        Generatemesh();
    }

    private void MakeGrid() {
        MarchingCubes.grd = new float[(int)GridSize.x, (int)GridSize.y, (int)GridSize.z];
        for (int z = 0; z < GridSize.z; z++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                for (int x = 0; x < GridSize.x; x++)
                {
                    if (Load.Graymatter[x, y, z] == 1) {
                        MarchingCubes.grd[x, y, z] = 1;
                    }
                    else {
                        MarchingCubes.grd[x, y, z] = Load.Brain[x, y, z];
                    }
                }
            }
        }
    }
    public void Generatemesh() {
        GameObject go = this.gameObject;
        mesh = GetMesh(ref go, ref material);
        MarchingCubes.MarchCube();
        SetMesh(ref mesh);
    }
    public static Mesh GetMesh(ref GameObject go, ref Material material)
    {
        Mesh mesh = null;
        MeshFilter mf = go.GetComponent<MeshFilter>(); //add meshfilter component
        if (mf == null)
        {
            mf = go.AddComponent<MeshFilter>();
        }
        MeshRenderer mr = go.GetComponent<MeshRenderer>(); //add meshrenderer component
        if (mr == null)
        {
            mr = go.AddComponent<MeshRenderer>();
        }
        mr.material = material;
        mesh = mf.mesh;
        if (mesh == null)
        {
            mf.mesh = new Mesh();
            mesh = mf.mesh;
        }
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32; //increase max vertices per mesh
        mesh.name = "Mesh";
        return mesh;
    }
    public static void SetMesh(ref Mesh mesh)
    {
        //our mesh data to meshfilter
        mesh.Clear();
        mesh.vertices = MarchingCubes.vertices.ToArray();
        mesh.triangles = MarchingCubes.triangles.ToArray();
        mesh.uv = MarchingCubes.uv.ToArray();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
