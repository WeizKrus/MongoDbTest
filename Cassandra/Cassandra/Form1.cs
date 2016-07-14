using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cassandra;
using Cassandra.Data;
using System.Diagnostics;

namespace CassandraProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public void Connect(String node)
        //{
        //    var Cluster = Cluster.Builder()
        //             .AddContactPoint(node)
        //             .Build();
        //    Console.WriteLine("Connected to cluster: " + Cluster.Metadata.ClusterName.ToString());
        //    foreach (var host in Cluster.Metadata.AllHosts())
        //    {
        //        Console.WriteLine("Data Center: " + host.Datacenter + ", " +
        //            "Host: " + host.Address + ", " +
        //            "Rack: " + host.Rack);
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            Cluster cluster = Cluster.Builder().WithPort(9042).AddContactPoint("192.168.25.131").Build();
            Debug.WriteLine(cluster.Metadata.ClusterName);

            try
            {
                ISession session = cluster.Connect();
                //session.Execute("CREATE KEYSPACE simplex WITH replication " +
                //    "= {'class':'SimpleStrategy', 'replication_factor':3};");
                session.Execute("insert into users (lastname, age, city, email, firstname) values ('Jones', 35, 'Austin', 'bob@example.com', 'Bob')");;

                Debug.WriteLine("Connected to cluster: " + cluster.Metadata.ClusterName.ToString());
                foreach (var host in cluster.Metadata.AllHosts())
                {
                    Debug.WriteLine(
                        "Data Center: " + host.Datacenter + ", " + "Host: " + host.Address + ", " + "Rack: " + host.Rack);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cluster.Shutdown();
            }
        }
    }
}
