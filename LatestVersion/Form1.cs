﻿
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace LatestVersion
{


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
            int iPort = 8080; // If admin rights it requires, wrong it is ;)
            iPort = 30080; // Damn !  I still no haz no admin rightz !


            string strBasePath = "";

            string strCurrentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strCurrentDirectory);
            strBasePath = System.IO.Path.Combine(di.Parent.Parent.Parent.FullName, "TestApplication");
            //strBasePath = System.IO.Path.Combine(di.Parent.Parent.Parent.FullName, "MvcTestApplication");


            //EmbeddableWebServer.cWebSource WebSource = new EmbeddableWebServer.cWebSource(System.Net.IPAddress.Any, iPort);
            Mono.WebServer.XSPWebSource ws = new Mono.WebServer.XSPWebSource(System.Net.IPAddress.Any, iPort);

            // EmbeddableWebServer.cServer Server = new EmbeddableWebServer.cServer(WebSource, strBasePath);
            Mono.WebServer.ApplicationServer Server = new Mono.WebServer.ApplicationServer(ws, strBasePath);

            Server.AddApplication("localhost", iPort, "/", strBasePath);
            Server.Start(true, 0);


            System.Diagnostics.Process.Start("\"http://localhost:" + iPort.ToString() + "\"");

            System.Console.WriteLine(" --- Server up and running. Press any key to quit --- ");
            System.Console.ReadKey();

            Server.Stop();
        }


    }


}
