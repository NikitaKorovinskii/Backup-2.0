
using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using NancyNew;
using server.BdTable;
using Server;

class Program
{
    static void Main(string[] args)
    {
        var uri = new Uri("http://localhost:1234");

        HostConfiguration hostConfiguration = new HostConfiguration();
        hostConfiguration.UrlReservations.CreateAutomatically = true;


        using (var host = new NancyHost(uri, new Bootstrapper(), hostConfiguration))
        {
            host.Start();

            Console.WriteLine("Your application is running on " + uri);
            Console.WriteLine("Press any [Enter] to close the host.");
            Console.ReadLine();
            /*SMTPSender n = new SMTPSender();
            n.SendUsual();*/
          
        }
    }
}


public class HomeModule : NancyModule
{
    public string FIO;
    public HomeModule()
    {
       Auth human = new Auth();
       human = new() { Login = "Anthony" };
        Get("/", args => "Олег лучший парень на деревне");
        Get("/SayHello", args => $"Hello {this.Request.Query["name"]}");
        Get("/SayHello2/{name}", args => $"Hello {args.name}");
        Get("/Human", args => $"{human.Login}");
        Post("/humanity", (x) =>
        {
            x = this.Bind<Client>();

            var res = new Response();

            res.StatusCode = (HttpStatusCode)200;
            res.Headers["Access-Control-Allow-Origin"] = "*";
            res.Headers["Access-Control-Allow-Method"] = "POST";
            res.Headers["Access-Control-Expose-Headers"] = "Human";
            res.Headers["Content-Type"] = "application/json";
            res.Headers["Human"] = System.Text.Json.JsonSerializer.Serialize(human);
            Console.WriteLine(x.Login);

            Console.WriteLine(x.Password);
            return res;
        });
        Post("/authorization", (x) =>
        {
            Client infoHuman = new Client();
            Auth client = new Auth();
            x = this.Bind<Client>();
            dynamic c = this.Bind<Auth>();

            var res = new Response();

            res.StatusCode = (HttpStatusCode)200;
            res.Headers["Access-Control-Allow-Origin"] = "*";
            res.Headers["Access-Control-Allow-Method"] = "POST";
            res.Headers["Access-Control-Expose-Headers"] = "Human";
            res.Headers["Content-Type"] = "application/json";
             res.Headers["Human"] = System.Text.Json.JsonSerializer.Serialize(human);
            Console.WriteLine(c.password);
            return res;
        });
        Post("/auth", async (x) =>
        {
           x = this.Bind<Auth>();
           Auth acc;
            //TODO: Add JWT
            string login = x.Login;
            string password = x.Password;

     
        Response response = new();

      

                response.StatusCode = HttpStatusCode.OK;
                response.Headers["Access-Control-Allow-Origin"] = "*";
                response.Headers["Access-Control-Allow-Method"] = "POST";

                string myToken = "lalala.somestring.secretword";
                response.Headers["Token"] = myToken;
                response.Headers["Access-Control-Expose-Headers"] = "Token, Account";
                response.Headers["Content-Type"] = "application/json";

            Console.WriteLine(x.Login + " " + x.Password);
            return response;
            
           
        });
    }
}