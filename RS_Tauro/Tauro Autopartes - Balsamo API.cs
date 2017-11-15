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


namespace RS_Tauro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Listado_articulos()
        {
            var list_client = new RestClient("http://api.balsamo.com.ar:9086/v1/articulos/listado");
            var list_request = new RestRequest(Method.POST);
            list_request.AddHeader("cache-control", "no-cache");
            list_request.AddHeader("content-type", "application/x-www-form-urlencoded");

            int pag = 1;
            try {
                while (pag < 2)

                {

                    list_request.AddParameter("application/x-www-form-urlencoded", "cliente=2222&pagina=" + pag.ToString() + "&apikey=f71ww547-ee22-2ftgd-987f-55557f0f3rr8f-CL-2222", ParameterType.RequestBody);
                    IRestResponse list_response = list_client.Execute(list_request);
                    Text = list_response.Content.ToString();

                    string[] lineas = Text.Split(default(char[]), StringSplitOptions.RemoveEmptyEntries);
                    List<string> _list = new List<string>();
                    int count = lineas.Count();
                    for (int i = 0; i < count; i++)
                    {
                        if (i >= 2 & (i % 2 == 0))
                        {
                            _list.Add(lineas[i]);

                        }

                    }
                    string _error = "";

                    var client = new RestClient("http://api.balsamo.com.ar:9086/v1/articulos");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    
                    foreach (string _codArt in _list)
                    {
                        string exp_codart = _codArt.Substring(1, _codArt.Length - 3);
                        using (System.IO.StreamWriter exp_file = new System.IO.StreamWriter(@"C:\temp\Balsamo.txt"))
                        {
                            int art = 1;
                            if (art < 2)
                            {
                                request.AddParameter("application/x-www-form-urlencoded", "cliente=2222&articulo=" + exp_codart + "&apikey=f71ww547-ee22-2ftgd-987f-55557f0f3rr8f-CL-2222", ParameterType.RequestBody);
                                IRestResponse response = client.Execute(request);
                                exp_file.WriteLine(response.Content.ToString() + Environment.NewLine);
                                _error = response.Content.ToString();
                                art++;
                            }
                        }

                    }

                    pag++;
                    lblMensaje.Text = _error;
                }

                
                MessageBox.Show("Archivo completo", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception e)
            { MessageBox.Show(e.ToString()); }

}        
        private void btnDescargar_Click(object sender, EventArgs e)
        {
            Listado_articulos();
        }
    }
}
