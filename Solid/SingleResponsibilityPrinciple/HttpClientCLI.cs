using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Solid.SingleResponsibilityPrinciple
{

// POST http://foo.bar.com/people -h:Content-Type=application/json -h:Accept=application/json -c:{"name":"Pradip"}
  public class HttpClientCLI
  {

    public void SendRequest(String input)
    {

      var args = input.Split(' ');
      var method = args[0];
      var url = args[1];
      var content = "";

      var client = new HttpClient();
      if (args.Length > 2)
      {
        for (int i = 3; i < args.Length; i++)
        {
          if (args[i].StartsWith("-h:"))
          {
            var header = args[i].Split('=');
            client.DefaultRequestHeaders.Add(header[0], header[1]);
          }
          else if (args[i].StartsWith("-c:"))
          {
            content = args[i];
          }
        }
      }

      Task<HttpResponseMessage> responseTask;

      switch (method)
      {
        case "POST":
          responseTask = client.PostAsync(url, new StringContent(content));
          break;
        case "PUT":
          responseTask = client.PutAsync(url, new StringContent(content));
          break;
        case "DELETE":
          responseTask = client.DeleteAsync(url);
          break;
        default:
          responseTask = client.GetAsync(url);
          break;
      }

      var response = responseTask.Result;
      if (response.StatusCode == System.Net.HttpStatusCode.OK)
      {
        string body = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(body);
      }
      else
      {
        Console.WriteLine($"{response.StatusCode} : {response.ReasonPhrase}");
      }

    }

  }

}