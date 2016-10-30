using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteSlicer2DDemoManager : MonoBehaviour
{
    public TimeManager timeManager;

    List<SpriteSlicer2DSliceInfo> m_SlicedSpriteInfo = new List<SpriteSlicer2DSliceInfo>();
    TrailRenderer m_TrailRenderer;

    struct MousePosition
    {
        public Vector3 m_WorldPosition;
        public float m_Time;
    }

    public float m_MouseRecordInterval = 0.05f;
    public int m_MaxMousePositions = 5;
    public bool m_FadeFragments = false;

    List<MousePosition> m_MousePositions = new List<MousePosition>();
    float m_MouseRecordTimer = 0.0f;

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        m_TrailRenderer = GetComponentInChildren<TrailRenderer>();
        m_FadeFragments = true;
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        // Right mouse button - explode any sprite the we click on
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = Camera.main.transform.position.z;

            RaycastHit2D rayCastResult = Physics2D.Raycast(mouseWorldPosition, new Vector3(0, 0, 0), 0.0f);

            //get points cause you hit a bird.
            bool birdHit = false;

            if (rayCastResult.rigidbody)
            {
                if (!rayCastResult.rigidbody.isKinematic)
                {
                    SpriteSlicer2D.ExplodeSprite(rayCastResult.rigidbody.gameObject, 16, 7.0f, true, ref m_SlicedSpriteInfo);
                    birdHit = true;
                    if (m_SlicedSpriteInfo.Count == 0)
                    {
                        // Couldn't cut for whatever reason, add some force anyway

                        rayCastResult.rigidbody.AddForce(new Vector2(0.0f, 4.0f));
                    }
                }
            }
            if (!timeManager.timeHasStopped())
            {
                timeManager.addClick(birdHit);
            }
        }

        else
        {
            m_MousePositions.Clear();
        }

        // Sliced sprites sharing the same layer as standard Unity sprites could increase the draw call count as
        // the engine will have to keep swapping between rendering SlicedSprites and Unity Sprites.To avoid this, 
        // move the newly sliced sprites either forward or back along the z-axis after they are created
        for (int spriteIndex = 0; spriteIndex < m_SlicedSpriteInfo.Count; spriteIndex++)
        {
            for (int childSprite = 0; childSprite < m_SlicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
            {
                Vector3 spritePosition = m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].transform.position;
                spritePosition.z = -1.0f;
                m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].transform.position = spritePosition;
                StartCoroutine(FadeOutCollider(m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].GetComponent<PolygonCollider2D>(), 0.01f));
            }
        }

        if (m_FadeFragments)
        {
            // If we've chosen to fade out fragments once an object is destroyed, add a fade and destroy component
            for (int spriteIndex = 0; spriteIndex < m_SlicedSpriteInfo.Count; spriteIndex++)
            {
                for (int childSprite = 0; childSprite < m_SlicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
                {
                    if (!m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].GetComponent<Rigidbody2D>().isKinematic)
                    {
                        m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].AddComponent<FadeAndDestroy>();
                    }
                }
            }
        }

        m_SlicedSpriteInfo.Clear();
    }

    IEnumerator FadeOutCollider(PolygonCollider2D childCollider, float fadeOutTime)
    {

        yield return new WaitForSeconds(fadeOutTime);
        if (childCollider != null)
        {
            childCollider.enabled = false;
        }
    }
}
