using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int arrayPos;

    private bool isCreate = false;
    
    public void CreateCrop(GameObject cropPrefab) // 타일의 자식으로 작물 생성 기능
    {
        if (isCreate)
            return;

        GameObject cropObj = Instantiate(cropPrefab);
        cropObj.transform.SetParent(transform);
        cropObj.transform.localPosition = Vector3.zero;

        isCreate = true;
    }
}