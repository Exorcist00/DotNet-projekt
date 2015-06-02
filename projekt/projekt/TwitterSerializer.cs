using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;


namespace projekt
{
    class TwitterSerializer :ITwitterSerializer
    {
      //  public string SerializeTwitter(ObiektDanych twitt)
      //  {
      //      
      //      throw new NotImplementedException();
      //  }

        public List<ObiektDanych> DeserializeTwitter(string stream)
        {
            var arr = new List<ObiektDanych>();
            try
            {
                JObject jobj = JObject.Parse(stream);
                JArray jarr = JArray.Parse(jobj["statuses"].ToString());
                for (int i = 0; i < jarr.Count(); i++)
                {
                    var obj = new ObiektDanych();
                    JObject twitt = JObject.Parse(jarr[i].ToString());

                    JObject user = JObject.Parse(twitt["user"].ToString());
                    obj.Name = user["name"].ToString();

                    JObject status = JObject.Parse(twitt["retweeted_status"].ToString());
                    obj.Date = status["created_at"].ToString();
                    obj.Text = status["text"].ToString();
                    arr.Add(obj);
                    Console.WriteLine(obj.Name+" "+obj.Date+""+obj.Text);
                }

            }catch(JsonReaderException e){
                Console.WriteLine(e.ToString());
            }
           
            if(arr.Count==0)
            {
                throw new NoTwittsException();
            }
            else
            {
                return arr;
            }

        }
    }
}
