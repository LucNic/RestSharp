using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft;
using System.IO;



namespace RS_Tauro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void _leerlistado()
        {
            string _path = @"c:\temp\balsamo.txt";
            var client = new RestClient("http://api.balsamo.com.ar:9086/v1/articulos");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            
            string[] _leerTXT = File.ReadAllLines(_path);

            using (System.IO.StreamWriter exp_file = new System.IO.StreamWriter(@"C:\temp\BalsamoWeb.txt"))
            {
                foreach (string _art in _leerTXT)
                {
                    string _artParam = _art.Trim();

                    request.AddParameter("application/x-www-form-urlencoded", "cliente=2222&articulo=" + _artParam + "&apikey=f71ww547-ee22-2ftgd-987f-55557f0f3rr8f-CL-2222", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);

                    var json = response.Content;
                    Errores _error = Newtonsoft.Json.JsonConvert.DeserializeObject<Errores>(json);
                    //dynamic _artweb = Newtonsoft.Json.JsonConvert.DeserializeObject(_txt);
                    //var _desc = _artweb.
                    Articulos _artweb = Newtonsoft.Json.JsonConvert.DeserializeObject<Articulos>(json);

                    

                    exp_file.WriteLine(response.Content.ToString() + Environment.NewLine);

                    if (_artParam == "805578-L")
                    { break;
                    }
                }
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            _leerlistado();            
        }
    }
}
