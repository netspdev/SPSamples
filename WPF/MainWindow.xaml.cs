using DTO.Employees;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        List<Task> tasks = new List<Task>();
        string address = "https://www.angular.net/api/Employees";
        public MainWindow()
        {
            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            List<TodoItem> items = new List<TodoItem>();
            items.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });
            //client.Timeout = TimeSpan.FromMilliseconds(2000);

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(async () =>
                {
                    var result = await GetTodoItem(tasks.Count);
                    items.Add(result);
                }));

                //items.Add(GetTodoItem(i).Result);
            }

            //then wait for all tasks to complete asyncronously
            Task.WaitAll(tasks.ToArray());
            ListBox1.ItemsSource = items;

            //then add the result of all the tasks to r in a treadsafe fashion
        }

        private async Task<TodoItem> GetTodoItem(int i)
        {

            System.Net.Http.HttpClient client1 = new System.Net.Http.HttpClient();
            client1.DefaultRequestHeaders.Add("api-client-key", "8AAFD0B09E0E45C4ADA6351EAFD21EE1");
            var test = client1.GetAsync("http://api-sandbox.pnistaging.com/rest/v1/accounts/retailer/TESUK?email=test@test489335.com&password=Password1&returnurl=true");

            TodoItem item = new TodoItem();
            try
            {
                //using (client = new HttpClient())
                //{
                Employee employee = new Employee()
                {
                    FirstName = i.ToString(),
                    LastName = i.ToString(),
                    Email = string.Format("{0}@{0}.com", i),
                    Phone = "3333333333"
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> result = client.PostAsync(address, GetEmployee(employee));
                result.Result.EnsureSuccessStatusCode();
                string content = result.Result.Content.ReadAsStringAsync().Result;
                item.Title = content;
                item.Completion = i;
                //}
            }
            catch (Exception ex)
            {
                item.Title = ex.ToString();
                item.Completion = i;
            }

            return item;
        }

        public StringContent GetEmployee(Employee employee)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Employee));
                serializer.WriteObject(stream, employee);


                var jsonString = Encoding.Default.GetString((stream.ToArray()));
                return new StringContent(jsonString, Encoding.UTF8, "application/json");
            }

            return new StringContent(string.Empty, Encoding.UTF8, "application/json");
        }
    }

    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
