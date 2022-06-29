using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace CaseStudyAPITesting.CommonMethodsObj
{
    [Binding]
    class APIObj
    {
        public string baseUrl = "http://dummy.restapiexample.com/api/v1";
        public RestResponse response;
        public dynamic id;
        public dynamic deserializeAPI;

        public void GetListOfUsersRequest()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("/employees", Method.Get);
            response = client.Execute(request);
        }

        public void VerifyGetResult()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            var value = deserializeAPI.data[1].employee_name;
            Assert.AreEqual("Garrett Winters", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void PostRequestforCreateUser()
        {
            RestClient clint = new RestClient(baseUrl);
            RestRequest request = new RestRequest("/create", Method.Post);
            request.AddBody("{\"name\":\"mrnobody\",\"salary\":\"6000\"}");
            response = clint.Execute(request);
        }

        public void VerifyPostResult()
        {
            
           
          
                deserializeAPI = JsonConvert.DeserializeObject(response.Content);          
                var value = deserializeAPI.data.name;
                Assert.AreEqual("mrnobody", value.Value);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                id = deserializeAPI.data.id.Value;
            
           
        }

        public void CreateTextFile()
        {
            string filePath = @"C:\Users\mindtreefeb65\source\repos\TestProject2\Id.txt";
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                using (FileStream fs = File.Create(filePath))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    Byte[] author = new UTF8Encoding(true).GetBytes("Automation");
                    fs.Write(author, 0, author.Length);

                }
                using (StreamWriter sq = File.CreateText(filePath))
                {
                    sq.WriteLine(id);
                }
            }
            catch { }
        }

        public void ReadTextFile()
        {
            string filePath = @"C:\Users\mindtreefeb65\source\repos\CaseStudyAPITesting\CaseStudyAPITesting\Id.txt";

            using (StreamReader sr = File.OpenText(filePath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    id = s;
                }
            }
        }

        public void DeleteUser()
        {
            RestClient clint = new RestClient(baseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/delete/" +id, Method.Delete);
            response = clint.Execute(request);
        }

        public void VerifyDeleteResult()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
