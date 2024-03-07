﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using IMS;
using System.ServiceModel.Description;

namespace Host
{
    public partial class Form1 : Form
    {
        ServiceHost sh = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Type t = typeof(ProductService);
            Uri tcp = new Uri("net.tcp://localhost:8010/Design_Time_Addresses/IMS/ProductService");
            Uri http = new Uri("http://localhost:8733/Design_Time_Addresses/IMS/ProductService");
            ServiceHost host = new ServiceHost(t, tcp, http);
            host.Open();
            label1.Text = "service running...";

            /*Uri tcpa = new Uri("net.tcp://localhost:8010/Design_Time_Addresses/IMS/ProductService/mex");
            Uri http = new Uri("http://localhost:8733/Design_Time_Addresses/IMS/");
            sh = new ServiceHost(typeof(Service1), tcpa);

            NetTcpBinding tcpb = new NetTcpBinding();

            ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(mBehave);
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            sh.AddServiceEndpoint(typeof(IService1), tcpb, tcpa);

            sh.Open();
            label1.Text = "Service Running ...";*/
        }
    }
}
