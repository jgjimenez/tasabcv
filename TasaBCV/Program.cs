using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace TasaBCV
{
    public static class Program
    {
        static NotifyIcon notifyIcon = new NotifyIcon();
        static ContextMenuStrip contextMenu = new ContextMenuStrip();

        static void Main()
        {

            contextMenu.Items.Add("Verificar Tasas", null, contextMenu_CheckRatesClick);

            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Text = "Tasa BCV";
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.Visible = true;

 
            ExecuteScraping();

            System.Timers.Timer timer = new System.Timers.Timer(3600000); 
            timer.Elapsed += (sender, e) => ExecuteScraping();
            timer.Start();

            Application.Run();
        }

        private static async void ExecuteScraping()
        {
            string url = "https://www.bcv.org.ve/";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url);

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(response);

                    var euroNode = doc.DocumentNode.SelectSingleNode("//div[@id='euro']//strong");
                    var yuanNode = doc.DocumentNode.SelectSingleNode("//div[@id='yuan']//strong");
                    var liraNode = doc.DocumentNode.SelectSingleNode("//div[@id='lira']//strong");
                    var rubloNode = doc.DocumentNode.SelectSingleNode("//div[@id='rublo']//strong");
                    var dolarNode = doc.DocumentNode.SelectSingleNode("//div[@id='dolar']//strong");

                    string euro = FormatToFourDecimals(euroNode?.InnerText.Trim());
                    string yuan = FormatToFourDecimals(yuanNode?.InnerText.Trim());
                    string lira = FormatToFourDecimals(liraNode?.InnerText.Trim());
                    string rublo = FormatToFourDecimals(rubloNode?.InnerText.Trim());
                    string dolar = FormatToFourDecimals(dolarNode?.InnerText.Trim());

                    var fechaNode = doc.DocumentNode.SelectSingleNode("//span[@class='date-display-single']");
                    string fechaTitulo = fechaNode?.InnerText.Trim() ?? "Tasas de cambio";

                    notifyIcon.Text = $"USD: {dolar}\nEUR: {euro}\nYuan: {yuan}\nLira: {lira}\nRublo: {rublo}";

                    string balloonTipText = $"Tasas de cambio al {fechaTitulo}:\n" +
                                             $"USD: {dolar}\n" +
                                             $"EUR: {euro}\n" +
                                             $"Yuan: {yuan}\n" +
                                             $"Lira: {lira}\n" +
                                             $"Rublo: {rublo}";

                    notifyIcon.BalloonTipIcon = ToolTipIcon.None;
                    notifyIcon.BalloonTipText = balloonTipText;
                    notifyIcon.ShowBalloonTip(5000);
                }
            }
            catch (Exception ex)
            {
                notifyIcon.Text = "Error al obtener tasas de cambio";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string FormatToFourDecimals(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result.ToString("F4");
            }
            return "N/A";
        }

        private static void contextMenu_CheckRatesClick(object sender, EventArgs e)
        {
            ExecuteScraping();
        }
    }
}