using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    // Start is called before the first frame update
    void Start()
    {
        mat.setIdentity();
        Question2();
        mat.Print();
    }

    HMatrix2D Question2()
    {
        // Declare and initialize mat1
        HMatrix2D mat1 = new HMatrix2D(
            1, 2, 1,
            0, 1, 0,
            2, 3, 4);

        // Declare and initialize mat2
        HMatrix2D mat2 = new HMatrix2D(
            2, 5, 9,
            6, 7, 3,
            1, 8, 0);

        // Declare resultMat and initialize it with the result of mat1 * mat2
        HMatrix2D resultMat = mat1 * mat2;

        // Declare and initialize vec1
        HVector2D vec1 = new HVector2D(2, 5);

        HVector2D resultVec = mat1 * vec1;

        Debug.Log("Matrix 1:");
        mat1.Print();

        Debug.Log("Matrix 2:");
        mat2.Print();

        Debug.Log("Vector 1:");
        Debug.Log($"x: {vec1.x}, y: {vec1.y}");

        resultMat.Print();
        resultVec.Print();
        return resultMat;
    }
}
