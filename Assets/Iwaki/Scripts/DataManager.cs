using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    const string fileName = "Ranking.json"; //jsonファイル名
    
    // コンポーネントから取得するよう
    RankingData _data;
    public RankingData Data => _data;

    // データを読み込んでインスタンスで保管しておく
    private void Awake()
    {
        var filePath = GetFilePath();

        //ファイルがないときファイルを作成
        if (!File.Exists(filePath))
        {
            Save(_data ??= new RankingData());
        }
        _data = Load();
    }

    private static string GetFilePath()
    {
        return $"{Application.dataPath}/{fileName}";
    }

    //jsonとしてデータを保存
    private static void Save(RankingData data)
    {
        string json = JsonUtility.ToJson(data); //jsonとして変換
        StreamWriter wr = new(GetFilePath(), false); //ファイル書き込み指定
        wr.WriteLine(json);                     //json変換した書き込み
        wr.Close();                             //ファイルを閉じる
    }

    //jsonファイルを読み込み
    private static RankingData Load()
    {
        var path = GetFilePath();
        if (File.Exists(path))
        {
            //jsonファイルを型に戻して返す
            return JsonUtility.FromJson<RankingData>(File.ReadAllText(path));
        }
        else
        {
            //ファイルが存在しなければ新しくセーブして返す
            var newData = new RankingData();
            Save(newData);
            return newData;
        }
    }

    /// <summary>
    /// ランキングにスコアを登録
    /// </summary>
    /// <param name="item"></param>
    public static void RegisterRank(RankingItem item)
    {
        var data = Load();

        for (int i = 0; i < RankingData.rankCount; i++)
        {
            if (data.ranks[i] == null)
            {
                data.ranks[i] = item;
            }

            // 入れ替え
            if (item.score > data.ranks[i].score)
            {
                (item, data.ranks[i]) = (data.ranks[i], item);
            }
        }

        Save(data);
    }

    public static void ResetRank()
    {
        Save(new RankingData()); //新しいデータで上書き保存
    }
}