using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapRandomize : MonoBehaviour
{
    public static MapRandomize instance;

    [SerializeField]
    private Text[] roomChoosen;
    [SerializeField]
    private string[] rooms;
    private Text choosenText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

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

    public void repickRoom(Text oldText)
    {
        string[] newRooms = rooms.Where(s => s != "Random").ToArray();
        int roomNumber = Random.Range(0,newRooms.Length);
        Debug.Log("New Room is " + newRooms[roomNumber]);
        oldText.text = newRooms[roomNumber];

        if (oldText.text.Equals("Battle"))
        {
            FindObjectOfType<AudioManager>().Play("Danger");
        }
    }
}
