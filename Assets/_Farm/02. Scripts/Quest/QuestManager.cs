using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : SingletonCore<QuestManager>, ISubject
{
    public List<IObserver> observers { get; private set; } = new List<IObserver>();

    [SerializeField] private Button[] questButtons;
    [SerializeField] private QuestData[] datas;

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
        Debug.Log($"퀘스트 {observer.QuestName}을 등록하였습니다.");
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
        Debug.Log($"퀘스트 {observer.QuestName}을 삭제하였습니다.");
    }

    public void NotifyListener(string questName)
    {
        
    }
}
