namespace TasaBCV
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            notifyIcon1 = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            verificarTasaBCVToolStripMenuItem = new ToolStripMenuItem();
            iniciarConElSistemaToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick_1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { verificarTasaBCVToolStripMenuItem, iniciarConElSistemaToolStripMenuItem, salirToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(185, 70);
            // 
            // verificarTasaBCVToolStripMenuItem
            // 
            verificarTasaBCVToolStripMenuItem.Name = "verificarTasaBCVToolStripMenuItem";
            verificarTasaBCVToolStripMenuItem.Size = new Size(184, 22);
            verificarTasaBCVToolStripMenuItem.Text = "Verificar Tasa BCV";
            verificarTasaBCVToolStripMenuItem.Click += verificarTasaBCVToolStripMenuItem_Click_1;
            // 
            // iniciarConElSistemaToolStripMenuItem
            // 
            iniciarConElSistemaToolStripMenuItem.Name = "iniciarConElSistemaToolStripMenuItem";
            iniciarConElSistemaToolStripMenuItem.Size = new Size(184, 22);
            iniciarConElSistemaToolStripMenuItem.Text = "Iniciar con el sistema";
            iniciarConElSistemaToolStripMenuItem.Click += iniciarConElSistemaToolStripMenuItem_Click_1;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(184, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click_1;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 179);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(400, 218);
            MinimizeBox = false;
            MinimumSize = new Size(400, 218);
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tasa BCV";
            WindowState = FormWindowState.Minimized;
            Resize += Principal_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem verificarTasaBCVToolStripMenuItem;
        private ToolStripMenuItem iniciarConElSistemaToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}
