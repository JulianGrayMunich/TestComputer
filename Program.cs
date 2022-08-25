
using System;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using EASendMail; //add EASendMail namespace (This needs the license code)
using GNAlibrary;



namespace TestComputer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Software to check the computer environment");
            Console.WriteLine("Press key to start test..");
            Console.ReadKey();
            Console.WriteLine("");

            string strDBconnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;
            string strProjectTitle = System.Configuration.ConfigurationManager.AppSettings["ProjectTitle"];
            string strEmailLogin = System.Configuration.ConfigurationManager.AppSettings["EmailLogin"];
            string strEmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
            string strEmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
            string strMailRecipients = System.Configuration.ConfigurationManager.AppSettings["systemMailRecipients"];

            Console.WriteLine("Testing App.config Settings:");
            Console.WriteLine(strProjectTitle);
            Console.WriteLine(strDBconnection);
            Console.ReadKey();

            gnaToolbox gna = new gnaToolbox();

            Console.WriteLine("");
            Console.WriteLine("Contact with GNAlibrary:");
            gna.HelloWorld();
            Console.WriteLine("");
            Console.WriteLine("Testing bidirectional comms between modules:");
            string strTest = gna.Test("SourceData");
            Console.WriteLine(strTest);
            Console.ReadKey();

            //Console.WriteLine("");
            //Console.WriteLine("Checking Software validity key");
            //string strSendEmail = "No";
            //gna.checkSoftwareReferenceDate(strProjectTitle, strEmailLogin, strEmailPassword, strSendEmail);
            //Console.ReadKey();

            Console.WriteLine("");
            Console.WriteLine("Testing DB connection:");
            Console.WriteLine(strDBconnection);
            gna.testDBconnection(strDBconnection);

            Console.WriteLine("");
            Console.WriteLine("Testing email:");

            string strMessage = "Test email";
            string strSubjectLine = "Subject Line : " + strProjectTitle + " test email";

            gna.sendEmail(strEmailLogin, strEmailPassword, strEmailFrom, strMailRecipients, strSubjectLine, strMessage);

            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("Test complete");
            Console.WriteLine("Press key to close..");
            Console.ReadKey();


        }
    }
}
