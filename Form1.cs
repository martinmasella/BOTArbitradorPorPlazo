using Newtonsoft.Json.Linq;
using Primary;
using Primary.Data;
using System.Globalization;
using System.Media;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BOTArbitradorPorPlazo
{
	public partial class frmBOT : Form

	{
		const string sURL = "https://api.iolinversiones.com";
		static readonly HttpClient httpIOL = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
		const string sURLVETA = "https://api.veta.xoms.com.ar";
		const string prefijoPrimary = "MERV - XMEV - ";
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
			tickersIOL.Add("ARKQ");
			tickersIOL.Add("DIA");
			tickersIOL.Add("EEM");
			tickersIOL.Add("EWZ");
			tickersIOL.Add("IWM");
			tickersIOL.Add("QQQ");
			tickersIOL.Add("SPY");
			tickersIOL.Add("XLB");
			tickersIOL.Add("XLC");
			tickersIOL.Add("XLE");
			tickersIOL.Add("XLF");
			tickersIOL.Add("XLI");
			tickersIOL.Add("XLK");
			tickersIOL.Add("XLP");
			tickersIOL.Add("XLRE");
			tickersIOL.Add("XLU");
			tickersIOL.Add("XLV");
			tickersIOL.Add("XLY");
			tickersIOL.Add("XME");

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
			tickersIOL.Add("AO27");
			tickersIOL.Add("AO28");
			tickersIOL.Add("AO29");
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

			//tickersIOL.Add("PBA25");
			//tickersIOL.Add("TX26");
			tickersIOL.Add("TX28");
			//tickersIOL.Add("TO26");
			tickersIOL.Add("BA37D");
			tickersIOL.Add("BB37D");
			tickersIOL.Add("NDT25");
			tickersIOL.Add("PR17");
			//tickersIOL.Add("TZX26");
			tickersIOL.Add("TZX27");
			tickersIOL.Add("TZX28");
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
			tickersIOL.Add("ASML");
			tickersIOL.Add("ASML");
			tickersIOL.Add("CCL");
			tickersIOL.Add("BKNG");
			tickersIOL.Add("CVS");
			tickersIOL.Add("DAL");
			tickersIOL.Add("DELL");
			tickersIOL.Add("DOCU");
			tickersIOL.Add("ETHA");
			tickersIOL.Add("KEEL");
			tickersIOL.Add("MDLZ");
			tickersIOL.Add("LAC");
			tickersIOL.Add("LAR");
			tickersIOL.Add("LLY");
			tickersIOL.Add("LMT");
			tickersIOL.Add("MRNA");
			tickersIOL.Add("MU");
			tickersIOL.Add("PINS");
			tickersIOL.Add("PAGS");
			tickersIOL.Add("PLTR");
			tickersIOL.Add("PM");
			tickersIOL.Add("RACE");
			tickersIOL.Add("RIOT");
			tickersIOL.Add("ROKU");
			tickersIOL.Add("SCHW");
			tickersIOL.Add("SNDK");
			tickersIOL.Add("SPCE");
			tickersIOL.Add("SPCX");
			tickersIOL.Add("STLA");
			tickersIOL.Add("SWKS");
			tickersIOL.Add("TMUS");
			tickersIOL.Add("TTE");

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
			tickersIOL.Add("IBIT");
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
			tickersIOL.Add("VALE3");
			tickersIOL.Add("VIV");
			tickersIOL.Add("VOD");
			tickersIOL.Add("VRSN");
			tickersIOL.Add("VZ");
			tickersIOL.Add("WFC");
			tickersIOL.Add("WMT");
			//tickersIOL.Add("X");
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
			var entries = new[] { Entry.Bids, Entry.Offers };

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
					var body = new JObject
					{
						["grant_type"] = "password",
						["username"] = txtUsuarioIOL.Text,
						["password"] = txtClaveIOL.Text
					};
					AplicarToken(SendIOL("POST", sURL + "/auth/token", body, null, false), 300);
				}
				else
				{
					if (DateTime.Now >= expires)
					{
						var body = new JObject
						{
							["grant_type"] = "refresh_token",
							["refresh_token"] = refresh
						};
						AplicarToken(SendIOL("POST", sURL + "/auth/token", body, null, false), 100);
					}
				}
			}
			catch (Exception e)
			{
				ToLog(e.Message);
			}

		}
		private void AplicarToken(JObject json, int margen)
		{
			string error = ErrorIOL(json);
			if (error != null)
			{
				ToLog(error);
				return;
			}
			bearer = "Bearer " + (string)json["data"]["access_token"];
			expires = DateTime.Now.AddSeconds((double)json["data"]["expires_in"] - margen);
			refresh = (string)json["data"]["refresh_token"];
			ToLog(bearer);
		}

		private JObject SendIOL(string method, string url, JObject body = null, string idempotencyKey = null, bool conToken = true)
		{
			string content;
			try
			{
				using var request = new HttpRequestMessage(new HttpMethod(method), url) { Version = HttpVersion.Version20 };
				if (conToken && bearer != null)
				{
					request.Headers.TryAddWithoutValidation("Authorization", bearer);
				}
				if (idempotencyKey != null)
				{
					request.Headers.Add("X-Idempotency-Key", idempotencyKey);
				}
				if (body != null)
				{
					request.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
				}
				using HttpResponseMessage response = httpIOL.SendAsync(request).GetAwaiter().GetResult();
				content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				if (content == string.Empty && !response.IsSuccessStatusCode)
				{
					content = (int)response.StatusCode + " " + response.ReasonPhrase;
				}
			}
			catch (Exception e)
			{
				return CrearErrorIOL(e.Message);
			}

			try
			{
				return JObject.Parse(content);
			}
			catch (Exception)
			{
				return CrearErrorIOL(content);
			}
		}

		private JObject CrearErrorIOL(string mensaje)
		{
			return new JObject
			{
				["data"] = null,
				["error"] = new JObject { ["message"] = mensaje }
			};
		}

		private string ErrorIOL(JObject json)
		{
			JToken error = json["error"];
			if (error == null || error.Type == JTokenType.Null)
			{
				return null;
			}
			if (error.Type == JTokenType.Object)
			{
				return (string)error["message"] ?? error.ToString();
			}
			return error.ToString();
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
			grdPanel.Columns[0].Width = 100;
			grdPanel.Columns[0].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			grdPanel.Columns.Add("Momento", "Momento");
			grdPanel.Columns[1].Width = 100;
			grdPanel.Columns[1].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			grdPanel.Columns.Add("QVCI", "QVCI");
			grdPanel.Columns[2].Width = 100;
			grdPanel.Columns[2].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			grdPanel.Columns.Add("PVCI", "PVCI");
			grdPanel.Columns[3].Width = 90;
			grdPanel.Columns[3].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			grdPanel.Columns.Add("PC24", "PC24");
			grdPanel.Columns[4].Width = 90;
			grdPanel.Columns[4].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			grdPanel.Columns.Add("QC24", "QC24");
			grdPanel.Columns[5].Width = 100;
			grdPanel.Columns[5].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

			grdPanel.Columns.Add("Ratio", "Ratio");
			grdPanel.Columns[6].Width = 120;
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
			/*
            preventivoCompra = Math.Round(preventivoCompra + ((preventivoCompra / 100) * 0.1), cifrasRedondeo);
            PC = preventivoCompra.ToString().Replace(",", ".");
            */
			preventivoCompra = Math.Round(preventivoCompra + ((preventivoCompra / 100) * 0), cifrasRedondeo);
			PC = preventivoCompra.ToString().Replace(",", ".");


			double preventivoVenta = double.Parse(PV);
			/*
            preventivoVenta = Math.Round(preventivoVenta - ((preventivoVenta / 100) * 0.1), cifrasRedondeo);
            PV = preventivoVenta.ToString().Replace(",", ".");
            */
			preventivoVenta = Math.Round(preventivoVenta - ((preventivoVenta / 100) * 0), cifrasRedondeo);
			PV = preventivoVenta.ToString().Replace(",", ".");

			string operacionCompra = await Comprar(simbolo, q, PC);
			if (operacionCompra != "Error")
			{
				string estadooperacion = "";
				int intentos = 24;

				for (int i = 1; i <= intentos; i++)
				{
					ToLog("Intento de compra " + i.ToString() + " de " + simbolo);
					estadooperacion = GetEstadoOperacion(operacionCompra, simbolo);
					if (estadooperacion == "completed")
					{
						break;
					}
					Application.DoEvents();
					await Task.Delay(250);
				}
				if (estadooperacion == "completed")
				{
					ToLog("Compra OK " + simbolo);
					Vender(simbolo, q, PV);
				}
				else
				{
					ToLog("Venció la compra de " + simbolo);
					string errorCancelacion = ErrorIOL(SendIOL("DELETE", sURL + "/broker/orders/" + operacionCompra));
					if (errorCancelacion != null)
					{
						ToLog(errorCancelacion);
					}
				}
			}
			else
			{
				ToLog("Error en compra de " + simbolo);
			}
		}
		private string GetEstadoOperacion(string idoperacion, string simbolo)
		{
			string hoy = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
			JObject json = SendIOL("GET", sURL + "/broker/accounts/activities/operations?start_date=" + hoy + "&end_date=" + hoy + "&symbol=" + Uri.EscapeDataString(simbolo));
			string error = ErrorIOL(json);
			if (error != null)
			{
				ToLog(error);
				return "Error";
			}
			if (json["data"] is JArray operaciones)
			{
				foreach (JToken operacion in operaciones)
				{
					if ((string)operacion["order_id"] == idoperacion)
					{
						return (string)operacion["status"];
					}
				}
			}
			return "Error";
		}

		private async Task<string> Comprar(string simbolo, string cantidad, string precio)
		{
			if (int.Parse(cantidad) > 0)
			{
				ToLog("Comprando " + cantidad + " " + simbolo + " a " + precio);
				await Task.Run(() => Application.DoEvents());
				return CrearOrden("buy", simbolo, cantidad, precio, "T0");
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
			return CrearOrden("sell", simbolo, cantidad, precio, "T1");
		}

		private string CrearOrden(string side, string simbolo, string cantidad, string precio, string plazo)
		{
			try
			{
				var body = new JObject
				{
					["symbol"] = simbolo,
					["market_id"] = "BCBA",
					["side"] = side,
					["order_type"] = "limit",
					["quantity"] = int.Parse(cantidad),
					["limit_price"] = decimal.Parse(precio, CultureInfo.InvariantCulture),
					["due_date"] = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
					["settlement_term"] = plazo
				};
				JObject json = SendIOL("POST", sURL + "/broker/orders", body, Guid.NewGuid().ToString());
				string error = ErrorIOL(json);
				if (error != null)
				{
					ToLog(error);
					return "Error";
				}
				if (!(bool)json["data"]["successful_purchase"])
				{
					ToLog(json["data"].ToString());
					return "Error";
				}
				return (string)json["data"]["order_id"];
			}
			catch (Exception ex)
			{
				ToLog(ex.Message);
				return "Error";
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
					simbolo == "TO26" || simbolo == "BA37D" || simbolo == "BB37D" || simbolo == "T2X4" ||
					simbolo == "TZX26" || simbolo == "TZX27" || simbolo == "TZX27" || simbolo == "TX26" ||
					simbolo == "TX28" || simbolo == "NDT25" || simbolo == "PR17" || simbolo == "TDS23" ||
					simbolo == "TDF24")
				{
					esBono = true;
				}
				else
				{
					esBono = false;
				}

				double porcentual = Math.Round(100 - ((Convert.ToDouble(PIV) / Convert.ToDouble(P24C)) * 100), 4);
				grdPanel.Rows[i].Cells[6].Value = porcentual.ToString("0.00") + "%";
				grdPanel.Rows[i].Cells[6].Style.Font = new Font(grdPanel.Font, FontStyle.Bold);

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
						if (int.Parse(DateTime.Now.ToString("HHmm")) >= 1035 && int.Parse(DateTime.Now.ToString("HHmm")) <= 1655)
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