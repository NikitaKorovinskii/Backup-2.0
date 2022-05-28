
using Nancy;
using Nancy.Hosting.Self;
using Nancy.ModelBinding;
using NancyNew;
using server;
using server.BdTable;
using Server;
using System.Linq;

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
        Get("/cars", args => 
        {
            using (work100013Context db = new())
            {
                List<Car> car = db.Cars.ToList();
            }
        });
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
           
            x = this.Bind<Client>();
            

            var res = new Response();

            using (work100013Context db = new())
            {
                string pasID = x.Passport;
                int idClient = 0;
                Client client = new Client
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    DataOfBith = x.DataOfBith,
                    Number = x.Number,
                    Passport = x.Passport,
                    NumberDriver = x.NumberDriver,
                };
                db.Clients.Add(client);
                db.SaveChanges();
                var list = db.Clients.Where(p => p.Passport == pasID);
                foreach (var u in list)
                {
                    idClient = u.IdClient;
                }
                Auth auth = new Auth
                {
                    Login = x.Number,
                    Email = x.Email,
                    Password = x.Password,
                    IdClient = idClient

                };
                db.Auths.Add(auth);
                db.SaveChanges();
                Console.WriteLine("Efdmspafm");
            }
            res.StatusCode = (HttpStatusCode)200;
            res.Headers["Access-Control-Allow-Origin"] = "*";
            res.Headers["Access-Control-Allow-Method"] = "POST";
            res.Headers["Access-Control-Expose-Headers"] = "Human";
            res.Headers["Content-Type"] = "application/json";
            res.Headers["Human"] = System.Text.Json.JsonSerializer.Serialize(human);

           
          
            return res;
        });
        Post("/auth", (x) =>
        {
            x = this.Bind<Auth>();
            //TODO: Add JWT
            string login = x.Login;
            string password = x.Password;
            int x1 = 0;
            using (work100013Context db = new())
            {
               var acc1 = db.Auths.Where(l => l.Login == login && l.Password == password);
                foreach(var u in acc1)
                {
                    if (acc1 != null)
                    {
                        x1++;
                    }
                }
            }

            Response response = new();

            if (x1 != 0)
            {

                response.StatusCode = HttpStatusCode.OK;
                response.Headers["Access-Control-Allow-Origin"] = "*";
                response.Headers["Access-Control-Allow-Method"] = "POST";

                string myToken = "lalala.somestring.secretword";
                response.Headers["Token"] = myToken;
                response.Headers["Access-Control-Expose-Headers"] = "Token, Account";
                response.Headers["Content-Type"] = "application/json";

                response.Headers["Account"] = System.Text.Json.JsonSerializer.Serialize(x1);
                return response;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }
        });
    }
}