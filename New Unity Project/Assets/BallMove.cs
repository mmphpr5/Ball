using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    GameManager gameManager;
    RectTransform rect;
    Rigidbody2D rb;
    public float direction = 270.0f;
    public GameObject particle;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        rect = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.down * gameManager.speed;
        rb.AddForce(Vector2.down * gameManager.speed);
        //direction = 270.0f;
        //direction = 270.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // パーティクル
        //if (!gameManager.startFlag)
        //{
        //    Instantiate(particle, new Vector3(transform.position.x, transform.position.y, -50f), Quaternion.identity);
        //    Destroy(gameObject);
        //}

        // 移動処理
        //rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - gameManager.speed);
        //Vector2 v;
        //v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * gameManager.speed;
        //v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * gameManager.speed;
        //v.x += rect.anchoredPosition.x;
        //v.y += rect.anchoredPosition.y;

        //rb.velocity = v;
        //rd.position = v;
        //rect.anchoredPosition = v;

        this.lastVelocity = rb.velocity * 0.5f;
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    //gameManager.rhyzhmButtonList
    //    //    .RemoveAt(gameManager.rhyzhmPrefabList.IndexOf(gameObject));
    //    //gameManager.rhyzhmPrefabList.Remove(gameObject);
    //    //Destroy(gameObject);

    //    //Vector2.Reflect(direction, other.compositecontacts[0].normal);

    //    direction = 180.0f;
    //}
    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal);
        this.rb.velocity = refrectVec;
    }

    void OnDestroy()
    {
        gameManager.LeadIconDecide();
        if (!gameManager.startFlag)
        {
            gameManager.rhyzhmButtonList.Clear();
            gameManager.rhyzhmPrefabList.Clear();
        }
    }

    //bool TestSidePlane(float start, float end, float negd, ref List<float> list)
    //{
    //    float denom = end - start;
    //    //if (Math::NearZero(denom))
    //    //{
    //    //    return false;
    //    //}
    //    //else
    //    //{
    //    float numer = -start + negd;
    //    float t = numer / denom;
    //    // t が 範囲 内 に ある こと を テスト
    //    if (t >= 0.0f && t <= 1.0f)
    //    {
    //        list.Add(t);
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //    //}
    //}

    //bool Intersect(ref Vector2 l, ref AABB aabb, out float outT)
    //{
    //    // 可能性 の ある t の 値 を すべて 保存 する 配列
    //    //std:: vector < float > tValues;
    //    List<float> tValues = new List<float>();
    //    // x 平面 を テスト 
    //    TestSidePlane(l.mStart.x, l.mEnd.x, aabb.mMin.x, tValues);
    //    TestSidePlane(l.mStart.x, l.mEnd.x, aabb.mMax.x, tValues);
    //    // y 平面 を テスト
    //    TestSidePlane(l.mStart.y, l.mEnd.y, aabb.mMin.y, tValues);
    //    TestSidePlane(l.mStart.y, l.mEnd.y, aabb.mMax.y, tValues);
    //    //// z 平面 を テスト 
    //    //TestSidePlane( l. mStart. z, l. mEnd. z, b. mMin. z, tValues);
    //    //TestSidePlane( l. mStart. z, l. mEnd. z, b. mMax. z, tValues);
    //    // t の 値 を 小さい 順 に ソート 
    //    //std:: sort( tValues. begin(), tValues. end());
    //    tValues.Sort();//昇順
    //    // ボックス に、 交点 が 含ま れる のか テスト
    //    Vector3 point;
    //    foreach (float t in tValues)
    //    {
    //        point = l.PointOnSegment(t);
    //        if (b.Contains(point))
    //        {
    //            outT = t;
    //            return true;
    //        }
    //    }
    //    // ボックス の 内部 に 交点 が 1 つも ない
    //    return false;
    //}

}
