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
    public partial class DescargaBalsamo : Form
    {
        public DescargaBalsamo()
        {
            InitializeComponent();
        }

        string[] _listadoTauro;
        public TextWriter exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb.txt");
        public TextWriter exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos.txt");
        public TextWriter exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos.txt");
        int _maxIndex;
        string _errcode;

        public void LeerArticulosTauro()
        {
            string path_tauro = @"c:\Tauro_Autopartes\balsamo.txt";
            _listadoTauro = File.ReadAllLines(path_tauro);
            _maxIndex = _listadoTauro.Count();

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            btnDescargar.Enabled = false;
            rbPrimer.Enabled = false;
            rbSegundo.Enabled = false;
            rbTercero.Enabled = false;
            rbCuarto.Enabled = false;
            rbQuinto.Enabled = false;
            rbSexto.Enabled = false;
            LeerArticulosTauro();
            lblMensaje.Text = "";
            lblMensaje.BackColor = Color.White;
            Iniciartimer();

        }
        int _index;
        int _limite;
        int _indexTimer = 0;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        
        private void Iniciartimer()
        {
            _timer.Interval = 1500;
            _timer.Enabled = true;
            _timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_index <= _maxIndex && _index < _limite)
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
                            case "5001":
                                exp_file_novalidos.WriteLine(_artParam);
                                break;
                            case "5003":
                                exp_file.Close();
                                exp_file_validos.Close();
                                exp_file_novalidos.Close();
                                _timer.Stop();
                                lblMensaje.Text = _errmsj;
                                lblMensaje.BackColor = Color.Red;
                                btnDescargar.Enabled = true;
                                break;
                            case "5004":
                                exp_file.Close();
                                exp_file_validos.Close();
                                exp_file_novalidos.Close();
                                _timer.Stop();
                                lblMensaje.Text = _errmsj;
                                lblMensaje.BackColor = Color.Red;
                                btnDescargar.Enabled = true;
                                break;
                            case "5006":
                                exp_file.Close();
                                exp_file_validos.Close();
                                exp_file_novalidos.Close();
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
                        exp_file_validos.WriteLine(_artParam);
                    }
                    if (_errcode != "5004")
                    {
                        lblMensaje.Text = _index + " articulos importados...";
                        _index++;
                        _indexTimer++;
                    }

                }
                else if (_errcode != "5004")
                {
                    _timer.Stop();
                    exp_file.Close();
                    exp_file_validos.Close();
                    exp_file_novalidos.Close();
                    lblMensaje.BackColor = Color.Green;
                    lblMensaje.Text = "Descarga Finalizada";
                    btnDescargar.Enabled = true;
                    rbPrimer.Enabled = true;
                    rbSegundo.Enabled = true;
                    rbTercero.Enabled = true;
                    rbCuarto.Enabled = true;
                    rbQuinto.Enabled = true;
                    rbSexto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message.ToString();
                lblMensaje2.Text = "Vuelva a intentarlo mas tarde";
                btnDescargar.Enabled = true;
                rbPrimer.Enabled = true;
                rbSegundo.Enabled = true;
                rbTercero.Enabled = true;
                rbCuarto.Enabled = true;
                rbQuinto.Enabled = true;
                rbSexto.Enabled = true;
                _timer.Stop();
                exp_file.Close();
                exp_file_validos.Close();
                exp_file_novalidos.Close();

            }

        }

        private void rbPrimer_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 0;
            _limite = 2500;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_1.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_1.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_1.txt");
        }

        private void rbSegundo_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 2500;
            _limite = 5000;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_2.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_2.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_2.txt");
        }

        private void rbTercero_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 5000;
            _limite = 7500;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_3.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_3.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_3.txt");
        }

        private void rbCuarto_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 7500;
            _limite = 10000;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_4.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_4.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_4.txt");
        }

        private void rbQuinto_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 10000;
            _limite = 12500;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_5.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_5.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_5.txt");
        }

        private void rbSexto_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 12500;
            _limite = 15000;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb_6.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos_6.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoNoValidos_6.txt");
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            exp_file.Close();
            exp_file_validos.Close();
            exp_file_novalidos.Close();
            _index = 0;
            exp_file = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb.txt");
            exp_file_validos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoValidos.txt");
            exp_file_novalidos = new StreamWriter(@"C:\Tauro_Autopartes\BalsamoWeb.txt");
        }
    }
}
