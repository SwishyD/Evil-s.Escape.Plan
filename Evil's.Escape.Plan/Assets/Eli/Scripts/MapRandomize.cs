using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapRandomize : MonoBehaviour
{
    public static MapRandomize instance;

    [SerializeField]
    private Image[] roomChoosen;
    public Sprite[] rooms;
    private Image choosenImage;

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
        foreach (Image choosen in roomChoosen)
        {
            choosenImage = choosen;
            pickRoom();
        }
    }

    private void pickRoom()
    {
        int roomNumber = Random.Range(0, rooms.Length);
        Debug.Log(rooms[roomNumber]);
        choosenImage.sprite = rooms[roomNumber];
    }

    public void repickRoom(Image oldImage)
    {
        Sprite[] newRooms = rooms.Where(s => s != rooms[4]).ToArray();
        int roomNumber = Random.Range(0,newRooms.Length);
        Debug.Log("New Room is " + newRooms[roomNumber]);
        oldImage.sprite = newRooms[roomNumber];
        
        if (oldImage.sprite == rooms[0])
        {
            Debug.Log("Battle Room is Loading");
            //SceneManager.LoadScene("Battle");
            FindObjectOfType<AudioManager>().Play("Danger");
        }
        else if (oldImage.sprite == rooms[1])
        {
            Debug.Log("Campfire Room is Loading");
            //SceneManager.LoadScene("Campfire");
        }
        else if (oldImage.sprite == rooms[2])
        {
            Debug.Log("Treasure Room is Loading");
            //SceneManager.LoadScene("Treasure");
        }
        else if (oldImage.sprite == rooms[3])
        {
            Debug.Log("Demon Room is Loading");
            //SceneManager.LoadScene("Demon");
        }
    }
}
