using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proj9MVCWebApiConsuming.Models;
using System.Text;

namespace Proj9MVCWebApiConsuming.Controllers
{
    public class EmpController : Controller
    {
        HttpClient client;
        public EmpController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPloicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
        }
        public IActionResult Index()
        {
            List<Emp> empList = new List<Emp>();
            string url = "https://localhost:7035/api/Emp/GetEmp/";
            HttpResponseMessage response=client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata=response.Content.ReadAsStringAsync().Result; //Jsondata converted to string
                var obj=JsonConvert.DeserializeObject<List<Emp>>(jsondata); //string converted to object using Newtonsoft.json tool (JsonConvert)
                if (obj != null)
                {
                    empList = obj;
                }
            }
            return View(empList);
        }
        public IActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            string url = "https://localhost:7035/api/Emp/AddEmp/";
            var jsondata = JsonConvert.SerializeObject(e);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url,content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DelEmp(int id)
        {
            string url = "https://localhost:7035/api/Emp/DelEmp/";
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(); 
        }  
        public IActionResult EditEmp(int id)
        {
            string url = "https://localhost:7035/api/Emp/EditEmp/";
            var jsondata = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PutAsync(url+id,content).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
 