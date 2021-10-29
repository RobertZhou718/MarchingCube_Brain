using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nifti.NET;

public class Load : MonoBehaviour
{  
    public static float[,,] Brain;
    public static float[,,] Graymatter;
    Nifti.NET.Nifti File;
    // Start is called before the first frame update
    void Awake()
    {
        File = NiftiFile.Read("Assets/Resource/brain.nii");
        //Debug.Log(File[200,300,300]);
        Brain = new float[File.Dimensions[0], File.Dimensions[1], File.Dimensions[2]];
        Graymatter = new float[File.Dimensions[0], File.Dimensions[1], File.Dimensions[2]];

        for (int i = 0; i < File.Dimensions[0]; i++)
        {
            for (int j = 0; j < File.Dimensions[1]; j++)
            {
                for (int k = 0; k < File.Dimensions[2]; k++)
                {
                    var length = File[i, j, k];
                    Brain[i, j, k] = length;
                }
            }
        }
        Getthreshold();

    }

    void Getthreshold()
    {
        for (int i = 0; i < File.Dimensions[0]; i++)
        {
            for (int j = 0; j < File.Dimensions[1]; j++)
            {
                for (int k = 0; k < File.Dimensions[2]; k++)
                {
                    if (15 < Brain[i, j, k] && Brain[i, j, k] < 40)
                    {
                        Graymatter[i, j, k] = 1;
                    }
                    else
                    {
                        Graymatter[i, j, k] = 0;
                    }


                }
            }
        }
    }
}
