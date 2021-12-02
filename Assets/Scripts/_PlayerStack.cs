using UnityEngine;

public class _PlayerStack : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    private _GameManager gameManager;
    private _StackManager stackManager;

    private void Awake()
    {
      
        //Hierarchde player
        player = this.transform.root.gameObject;

        // DroplePlatformlarý býrakacak þekilde ayarlama
        gameManager = GameObject.Find("GameManager").GetComponent<_GameManager>();

        stackManager = player.GetComponent<_StackManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        // Platform and DropPlatform Trigger
        if (other.tag == "Platform")
        {
            other.tag = "Untagged";
            stackManager.StackPlatform(other.gameObject);

            //Yeni platformlar ekleme
            other.gameObject.AddComponent<_PlayerStack>();

            //Platformlarý yoketme
            Destroy(this);
        }
        else if (other.tag == "DropPlatform")
        {
            
            if (gameManager.PlatformUnder ==0)
            {
                //Yeterli platform yoksa karakteri geri yollama

                Vector3 playerVelocity = player.GetComponent<Rigidbody>().velocity;
                playerVelocity *= 1.5f;
                player.GetComponent<Rigidbody>().velocity -= playerVelocity;
                


            }
            // Eðer platformlarý almaya devam ediyorsa
            else
            {
                other.tag = "Untagged";
                stackManager.DropPlatform(other.gameObject,0);
                Destroy(this);
            }

        }
       
    }
    



}

