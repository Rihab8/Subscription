using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace MiniProject.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        public Subscription GetSubscriptionDetails(int subscriptionId)
        {
            var drug = SubscriptionHelper.SubscriptionDetails.FirstOrDefault(x => x.SubscriptionId == subscriptionId);
            if (drug == null)
            {
                return null;
            }
            return drug;

        }

        //Adds Subscription Details if the user required is available
        public Subscription AddSubscription(Subscription subscription)
        {
            bool flag =true;

            using (var client = new HttpClient())
            {
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SubscriptionHelper.SessionToken);

                client.BaseAddress = new Uri("http://52.230.228.30/api/");//Target Web Api

                 var responseTask = client.GetAsync("DrugsApi/SearchDrugsById/" + subscription.DrugId);
                 responseTask.Wait();
                 var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;

                    Drugs drug = JsonConvert.DeserializeObject<Drugs>(data);

                    SubscriptionHelper.SubscriptionDetails.Add(subscription);
    
                }
                else
                {
                    flag = false;
                }

               
                   
             }
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SubscriptionHelper.SessionToken);
                client.BaseAddress = new Uri("http://52.238.255.194/api/");


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

                //HTTP POST Request 
                var responseTask = client.PostAsync("Refill/AddRefillStatus", content);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    
                }
                else
                {
                    flag = false;
                }

            }
            if (flag) return null;
            return subscription;

        } 

        //Checks Amount Status and Unsubscribes if NO Dues
        public Subscription RemoveSubscription(int drugId)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SubscriptionHelper.SessionToken);
                var subscription = SubscriptionHelper.SubscriptionDetails.SingleOrDefault(s => s.DrugId == drugId);
                if (subscription == null) return null;
             
                client.BaseAddress = new Uri("http://52.238.255.194/api/");
                
                var responseTask = client.GetAsync("Refill/GetRefillStatus/" + subscription.SubscriptionId);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    RefillOrder refill = JsonConvert.DeserializeObject<RefillOrder>(data);
                    RefillOrder status = new RefillOrder();


                    string subStatus = status.Payment;


                    if (refill.Payment.Equals("Clear"))
                    {
                        
                        SubscriptionHelper.SubscriptionDetails.Remove(subscription);
                        return subscription;
                    }



                }
                return null;
            }
        }

       

        public List<Subscription> GetAllSubscription()
        {
            return SubscriptionHelper.SubscriptionDetails;
        }







    }
        //Gets all subscribed users details
        

       

        


    }

    
