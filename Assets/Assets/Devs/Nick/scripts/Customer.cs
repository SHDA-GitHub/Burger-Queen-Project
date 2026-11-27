using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
   NavMeshAgent agent;
    [SerializeField] Transform AgentDestination;
    private bool CustomerHasSpot;

    [SerializeField]List<string> Foods;
    [SerializeField] List<string> Drinks;
    public string Chosenfood;
    public string ChosenDrink;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CustomerHasSpot = false;
        ChooseItems();
        
    }

    
    void Update()
    {
        if( Vector3.Distance(AgentDestination.position, agent.transform.position) <= 0.1f)
        {
            agent.destination = agent.transform.position;
        }
        else if(Vector3.Distance(AgentDestination.position, agent.transform.position) >= 0.2f)
        { 
            agent.SetDestination(AgentDestination.position);
        }
           
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CustomerSpot") && CustomerHasSpot == false)
        {
            var CustomerSpotScript = other.gameObject.GetComponent<CustomerSpot>();
            if(CustomerSpotScript == null)return;
            else if(CustomerSpotScript.IsFree == true)
            {
                agent.SetDestination(other.gameObject.transform.position);
                AgentDestination = other.gameObject.transform;
                CustomerSpotScript.IsFree = false;
                CustomerHasSpot = true;
            }
            else return;
        }
    }
    private void ChooseItems()
    {
        int FoodChoise = Random.Range(0,Foods.Count);
        int DrinkChoise = Random.Range(0, Drinks.Count);
        Chosenfood = Foods[FoodChoise];
        ChosenDrink = Drinks[DrinkChoise];
        
    }
        
            
                
            
}

