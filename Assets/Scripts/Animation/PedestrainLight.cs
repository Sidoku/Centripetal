using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrainLight : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private int pictureIndex = 0;
    private Sprite[] pictures = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        // pictures[0] = Resources.Load("Pictures/WalkSign_Green") as Sprite;
        // pictures[1] = Resources.Load("Pictures/WalkSign_Yellow") as Sprite;
        // pictures[2] = Resources.Load("Pictures/WalkSign_Red") as Sprite;
        pictures[0] = Resources.Load<Sprite>("Pictures/WalkSign_Green");
        pictures[1] = Resources.Load<Sprite>("Pictures/WalkSign_Yellow");
        pictures[2] = Resources.Load<Sprite>("Pictures/WalkSign_Red");
        StartCoroutine(ChangePictures(pictureIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangePictures(int index)
    {
        yield return new WaitForSeconds(1f);
        m_SpriteRenderer.sprite = pictures[index];
        if (index == 2)
        {
            index = -1;
        }
        StartCoroutine(ChangePictures(index + 1));
    }
}
