namespace projetoForms
{
    partial class FormAlojamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listView1 = new ListView();
            button1 = new Button();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripSeparator();
            menuStrip1 = new MenuStrip();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            verReservasToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            RemoverReserva = new Button();
            label4 = new Label();
            label3 = new Label();
            listView2 = new ListView();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(72, 52);
            listView1.Name = "listView1";
            listView1.Size = new Size(662, 208);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(396, 341);
            button1.Name = "button1";
            button1.Size = new Size(137, 41);
            button1.TabIndex = 1;
            button1.Text = "Reserva";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 281);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Data Inicio";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(201, 275);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(548, 275);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(487, 281);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Data fim:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 10);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(57, 6);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { reservasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // reservasToolStripMenuItem
            // 
            reservasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verReservasToolStripMenuItem });
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(64, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            reservasToolStripMenuItem.Click += reservasToolStripMenuItem_Click;
            // 
            // verReservasToolStripMenuItem
            // 
            verReservasToolStripMenuItem.Name = "verReservasToolStripMenuItem";
            verReservasToolStripMenuItem.Size = new Size(180, 22);
            verReservasToolStripMenuItem.Text = "Ver Reservas";
            verReservasToolStripMenuItem.Click += verReservasToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(RemoverReserva);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(listView2);
            panel1.Location = new Point(39, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(728, 372);
            panel1.TabIndex = 8;
            panel1.Visible = false;
            // 
            // RemoverReserva
            // 
            RemoverReserva.Location = new Point(347, 342);
            RemoverReserva.Name = "RemoverReserva";
            RemoverReserva.Size = new Size(75, 23);
            RemoverReserva.TabIndex = 3;
            RemoverReserva.Text = "Remover";
            RemoverReserva.UseVisualStyleBackColor = true;
            RemoverReserva.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(671, 22);
            label4.Name = "label4";
            label4.Size = new Size(24, 28);
            label4.TabIndex = 2;
            label4.Text = "X";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            label3.Location = new Point(317, 22);
            label3.Name = "label3";
            label3.Size = new Size(120, 36);
            label3.TabIndex = 1;
            label3.Text = "Reservas";
            // 
            // listView2
            // 
            listView2.Location = new Point(33, 73);
            listView2.Name = "listView2";
            listView2.Size = new Size(676, 257);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // FormAlojamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(listView1);
            MainMenuStrip = menuStrip1;
            Name = "FormAlojamentos";
            Text = "FormAlojamentos";
            Load += FormAlojamentos_Load;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripMenuItem1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem verReservasToolStripMenuItem;
        private Panel panel1;
        private Label label3;
        private ListView listView2;
        private Label label4;
        private Button RemoverReserva;
    }
}