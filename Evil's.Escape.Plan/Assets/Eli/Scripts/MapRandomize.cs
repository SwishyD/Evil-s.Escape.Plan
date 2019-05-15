using UnityEngine;
using UnityEngine.UI;

public class MapRandomize : MonoBehaviour
{
    [SerializeField]
    private Text[] roomChoosen;
    [SerializeField]
    private string[] rooms;
    private Text choosenText;

    public void Start()
    {
        foreach (Text choosen in roomChoosen)
        {
            choosenText = choosen;
            pickRoom();
        }
    }

    private void pickRoom()
    {
        int roomNumber = Random.Range(0, rooms.Length);
        Debug.Log(rooms[roomNumber]);
        choosenText.text = rooms[roomNumber];
    }
}
