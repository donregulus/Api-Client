using rfeTestCLIENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace rfeTestCLIENT.Controllers
{
    public class DiffController : Controller
    {
        string BaserURI = "https://localhost:7116/v1/diff/";

        class APIResult
        {
            public string result { set; get; }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostLeft()
        {
            return View();
        }


        [HttpPost]
        public ActionResult  PostLeft(Diff diff)
        {
            try
            {
                if (ModelState.IsValidField("Id") && ModelState.IsValidField("Left"))
                {
                    var client = new HttpClient();

                    //Set Base URL and clear every previous request
                    client.BaseAddress = new Uri(BaserURI);
                    client.DefaultRequestHeaders.Clear();

                    //Calling PostLeft request of rfeTestAPI
                    var res = client.PostAsJsonAsync<string>(diff.Id.ToString() + "/left", diff.Left);
                    res.Wait();

                    //Check the request result
                    if (res.Result.IsSuccessStatusCode)
                    {
                        //Redirect to Home Page
                        return Redirect("index");
                    }
                    else
                    {
                        //show message error
                        ModelState.AddModelError(string.Empty, "Can not Post the left value " + diff.Left + " at " + diff.Id.ToString());
                        return View(diff);
                    }
                }
                else
                {
                    return View(diff);
                }
            }
            catch (Exception )
            {
                //show message error
                ModelState.AddModelError(String.Empty,"Connection to API failed");
                return View(diff);

            }

        }

        public ActionResult PostRight()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PostRight(Diff diff)
        {
            try
            {
                if (ModelState.IsValidField("Id") && ModelState.IsValidField("Right"))
                {
                    var client = new HttpClient();
                    //Set Base URL and clear every previous request
                    client.BaseAddress = new Uri(BaserURI);
                    client.DefaultRequestHeaders.Clear();

                    //Calling PostLeft request of rfeTestAPI
                    var res = client.PostAsJsonAsync<string>(diff.Id.ToString() + "/right", diff.Right);
                    res.Wait();

                    //Check the request result
                    if (res.Result.IsSuccessStatusCode)
                    {
                        //Redirect to Home Page
                        return Redirect("index");
                    }
                    else
                    {
                        //show message error
                        ModelState.AddModelError(string.Empty, "Can not Post the right value " + diff.Right + " at " + diff.Id.ToString());
                        return View(diff);
                    }
                }
                else
                {
                    return View(diff);
                }
            }
            catch (Exception)
            {
                //show message error
                ModelState.AddModelError(String.Empty, "Connection to API failed");
                return View(diff);
            }
        }

        [HttpPost]
        public ActionResult CheckResults(Diff diff)
        {

            try
            {
                if (ModelState.IsValidField("ID"))
                {
                    var client = new HttpClient();

                    //Set Base URL and clear every previous request
                    client.BaseAddress = new Uri(BaserURI);
                    client.DefaultRequestHeaders.Clear();

                    //Calling PostLeft request of rfeTestAPI
                    var res = client.GetAsync(diff.Id.ToString());
                    res.Wait();
                    

                    //Check the request result
                    if (res.Result.IsSuccessStatusCode)
                    {
                        //Write message response
                        var resp = res.Result.Content.ReadFromJsonAsync<APIResult>().Result;                                  
                        ViewBag.Result = resp.result;
                        return View();
                    }
                    else
                    {
                        //show message error
                        ModelState.AddModelError(string.Empty, "Can not get result for ID : " + diff.Id.ToString());
                        return View(diff);
                    }
                }
                else
                {
                    return View(diff);
                }
            }
            catch (Exception)
            {
                //show message error
                ModelState.AddModelError(String.Empty, "Connection to API failed");
                return View(diff);
            }

        }

        
        public ActionResult CheckResults()
        {
            
            return View();
        }



    }
}