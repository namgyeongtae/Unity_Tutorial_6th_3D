using UnityEngine;

public class Quest : IObserver
{
    private QuestData data;
    public string QuestName { get; }
    public int CurrentCount { get; private set; }
    public bool IsCompleted { get; private set; }

    public Quest(QuestData data)
    {
        this.data = data;
        QuestName = data.questName;

        QuestManager.Instance.AddObserver(this);
    }

    public void Notify(string questName)
    {
        if (questName == QuestName && !IsCompleted)
        {
            if (CurrentCount >= data.requestCount)
            {
                IsCompleted = true;
                Debug.Log($"{QuestName} 퀘스트 완료");
                QuestManager.Instance.RemoveObserver(this);
            }
        }
    }
}
