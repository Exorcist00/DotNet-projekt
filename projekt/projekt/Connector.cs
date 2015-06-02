using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projekt
{
    class Connector
    {

        public void MakeRequest(string tag)
        {
            Uri serviceUri = new Uri("https://api.twitter.com/1.1/search/tweets.json?q=%23"+tag+"&result_type=recent&count=5");

            using (WebClient downloader = new WebClient())
            {
                // downloader.Headers.Add("User-Agent: Other");
                downloader.Headers.Add("Authorization", "Bearer AAAAAAAAAAAAAAAAAAAAAB3pagAAAAAAZnk%2BvI57RIvNbZalrGxVVRaPzmI%3D9W40m1MlsWN5Z3fOKdLcQpgucmh4qEXlQAjrk7GgTJ4t9gZy6l");
                downloader.OpenReadCompleted += new OpenReadCompletedEventHandler(downloader_OpenReadCompleted);
                downloader.OpenReadAsync(serviceUri);
            }
            
           
        }

        void downloader_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    Stream responseStream = e.Result;
                    var _serializer = new TwitterSerializer();
                    var reader = new StreamReader(responseStream);
                    var read = reader.ReadToEnd();
                    var obiekty = _serializer.DeserializeTwitter(read);
                    // MainWindow.Kolekcja2 = obiekty;
                   // Console.WriteLine(obiekty[0].Text);
                    MainWindow.Kolekcja = obiekty;
                }
                catch(NoTwittsException err)
                {
                    Console.WriteLine(err.GetErrMess());
                }
                
            }
            else
            {

                MessageBox.Show("Error:"+e.Error.Message);
            }
        }
    }
}
