using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FHWebAPIClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53375/");                                             //Client edilecek domain
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //Veri çıktısı format tipi ->json
                HttpResponseMessage response;                                                                 //Http Mesajı
                response = client.GetAsync("api/StudentApi").Result;                                      //Web sayfasındaki kullanılacak Api
                if (response.IsSuccessStatusCode)
                {
                    var students = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    foreach (var ogrenci in students)
                    {
                        Console.WriteLine("ID: {0} - FirstName : {1} - LastName: {2} " +
                            "- Email: {3} - Mobile : {4} - Address : {5}",
                            ogrenci.Id, ogrenci.FirstName, ogrenci.LastName, ogrenci.Email, ogrenci.Mobile,ogrenci.Address);
                    }
                }
                Console.ReadKey();
            }
        }
        class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string Address { get; set; }
        }
    }
}
