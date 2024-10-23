
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class GridRenderer: MonoBehaviour {

    public Vector2Int size;
    public Color color = Color.white;
    public float line_width = 0.1f;

    //--------------------------------------------------

    public void SetSize (Vector2Int size) {

        this.size = size;
    }

    //--------------------------------------------------

    public void DrawGrid () {

        DestroyGrid ();
        CreateGrid ();
    }

    //--------------------------------------------------

    public void CreateGrid () {

        // Vertical
        Vector3 line_start = new Vector3 (-(float) size.x / 2, -(float) size.y / 2, 0);
        Vector3 line_end   = new Vector3 (-(float) size.x / 2,  (float) size.y / 2, 0);
        for (int i = 0; i <= size.x; i++) {

            CreateLine (line_start, line_end);
            line_start.x += 1;
            line_end.x   += 1;
        }

        //--------------------------------------------------

        // Horizontal
        line_start = new Vector3 (-(float) size.x / 2, -(float) size.y / 2, 0);
        line_end   = new Vector3 ( (float) size.x / 2, -(float) size.y / 2, 0);
        for (int i = 0; i <= size.y; i++) {

            CreateLine (line_start, line_end);
            line_start.y += 1;
            line_end.y   += 1;
        }
    }

    private void CreateLine (Vector3 line_start, Vector3 line_end) {

        GameObject lineObject = new GameObject ("Line");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer> ();
        lineObject.transform.parent = transform;
        lineObject.transform.localPosition = Vector3.zero;

        lineRenderer.useWorldSpace = false;

        lineRenderer.startWidth = line_width;
        lineRenderer.endWidth   = line_width;
        lineRenderer.material   = new Material (Shader.Find ("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor   = color;

        //--------------------------------------------------
        // line positions

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition (0, line_start);
        lineRenderer.SetPosition (1, line_end);
    }

    private void DestroyGrid () {

        // copy children
        Transform [] children = new Transform [transform.childCount];
        for (int i = 0; i < transform.childCount; i++) children[i] = transform.GetChild(i);

        // destroy children
        foreach (Transform child in children) Destroy(child.gameObject);
    }
}