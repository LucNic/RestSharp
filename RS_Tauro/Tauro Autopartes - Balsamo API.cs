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
            string[] _leerTXT = File.ReadAllLines(_path);

            int _countError = 0;

            using (System.IO.StreamWriter exp_file = new System.IO.StreamWriter(@"C:\temp\BalsamoWeb.txt"))
            {

                foreach (string _art in _leerTXT)
                {

                    if (_countError < 5)
                    {
                        string _artParam = _art.Trim();

                        var request = new RestRequest(Method.POST);
                        request.AddHeader("cache-control", "no-cache");
                        request.AddHeader("content-type", "application/x-www-form-urlencoded");
                        request.AddParameter("application/x-www-form-urlencoded", "cliente=2222&articulo=" + _artParam + "&apikey=f71ww547-ee22-2ftgd-987f-55557f0f3rr8f-CL-2222", ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);

                        var _artweb = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                        string _success = _artweb.success;


                        var _errorweb = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content.ToString());
                        string _errcode = _errorweb.error_code;
                        string _errmsj = _errorweb.error_msg;

                        if (_success == "False")
                        {
                            switch (_errcode)
                            {
                                case "5002":
                                    lblMensaje.Text = _errmsj;
                                    _countError++;
                                    break;
                                case "5003":
                                    lblMensaje.Text = _errmsj;
                                    _countError++;
                                    break;
                                case "5004":
                                    lblMensaje.Text = _errmsj;
                                    _countError++;
                                    break;
                                case "5005":
                                    lblMensaje.Text = _errmsj;
                                    _countError++;
                                    break;
                                case "5006":
                                    lblMensaje.Text = _errmsj;
                                    _countError++;
                                    break;
                            }
                        }
                        else
                        {
                            string _descrip = _artweb.data.descripcion;
                            string _arti = _artweb.data.articulo;
                            string _ori = _artweb.data.original;
                            string _rub = _artweb.data.rubro;
                            string _cost = _artweb.data.costo;

                            exp_file.WriteLine(_descrip + ";" + _arti + ";" + _ori + ";" + _rub + ";" + _cost + ";" + Environment.NewLine);
                        }

                        if (lblMensaje.Text == "")
                        {
                            lblMensaje.Text = "DESCARGA FINALIZADA";
                        }
                        
                    }

                   
                    else
                    {
                        break;
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
