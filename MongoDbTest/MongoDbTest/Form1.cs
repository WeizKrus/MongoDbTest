using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace MongoDbTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MongoClient mongoClient = new MongoClient(@"mongodb://localhost:27017");
            IMongoDatabase db = mongoClient.GetDatabase("test");
            var collection = db.GetCollection<BsonDocument>("restaurants");

            var filter = new BsonDocument();
            var count = 0;

            using (var cursor = collection.FindSync(filter))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        string a = "";
                        // process document
                        count++;
                    }
                }
            }

            count.Should().Be(1);
        }
    }

    public partial class Form1 : Form
    {
        public class address
        {
            public string street { get; set; }
            public string zipcode { get; set; }
            public string building { get; set; }
            public int[] coord { get; set; }
        }

        public class grades
        {
            public DateTime date { get; set; }
            public char grade { get; set; }
            public byte score { get; set; }
        }

    }
}
