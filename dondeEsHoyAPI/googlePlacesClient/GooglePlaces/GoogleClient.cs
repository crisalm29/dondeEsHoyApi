using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace googlePlacesClient.GooglePlaces
{
    public class GoogleClient
    {
        public List<JToken> obtenerLocales(string lat,string lng )
        {
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + lat + "," + lng + "&radius=2000&types=liquor_store|bar&key=AIzaSyA8L2m_wupP7ayUzTrmbJLG_GoRAMgOWos";
            List<JToken> resultado = new List<JToken>();
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

                    resultado = result.ToList();
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }

            return resultado;
        }
    }
}
