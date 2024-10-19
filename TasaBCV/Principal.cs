using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace TasaBCV
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();

            timer1.Interval = 3600000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            notifyIcon1.Visible = true;

            notifyIcon1.ContextMenuStrip = contextMenuStrip1;

            ExecuteScraping();
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
            ExecuteScraping();
        }

        private async void ExecuteScraping()
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

                    notifyIcon1.Text = $"USD: {dolar}\nEUR: {euro}\nYuan: {yuan}\nLira: {lira}\nRublo: {rublo}";

                    string balloonTipText = $"Tasas de cambio al {fechaTitulo}:\n" +
                                             $"USD: {dolar}\n" +
                                             $"EUR: {euro}\n" +
                                             $"Yuan: {yuan}\n" +
                                             $"Lira: {lira}\n" +
                                             $"Rublo: {rublo}";

                    notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
                    notifyIcon1.BalloonTipText = balloonTipText;
                    notifyIcon1.ShowBalloonTip(5000);
                }
            }
            catch (Exception ex)
            {
                notifyIcon1.Text = "Error al obtener tasas de cambio";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatToFourDecimals(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result.ToString("F4");
            }
            return "N/A";
        }

        private void notifyIcon1_DoubleClick_1(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "La aplicación está minimizada en la bandeja de tareas";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void verificarTasaBCVToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExecuteScraping();
        }

        private void SetStartup()
        {
            string exePath = Application.ExecutablePath;
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";

            using (var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyName))
            {
                if (key.GetValue("TasaBCV") != null)
                {
                    key.DeleteValue("TasaBCV");
                }

                if (iniciarConElSistemaToolStripMenuItem.Checked)
                {
                    key.SetValue("TasaBCV", exePath);
                    MessageBox.Show("La aplicación se iniciará con el sistema.", "Configuración guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La aplicación no se iniciará con el sistema.", "Configuración guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadStartupSetting()
        {
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName))
            {

                if (key.GetValue("TasaBCV") != null)
                {
                    iniciarConElSistemaToolStripMenuItem.Checked = true;
                }
                else
                {
                    iniciarConElSistemaToolStripMenuItem.Checked = false;
                }
            }
        }

        private void iniciarConElSistemaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SetStartup();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
