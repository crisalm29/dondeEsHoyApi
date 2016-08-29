using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDataGoogleMaps
{
    class Program
    {
        static void Main(string[] args)
        {

            // APi https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=9.996046,-84.117465&radius=50000&types=clothing_store&key=AIzaSyA8L2m_wupP7ayUzTrmbJLG_GoRAMgOWos

            string requestUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=9.996046,-84.117465&radius=50000&types=clothing_store&key=AIzaSyA8L2m_wupP7ayUzTrmbJLG_GoRAMgOWos";

            List<JToken> localesTotal = new List<JToken>();
            Program programa = new Program();
            string pageToken = "";
            bool seguir = true;
            string urlWpagetoken = "";
            for (int i = 1; seguir;  i++)
            {
                if(i==1)
                 urlWpagetoken = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=9.996046,-84.117465&radius=50000&types=clothing_store&key=AIzaSyA8L2m_wupP7ayUzTrmbJLG_GoRAMgOWos";
                else
                {
                    urlWpagetoken = " https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken=" + pageToken + "&key=AIzaSyA8L2m_wupP7ayUzTrmbJLG_GoRAMgOWos";
                }
                List<JToken> obtenidos = programa.obtenerLocales(urlWpagetoken,out pageToken);

                if (obtenidos.Count == 0) break;

                localesTotal = localesTotal.Concat(obtenidos).ToList();
                


            }

            foreach(JToken local in localesTotal)
            {
                //Console.WriteLine(local.ToString());
                try
                {
                    string nombre = local["name"].ToString();
                    Console.WriteLine(nombre);

                }
                catch
                {
                    Console.WriteLine("Fallo algo");
                }
                Console.WriteLine("***********************************");
            }


            Console.WriteLine(localesTotal.Count);


            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.ContentType = "application/json; charset=utf-8";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    StreamReader st = new StreamReader(response.GetResponseStream());

                    string jsonTxt = st.ReadToEnd();

                    JObject json = JObject.Parse(jsonTxt);

                    JToken result = json.GetValue("results");

                    List<JToken> lista = result.ToList();

                    foreach(JToken local in lista)
                    {
                        //Console.WriteLine(local.ToString());
                        Console.WriteLine("**********************************************");
                        try
                        {
                            string nombre = local["name"].ToString();
                            Console.WriteLine(nombre);

                        }
                        catch
                        {
                            Console.WriteLine("Fallo algo");
                        }
                    }

                    //Console.WriteLine(result.ToString());
                    Console.WriteLine(result.Count().ToString());



                    Console.ReadLine();
                    //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    //object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    //Response jsonResponse = objResponse as Response;
                    //return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        List<JToken> obtenerLocales(string url,out string nextPageToken)
        {
            List<JToken> resultado = new List<JToken>();
            nextPageToken = "";
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json; charset=utf-8";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    StreamReader st = new StreamReader(response.GetResponseStream());

                    string jsonTxt = st.ReadToEnd();

                    JObject json = JObject.Parse(jsonTxt);

                    JToken result = json.GetValue("results");
                    resultado = result.ToList();
                    nextPageToken = json["next_page_token"].ToString();

                    resultado = result.ToList();
                }
            }
            catch
            {

            }

            return resultado;
        }
    }
}