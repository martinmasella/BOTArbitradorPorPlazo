using Newtonsoft.Json.Linq;
using Primary;
using Primary.Data;
using System.Media;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BOTArbitradorPorPlazo
{
    public partial class frmBOT : Form

    {
        const string sURL = "https://api.invertironline.com";
        const string SURLOper = "https://www.invertironline.com";
        const string sURLVETA = "https://api.veta.xoms.com.ar";
        const string prefijoPrimary= "MERV - XMEV - ";
        const string sufijoCI = " - CI";
        const string sufijo24 = " - 24hs";


        string tokenVETA;
        string bearer;
        string refresh;
        double umbral;
        double timeOffset;
        double umbralBonos;
        double umbralAcciones;
        DateTime expires;

        List<string> tickersIOL;
        List<Ticker> tickers;
        List<string> tickersCI;
        List<string> tickers24;

        public frmBOT()
        {
            InitializeComponent();
        }
                                                                                   
        private void frmBOT_Load(object sender, EventArgs e)
        {
            this.Top = 10;
            this.Text = "PlazoBOT Arbitrador - Copyright 2020 Tinchex Capital";
                        
            DoubleBuffered = true;
            CheckForIllegalCrossThreadCalls = false;
            umbralAcciones = 0.32;  //Establecer los umbrales de acuerdo a la comisión de cada uno.
            umbralBonos = 0.12;

            tickersIOL = new List<string>();
            tickers = new List<Ticker>();

            FillTickersIOL();

            ConfigureGrid();

            for (double j = 0; j <= 4; j = j + 0.1)
            {
                cboUmbral.Items.Add(Math.Round(j, 2));
            }

            var configuracion = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            try
            {
                cboUmbral.SelectedIndex = int.Parse(configuracion.GetSection("MiConfiguracion:Umbral").Value);
                txtPresupuesto.Text = configuracion.GetSection("MiConfiguracion:Presupuesto").Value;
                txtUsuarioIOL.Text = configuracion.GetSection("MiConfiguracion:UserIOL").Value;
                txtClaveIOL.Text = configuracion.GetSection("MiConfiguracion:ClaveIOL").Value;
                txtUsuarioVETA.Text = configuracion.GetSection("MiConfiguracion:UserVETA").Value;
                txtClaveVETA.Text = configuracion.GetSection("MiConfiguracion:ClaveVETA").Value;
            }
            catch (Exception ex)
            {

            }
        }


        private void FillTickersIOL()
        {
            //ETFs
            tickersIOL.Add("-ETFs-");

            tickersIOL.Add("ARKK");
            tickersIOL.Add("DIA");
            tickersIOL.Add("EEM");
            tickersIOL.Add("EWZ");
            tickersIOL.Add("IWM");
            tickersIOL.Add("QQQ");
            tickersIOL.Add("SPY");
            tickersIOL.Add("XLE");
            tickersIOL.Add("XLF");

            //Bonos
            tickersIOL.Add("-BONDs-");

            //AddTicker("101675", "S29O1");

            //tickersIOL.Add("S30N2");
            tickersIOL.Add("AL29");
            //AddTicker("99934", "AL29D");
            //AddTicker("99935", "AL29C");

            //tickersIOL.Add("AL30");
            //AddTicker("99926", "AL30D");
            //AddTicker("99927", "AL30C");

            tickersIOL.Add("AL35");
            //AddTicker("99928", "AL35D");
            //AddTicker("99929", "AL35C");

            tickersIOL.Add("AE38");
            //AddTicker("99930", "AE38D");
            //AddTicker("99931", "AE38C");

            tickersIOL.Add("AL41");
            //AddTicker("87456", "CO26");
            //tickersIOL.Add("CUAP");
            tickersIOL.Add("DICP");
            tickersIOL.Add("PARP");

            tickersIOL.Add("GD29");
            //AddTicker("99957", "GD29D");
            //AddTicker("99956", "GD29C");

            //tickersIOL.Add("GD30");
            //AddTicker("99958", "GD30D");
            //AddTicker("99963", "GD30C");
            tickersIOL.Add("GD35");
            //AddTicker("99959", "GD35D");
            //AddTicker("99965", "GD35C");

            tickersIOL.Add("GD38");
            tickersIOL.Add("GD41");
            tickersIOL.Add("GD46");

            tickersIOL.Add("PBA25");
            tickersIOL.Add("TX26");
            tickersIOL.Add("TX28");
            tickersIOL.Add("TO26");
            tickersIOL.Add("TDG24");
            //Acciones
            tickersIOL.Add("-ACCs-");

            tickersIOL.Add("ALUA");
            tickersIOL.Add("BBAR");
            tickersIOL.Add("BMA");
            tickersIOL.Add("BYMA");
            tickersIOL.Add("GGAL");
            tickersIOL.Add("PAMP");
            tickersIOL.Add("SUPV");
            tickersIOL.Add("TXAR");
            tickersIOL.Add("YPFD");

            //CEDEARs nuevos
            tickersIOL.Add("-NCEDs-");

            tickersIOL.Add("AAL");
            tickersIOL.Add("AKO.B");
            tickersIOL.Add("COIN");
            tickersIOL.Add("DOW");
            tickersIOL.Add("EA");
            tickersIOL.Add("GM");
            tickersIOL.Add("LRCX");
            tickersIOL.Add("NIO");
            tickersIOL.Add("SE");
            tickersIOL.Add("SPGI");
            tickersIOL.Add("TWLO");
            tickersIOL.Add("XP");
            tickersIOL.Add("ABBV");
            tickersIOL.Add("AVGO");
            tickersIOL.Add("BIOX");
            tickersIOL.Add("BRKB");
            tickersIOL.Add("CAAP");
            tickersIOL.Add("DOCU");
            tickersIOL.Add("ETSY");
            tickersIOL.Add("MA");
            tickersIOL.Add("PAAS");
            tickersIOL.Add("PSX");
            tickersIOL.Add("SHOP");
            tickersIOL.Add("SNOW");
            tickersIOL.Add("SPOT");                                     
            tickersIOL.Add("SQ");
            tickersIOL.Add("UNH");
            tickersIOL.Add("UNP");
            tickersIOL.Add("WBA");
            tickersIOL.Add("ZM");

            tickersIOL.Add("-NCEDs2-");

            tickersIOL.Add("ABNB");
            tickersIOL.Add("BITF");
            tickersIOL.Add("F");
            tickersIOL.Add("HUT");
            tickersIOL.Add("JMIA");
            tickersIOL.Add("MOS");
            tickersIOL.Add("MSTR");
            tickersIOL.Add("MU");
            tickersIOL.Add("OXY");
            tickersIOL.Add("PANW");
            tickersIOL.Add("RBLX");
            tickersIOL.Add("SATL");
            tickersIOL.Add("UAL");
            tickersIOL.Add("UBER");
            tickersIOL.Add("UPST");

            tickersIOL.Add("-NCEDs3-");

            //tickersIOL.Add("ACN");
            tickersIOL.Add("CCL");
            tickersIOL.Add("BKNG");
            tickersIOL.Add("CVS");
            tickersIOL.Add("DAL");
            tickersIOL.Add("MDLZ");
            tickersIOL.Add("MRNA");
            tickersIOL.Add("PINS");
            tickersIOL.Add("PM");
            tickersIOL.Add("RACE");
            tickersIOL.Add("RIOT");
            tickersIOL.Add("ROKU");
            tickersIOL.Add("SCHW");
            tickersIOL.Add("SPCE");
            tickersIOL.Add("STLA");
            tickersIOL.Add("SWKS");
            tickersIOL.Add("TMUS");

            //CEDEARs viejos
            tickersIOL.Add("-OCEDs-");

            tickersIOL.Add("AAPL");
            tickersIOL.Add("ABEV");
            tickersIOL.Add("ABT");
            tickersIOL.Add("ADBE");
            tickersIOL.Add("ADGO");
            tickersIOL.Add("AIG");
            tickersIOL.Add("AMD");
            tickersIOL.Add("AMGN");
            tickersIOL.Add("AMX"); ;
            tickersIOL.Add("AMZN");
            tickersIOL.Add("ARCO");
            tickersIOL.Add("AXP");
            tickersIOL.Add("AZN");
            tickersIOL.Add("BA");
            tickersIOL.Add("BA.C");
            tickersIOL.Add("BABA");
            tickersIOL.Add("BB");
            tickersIOL.Add("BBD");
            tickersIOL.Add("BBV");
            tickersIOL.Add("BCS");
            tickersIOL.Add("BHP");
            tickersIOL.Add("BIDU");
            tickersIOL.Add("BIIB");
            tickersIOL.Add("BNG");
            tickersIOL.Add("BP");
            tickersIOL.Add("BRFS");
            tickersIOL.Add("BSBR");
            tickersIOL.Add("C");
            tickersIOL.Add("CAH");
            tickersIOL.Add("CAT");
            tickersIOL.Add("CL");
            tickersIOL.Add("COST");
            tickersIOL.Add("CRM");
            tickersIOL.Add("CSCO");
            tickersIOL.Add("CVX");
            tickersIOL.Add("CX");
            tickersIOL.Add("DE");
            tickersIOL.Add("DESP");
            tickersIOL.Add("DISN");
            tickersIOL.Add("EBAY");
            tickersIOL.Add("ERIC");
            tickersIOL.Add("ERJ");
            tickersIOL.Add("FCX");
            tickersIOL.Add("FDX");
            tickersIOL.Add("FMX");
            tickersIOL.Add("FSLR");
            tickersIOL.Add("GE");
            tickersIOL.Add("GFI");
            tickersIOL.Add("GGB");
            tickersIOL.Add("GILD");
            tickersIOL.Add("GLOB");
            tickersIOL.Add("GOLD");
            tickersIOL.Add("GOOGL");
            tickersIOL.Add("GS");
            tickersIOL.Add("HD");
            tickersIOL.Add("HMY");
            tickersIOL.Add("HPQ");
            tickersIOL.Add("HSBC");
            tickersIOL.Add("IBM");
            tickersIOL.Add("INTC");
            tickersIOL.Add("ITUB");
            tickersIOL.Add("JD");
            tickersIOL.Add("JNJ");
            tickersIOL.Add("JPM");
            tickersIOL.Add("KO");
            tickersIOL.Add("MCD");
            tickersIOL.Add("MELI");
            tickersIOL.Add("META");
            tickersIOL.Add("MMM");
            tickersIOL.Add("MO");
            tickersIOL.Add("MRK");
            tickersIOL.Add("MSFT");
            tickersIOL.Add("NFLX");
            tickersIOL.Add("NKE");
            tickersIOL.Add("NOKA");
            tickersIOL.Add("NVDA");
            //AddTicker("87319", "OGZD");
            tickersIOL.Add("ORAN");
            tickersIOL.Add("ORCL");
            tickersIOL.Add("PBR");
            tickersIOL.Add("PEP");
            tickersIOL.Add("PFE");
            tickersIOL.Add("PG");
            tickersIOL.Add("PYPL");
            tickersIOL.Add("QCOM");
            tickersIOL.Add("RIO");
            tickersIOL.Add("RTX");
            tickersIOL.Add("SAP");
            tickersIOL.Add("SBUX");
            tickersIOL.Add("SID");
            tickersIOL.Add("SLB");
            tickersIOL.Add("SNAP");
            tickersIOL.Add("SONY");
            tickersIOL.Add("T");
            tickersIOL.Add("TEN");
            tickersIOL.Add("TRIP");
            tickersIOL.Add("TSM");
            tickersIOL.Add("TSLA");
            tickersIOL.Add("TWTR");
            tickersIOL.Add("TXN");
            tickersIOL.Add("TXR");
            tickersIOL.Add("UGP");
            tickersIOL.Add("UL");
            tickersIOL.Add("V");
            tickersIOL.Add("VALE");
            tickersIOL.Add("VIV");
            tickersIOL.Add("VOD");
            tickersIOL.Add("VRSN");
            tickersIOL.Add("VZ");
            tickersIOL.Add("WFC");
            tickersIOL.Add("WMT");
            tickersIOL.Add("X");
            tickersIOL.Add("XOM");

            //Galpones
            tickersIOL.Add("-GALPs-");

            //tickersIOL.Add("AUSO");
            //AddTicker("302", "BHIP");
            //tickersIOL.Add("BOLT");
            tickersIOL.Add("CEPU");
            tickersIOL.Add("COME");
            tickersIOL.Add("CRES");
            tickersIOL.Add("CTIO");
            //tickersIOL.Add("CVH");
            tickersIOL.Add("EDN");
            tickersIOL.Add("GAMI");
            //tickersIOL.Add("GCDI");
            //tickersIOL.Add("HARG");
            tickersIOL.Add("LOMA");
            tickersIOL.Add("MIRG");
            //tickersIOL.Add("OEST");
            //tickersIOL.Add("SAMI");
            tickersIOL.Add("TECO2");
            tickersIOL.Add("TGNO4");
            tickersIOL.Add("TGSU2");
            tickersIOL.Add("TRAN");
            tickersIOL.Add("VALO");
            /*
            */
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private async Task Inicio()
        {
            var api = new Api(new Uri(sURLVETA));
            await api.Login(txtUsuarioVETA.Text, txtClaveVETA.Text);
            ToLog("Login VETA Ok");

            var allInstruments = await api.GetAllInstruments();

            //var entries = new[] { Entry.Last, Entry.Bids, Entry.Offers };
            var entries = new[] {Entry.Bids, Entry.Offers };

            FillListaTickers();

            var instrumentos = allInstruments.Where(c => tickersCI.Contains(c.Symbol))
                .Concat(allInstruments.Where(c => tickers24.Contains(c.Symbol)));

            using var socket = api.CreateMarketDataSocket(instrumentos, entries, 1, 1);
            socket.OnData = OnMarketData;
            var socketTask = await socket.Start();
            socketTask.Wait(1000);
            LoginIOL();
            tmr.Start();
            ToLog("Login IOL Ok");
            await socketTask;

        }

        private async void LoginIOL()
        {
            try
            {
                if (expires == DateTime.MinValue)
                {
                    string postData = "username=" + txtUsuarioIOL.Text + "&password=" + txtClaveIOL.Text + "&grant_type=password";
                    string response;
                    response = GetResponsePOST(sURL + "/token", postData);
                    dynamic json = JObject.Parse(response);
                    bearer = "Bearer " + json.access_token;
                    expires = DateTime.Now.AddSeconds((double)json.expires_in - 300);
                    refresh = json.refresh_token;                           
                    ToLog(bearer);
                }
                else
                {
                    if (DateTime.Now >= expires)
                    {
                        string postData = "refresh_token=" + refresh + "&grant_type=refresh_token";
                        string response;
                        response = GetResponsePOST(sURL + "/token", postData);
                        if (response.Contains("Error") || response.Contains("excedi"))
                        {
                            ToLog(response);
                        }
                        else
                        {
                            dynamic json = JObject.Parse(response);
                            bearer = "Bearer " + json.access_token;
                            expires = DateTime.Now.AddSeconds((double)json.expires_in - 100);
                            refresh = json.refresh_token;
                            ToLog(bearer);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ToLog(e.Message);
            }

        }
        private string GetResponseGET(string sURL, string sHeader)
        {
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 10000;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", sHeader);

            try
            {
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private string GetResponsePOST(string sURL, string sData)
        {
            WebRequest request = WebRequest.Create(sURL);
            var data = Encoding.ASCII.GetBytes(sData);
            request.Timeout = 10000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = sData.Length;

            if (bearer != null)
            {
                request.Headers.Add("Authorization", bearer);
            }
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                WebResponse response = request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        private void FillListaTickers()
        {
            foreach (string tickerIOL in tickersIOL)
            {
                tickers.Add(new Ticker(tickerIOL, prefijoPrimary + tickerIOL + sufijoCI, prefijoPrimary + tickerIOL + sufijo24));
                tickersCI = tickers.Select(t => t.PrimaryCI).ToList();
                tickers24 = tickers.Select(t => t.Primary24).ToList();
            }
        }

        private async void OnMarketData(Api api, MarketData marketData)
        {
            //var ticker = marketData.Instrument.Symbol;
            var ticker = marketData.InstrumentId.Symbol;
            var bid = default(decimal);
            var offer = default(decimal);
            var bidSize = default(decimal);
            var offerSize = default(decimal);

            if (marketData.Data.Bids != null)
            {
                foreach (var trade in marketData.Data.Bids)
                {
                    bid = trade.Price;
                    bidSize = trade.Size;
                }
            }

            if (marketData.Data.Offers != null)
            {
                foreach (var trade in marketData.Data.Offers)
                {
                    offer = trade.Price;
                    offerSize = trade.Size;
                }
            }
            DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(marketData.Timestamp).DateTime;

            if (ticker.EndsWith("24hs"))
            {
                for (int j = 0; j < grdPanel.Rows.Count; j++)
                {
                    string left = grdPanel.Rows[j].Cells[0].Value.ToString();
                    string right = tickers.Where(t => t.Primary24 == ticker).Select(t => t.IOL).First().ToString();
                    if (left == right)
                    {
                        if (bidSize == 0)
                        {
                            grdPanel.Rows[j].Cells[4].Value = "";
                            grdPanel.Rows[j].Cells[5].Value = "";
                        }
                        else
                        {
                            grdPanel.Rows[j].Cells[4].Value = bid;
                            grdPanel.Rows[j].Cells[5].Value = bidSize;
                        }
                        refreshRatio(j);
                    }
                }
            }
            if (ticker.EndsWith("CI"))
            {
                for (int j = 0; j < grdPanel.Rows.Count; j++)
                {
                    string left = grdPanel.Rows[j].Cells[0].Value.ToString();
                    string right = tickers.Where(t => t.PrimaryCI == ticker).Select(t => t.IOL).First().ToString();

                    //if (grdPanel.Rows[j].Cells[0].Value.ToString() == tickers.Where(t => t.PrimaryCI == ticker).Select(t => t.IOL).First().ToString()) ;
                    if (left == right)
                    {
                        //ToLog("primero " + grdPanel.Rows[j].Cells[0].Value.ToString() + " segundo " + tickers.Where(t => t.PrimaryCI == ticker).Select(t => t.IOL).First().ToString());
                        if (offerSize == 0)
                        {
                            grdPanel.Rows[j].Cells[2].Value = "";
                            grdPanel.Rows[j].Cells[3].Value = "";
                        }
                        else
                        {
                            grdPanel.Rows[j].Cells[2].Value = offerSize;
                            grdPanel.Rows[j].Cells[3].Value = offer;
                        }
                        refreshRatio(j);
                    }
                }
            }
            Application.DoEvents();
        }

        private void ConfigureGrid()
        {
            grdPanel.Columns.Clear();
            grdPanel.Rows.Clear();
            grdPanel.Columns.Add("Ticker", "Ticker");
            grdPanel.Columns[0].Width = 70;
            grdPanel.Columns[0].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPanel.Columns.Add("Momento", "Momento");
            grdPanel.Columns[1].Width = 70;
            grdPanel.Columns[1].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPanel.Columns.Add("QVCI", "QVCI");
            grdPanel.Columns[2].Width = 70;
            grdPanel.Columns[2].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPanel.Columns.Add("PVCI", "PVCI");
            grdPanel.Columns[3].Width = 70;
            grdPanel.Columns[3].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPanel.Columns.Add("PC24", "PC24");
            grdPanel.Columns[4].Width = 70;
            grdPanel.Columns[4].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdPanel.Columns.Add("QC24", "QC24");
            grdPanel.Columns[5].Width = 70;
            grdPanel.Columns[5].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdPanel.Columns.Add("Ratio", "Ratio");
            grdPanel.Columns[6].Width = 70;
            grdPanel.Columns[6].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            grdPanel.RowHeadersWidth = 4;
            
            foreach (var ticker in tickersIOL)
            {
                grdPanel.Rows.Add(ticker);
            }

        }

        private async void ToLog(string s)
        {
            lbLog.Items.Add(DateTime.Now.ToLongTimeString() + ": " + s);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
        }

        private async void tmr_Tick(object sender, EventArgs e)
        {
            if (txtUsuarioIOL.Text != string.Empty && txtClaveIOL.Text != string.Empty)
            {
                LoginIOL();
            }

        }


        private async void Operar(string simbolo, string q, string PC, string PV)
            {
            int cifrasRedondeo = 0;
            LoginIOL();
            ToLog("Iniciando " + simbolo);

            double preventivoCompra = double.Parse(PC);
            if (preventivoCompra < 100)
            {
                cifrasRedondeo = 1;
            }
            preventivoCompra = Math.Round(preventivoCompra + ((preventivoCompra / 100) * 0.1), cifrasRedondeo);
            PC = preventivoCompra.ToString().Replace(",", ".");

            double preventivoVenta = double.Parse(PV);
            preventivoVenta = Math.Round(preventivoVenta - ((preventivoVenta / 100) * 0.1), cifrasRedondeo);
            PV = preventivoVenta.ToString().Replace(",", ".");

            string operacionCompra = await Comprar(simbolo, q, PC);
            if (operacionCompra != "Error")
            {
                string estadooperacion = "";
                int intentos = 24;

                for (int i = 1; i <= intentos; i++)
                {
                    ToLog("Intento de compra " + i.ToString() + " de " + simbolo);
                    estadooperacion = GetEstadoOperacion(operacionCompra);
                    if (estadooperacion == "terminada")
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                if (estadooperacion == "terminada")
                {
                    ToLog("Compra OK " + simbolo);
                    Vender(simbolo, q, PV);
                }
                else
                {
                    ToLog("Venció la compra de " + simbolo);
                    WebRequest request = WebRequest.Create(sURL + "/api/v2/operaciones/" + operacionCompra);
                    request.Method = "DELETE";
                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", bearer);

                    try
                    {
                        WebResponse response = request.GetResponse();
                    }
                    catch (Exception e)
                    {
                        ToLog(e.Message);
                    }
                }
            }
            else
            {
                ToLog("Error en compra de " + simbolo);
            }
        }
        private string GetEstadoOperacion(string idoperacion)
        {
            string response;
            response = GetResponseGET(sURL + "/api/v2/operaciones/" + idoperacion, bearer);
            if (response.Contains("Error") || response.Contains("Se exced"))
            {
                return "Error";
            }
            else
            {
                dynamic json = JObject.Parse(response);
                return json.estadoActual.Value;
            }
        }

        private async Task<string> Comprar(string simbolo, string cantidad, string precio)
        {
            if (int.Parse(cantidad)>0)
            {
                ToLog("Comprando " + cantidad + " " + simbolo + " a " + precio);
                await Task.Run(() => Application.DoEvents());
                string validez = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T17:59:59.000Z";
                string postData = "mercado=bCBA&simbolo=" + simbolo + "&cantidad=" + cantidad + "&precio=" + precio + "&validez=" + validez + "&plazo=t0";
                string response;
                response = GetResponsePOST(sURL + "/api/v2/operar/Comprar", postData);
                if (response.Contains("Error") || response.Contains("Se exced") || response.Contains("No se puede"))
                {
                    ToLog(response);
                    return "Error";
                }
                else
                {   try
                    {
                        dynamic json = JObject.Parse(response);
                        string operacion = json.numeroOperacion;
                        if (json.ok == "false")
                        {
                            return "Error";
                        }
                        else
                        {
                            return operacion;
                        }
                    }
                    catch (Exception ex)
                    {
                        ToLog(response);
                        return "Error";
                    }
                }
            }
            else
            {
                ToLog("Error de cantidad: " + cantidad);
                return "Error";
            }
        }

        private string Vender(string simbolo, string cantidad, string precio)
        {
            ToLog("Vendiendo " + cantidad + " " + simbolo + " a " + precio);
            Application.DoEvents();
            string validez = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "T17:59:59.000Z";
            string postData = "mercado=bCBA&simbolo=" + simbolo + "&cantidad=" + cantidad + "&precio=" + precio + "&validez=" + validez + "&plazo=t1";
            string response;
            response = GetResponsePOST(sURL + "/api/v2/operar/Vender", postData);
            dynamic json = JObject.Parse(response);
            string operacion = json.numeroOperacion;
            if (json.ok == "false")
            {
                return "Error";
            }
            else
            {
                return operacion;
            }
        }

        private async void refreshRatio(int i)
        {
            Boolean esBono = false;
            string PIV = "";
            string P24C = "";
            string QIV = "";
            string Q24C = "";
            int Q;
            string simbolo = grdPanel.Rows[i].Cells[0].Value.ToString();
            grdPanel.ClearSelection();
            grdPanel.Rows[i].Cells[1].Value = DateTime.Now.ToLongTimeString();
            if (chkFollow.Checked)
            {
                grdPanel.CurrentCell = grdPanel.Rows[i].Cells[1];
            }
            grdPanel.Rows[i].Selected = true;
            Application.DoEvents();
            if (grdPanel.Rows[i].Cells[3].Value != null)
            {
                PIV = grdPanel.Rows[i].Cells[3].Value.ToString();
                QIV = grdPanel.Rows[i].Cells[2].Value.ToString();
            }
            if (grdPanel.Rows[i].Cells[4].Value != null)
            {
                P24C = grdPanel.Rows[i].Cells[4].Value.ToString();
                Q24C = grdPanel.Rows[i].Cells[5].Value.ToString();
            }
            if (PIV == "" || P24C == "")
            {
                grdPanel.Rows[i].Cells[6].Value = "";
            }
            else if (PIV != "" && P24C != "")
            {
                if (simbolo == "AL30" || simbolo == "AL29" || simbolo == "AL35" || simbolo == "AE38" ||
                    simbolo == "AL41" || simbolo == "TC23" || simbolo == "TC24" || simbolo == "CO26" ||
                    simbolo == "CUAP" || simbolo == "DICP" || simbolo == "GD29" || simbolo == "GD30" ||
                    simbolo == "GD35" || simbolo == "GD38" || simbolo == "GD41" || simbolo == "GD46" ||
                    simbolo == "PARP" || simbolo == "PR13" || simbolo == "PR15" || simbolo == "TO23" ||
                    simbolo == "TO26" || simbolo == "T2X2" || simbolo == "T2X3" || simbolo == "T2X4" ||
                    simbolo == "TX22" || simbolo == "TX23" || simbolo == "TX24" || simbolo == "TX26" ||
                    simbolo == "TX28" || simbolo == "TDJ23" || simbolo == "TDL23" || simbolo == "TDS23" ||
                    simbolo == "TDF24")
                {
                    esBono = true;
                }
                else
                {
                    esBono = false;
                }

                double porcentual = Math.Round(100 - ((Convert.ToDouble(PIV) / Convert.ToDouble(P24C)) * 100), 4);
                grdPanel.Rows[i].Cells[6].Value = Math.Round(porcentual,2);

                if (porcentual > 0)
                {
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.DarkGreen;
                }
                else
                {
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                }

                double limiteBonos = umbralBonos + double.Parse(cboUmbral.Text.Replace(".", ","));
                double limiteAcciones = umbralAcciones + double.Parse(cboUmbral.Text.Replace(".", ","));

                if (
                    (esBono && (porcentual > limiteBonos))
                    ||
                    (!esBono && (porcentual > limiteAcciones))
                   )
                {
                    if (chkBeep.Checked)
                    {
                        SystemSounds.Beep.Play();
                    }
                    grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.DarkSlateBlue;
                    ToLog("Arbitraje en " + simbolo + " con ratio " + porcentual.ToString());
                    if (chkAuto.Checked)
                    {
                        string cant;
                        if (int.Parse(Q24C) < int.Parse(QIV))
                        {
                            Q = int.Parse(Q24C);
                        }
                        else
                        {
                            Q = int.Parse(QIV);
                        }
                        double presupuesto = double.Parse(txtPresupuesto.Text);
                        if (Q * double.Parse(PIV) < presupuesto)
                        {
                            cant = Q.ToString();
                        }
                        else
                        {
                            if (esBono)
                            {
                                cant = Math.Floor(presupuesto * 100 / double.Parse(PIV)).ToString();
                            }
                            else
                            {
                                cant = Math.Floor(presupuesto / double.Parse(PIV)).ToString();
                            }
                        }
                        if (int.Parse(DateTime.Now.ToString("HHmm")) >= 1105 && int.Parse(DateTime.Now.ToString("HHmm")) <= 1625)
                        {
                            Operar(simbolo, cant, PIV, P24C);
                        }
                    }
                }
                else
                {
                    //grdPanel.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                }
                Application.DoEvents();
            }
        }

        private void grbLogin_Enter(object sender, EventArgs e)
        {

        }
    }

    record Ticker(string IOL, string PrimaryCI, string Primary24);
    
}