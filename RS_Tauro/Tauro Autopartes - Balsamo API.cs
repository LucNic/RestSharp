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
using System.Timers;

namespace RS_Tauro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] _listadoTauro;
        public TextWriter exp_file = new StreamWriter(@"C:\temp\BalsamoWeb.txt");
        int _maxIndex;
        string _errcode;
        
        public void LeerArticulosTauro()
        {
            string path_tauro= @"c:\temp\balsamo.txt";
            _listadoTauro = File.ReadAllLines(path_tauro);
            _maxIndex = _listadoTauro.Count();
            
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            LeerArticulosTauro();
            Iniciartimer();
        
        }

        int _index = 0;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timer_global = new System.Windows.Forms.Timer();

        private void Iniciartimer()
        {
            _timer_global.Interval = 120000;
            _timer_global.Enabled = true;
            _timer_global.Tick += new EventHandler(timer_global_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (_index <= 120)//_maxIndex)
            {
                string _artParam = _listadoTauro[_index].ToString().Trim();
                var client = new RestClient("http://api.balsamo.com.ar:9086/v1/articulos");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", "cliente=2222&articulo=" + _artParam + "&apikey=f71ww547-ee22-2ftgd-987f-55557f0f3rr8f-CL-2222", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _artweb = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                string _success = _artweb.success;

                var _errorweb = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content.ToString());
                _errcode = _errorweb.error_code;
                string _errmsj = _errorweb.error_msg;

                if (_success == "False")
                {
                    switch (_errcode)
                    {
                        case "5004":
                            exp_file.Close();
                            _timer.Stop();
                            lblMensaje.Text = _errmsj;
                            lblMensaje.BackColor = Color.Red;
                            break;
                        case "5006":
                            _timer.Stop();
                            lblMensaje.Text = _errmsj;
                            lblMensaje.BackColor = Color.Blue;
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


                    exp_file.WriteLine(_descrip + ";" + _arti + ";" + _ori + ";" + _rub + ";" + _cost + ";");

                }
                if (_errcode != "5004")
                {
                    lblMensaje.Text = _index + " articulos importados...";
                    _index++;
                }
            }
            else if (_errcode != "5004")
            {
                _timer.Stop();
                exp_file.Close();
                lblMensaje.Text = "Descarga Finalizada";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            exp_file.Close();
        }

        private void timer_global_Tick(object sender, EventArgs e)
        {
            _timer.Interval = 10;
            _timer.Enabled = true;
            _timer.Tick += new EventHandler(timer_Tick);
        }
    }
}
