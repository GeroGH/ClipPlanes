using System;
using System.Drawing;
using System.Windows.Forms;
using ClipPlanes;
public enum UserOption
{
    DirectionX,
    DirectionY,
    DirectionZ,
    ClearPlanes,
    KeepPlanesAfter
}
public partial class OptionSelectionForm : Form
{
    private System.Windows.Forms.Button buttonY;
    private System.Windows.Forms.Button buttonZ;
    private System.Windows.Forms.TextBox textBox1;
    private ContextMenuStrip contextMenuStrip1;
    private System.ComponentModel.IContainer components;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button buttonClearPlanes;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private System.Windows.Forms.Button buttonX;

    public UserOption SelectedOption { get; private set; }
    public OptionSelectionForm()
    {
        this.InitializeComponent();
    }
    private void ButtonX_Click(object sender, EventArgs e)
    {
        ClipPlanesCode.Execute(UserOption.DirectionX);
    }

    private void ButtonY_Click(object sender, EventArgs e)
    {
        ClipPlanesCode.Execute(UserOption.DirectionY);
    }

    private void ButtonZ_Click(object sender, EventArgs e)
    {
        ClipPlanesCode.Execute(UserOption.DirectionZ);
    }

    private void ButtonClearPlanes_Click(object sender, EventArgs e)
    {
        ClipPlanesCode.Execute(UserOption.ClearPlanes);
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.buttonX = new System.Windows.Forms.Button();
        this.buttonY = new System.Windows.Forms.Button();
        this.buttonZ = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.buttonClearPlanes = new System.Windows.Forms.Button();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.groupBox4 = new System.Windows.Forms.GroupBox();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        this.groupBox4.SuspendLayout();
        this.SuspendLayout();
        // 
        // buttonX
        // 
        this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonX.ForeColor = System.Drawing.Color.Red;
        this.buttonX.Location = new System.Drawing.Point(6, 19);
        this.buttonX.Name = "buttonX";
        this.buttonX.Size = new System.Drawing.Size(146, 47);
        this.buttonX.TabIndex = 0;
        this.buttonX.Text = "X";
        this.buttonX.UseVisualStyleBackColor = true;
        this.buttonX.Click += new System.EventHandler(this.ButtonX_Click);
        // 
        // buttonY
        // 
        this.buttonY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonY.ForeColor = System.Drawing.Color.Green;
        this.buttonY.Location = new System.Drawing.Point(6, 72);
        this.buttonY.Name = "buttonY";
        this.buttonY.Size = new System.Drawing.Size(146, 47);
        this.buttonY.TabIndex = 1;
        this.buttonY.Text = "Y";
        this.buttonY.UseVisualStyleBackColor = true;
        this.buttonY.Click += new System.EventHandler(this.ButtonY_Click);
        // 
        // buttonZ
        // 
        this.buttonZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonZ.ForeColor = System.Drawing.Color.DodgerBlue;
        this.buttonZ.Location = new System.Drawing.Point(6, 125);
        this.buttonZ.Name = "buttonZ";
        this.buttonZ.Size = new System.Drawing.Size(146, 47);
        this.buttonZ.TabIndex = 2;
        this.buttonZ.Text = "Z";
        this.buttonZ.UseVisualStyleBackColor = true;
        this.buttonZ.Click += new System.EventHandler(this.ButtonZ_Click);
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(6, 19);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(151, 20);
        this.textBox1.TabIndex = 3;
        this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
        // 
        // contextMenuStrip1
        // 
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.textBox1);
        this.groupBox1.Location = new System.Drawing.Point(179, 16);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(163, 47);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Up distance:";
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.textBox2);
        this.groupBox2.Location = new System.Drawing.Point(179, 69);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(163, 47);
        this.groupBox2.TabIndex = 7;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Down Distance:";
        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(6, 19);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(146, 20);
        this.textBox2.TabIndex = 3;
        this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
        // 
        // buttonClearPlanes
        // 
        this.buttonClearPlanes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonClearPlanes.ForeColor = System.Drawing.Color.Black;
        this.buttonClearPlanes.Location = new System.Drawing.Point(6, 19);
        this.buttonClearPlanes.Name = "buttonClearPlanes";
        this.buttonClearPlanes.Size = new System.Drawing.Size(146, 47);
        this.buttonClearPlanes.TabIndex = 8;
        this.buttonClearPlanes.Text = "Clear Planes";
        this.buttonClearPlanes.UseVisualStyleBackColor = true;
        this.buttonClearPlanes.Click += new System.EventHandler(this.ButtonClearPlanes_Click);
        // 
        // groupBox3
        // 
        this.groupBox3.Controls.Add(this.buttonX);
        this.groupBox3.Controls.Add(this.buttonY);
        this.groupBox3.Controls.Add(this.buttonZ);
        this.groupBox3.Location = new System.Drawing.Point(12, 16);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(161, 184);
        this.groupBox3.TabIndex = 9;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "Clip Plane Direction:";
        // 
        // groupBox4
        // 
        this.groupBox4.Controls.Add(this.buttonClearPlanes);
        this.groupBox4.Location = new System.Drawing.Point(179, 122);
        this.groupBox4.Name = "groupBox4";
        this.groupBox4.Size = new System.Drawing.Size(163, 78);
        this.groupBox4.TabIndex = 10;
        this.groupBox4.TabStop = false;
        this.groupBox4.Text = "Reset:";
        // 
        // OptionSelectionForm
        // 
        this.ClientSize = new System.Drawing.Size(349, 204);
        this.Controls.Add(this.groupBox4);
        this.Controls.Add(this.groupBox3);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Location = new System.Drawing.Point(4128, 84);
        this.Name = "OptionSelectionForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.TopMost = true;
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionSelectionForm_FormClosed);
        this.Load += new System.EventHandler(this.OptionSelectionForm_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.groupBox3.ResumeLayout(false);
        this.groupBox4.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    private void OptionSelectionForm_Load(object sender, EventArgs e)
    {
        var currentScreen = Screen.FromPoint(Cursor.Position);
        var workingArea = currentScreen.WorkingArea;
        this.Location = new Point(workingArea.Right - this.Width - 50, workingArea.Top + 150);
        this.textBox1.Text = ClipPlanes.Properties.Settings.Default.UpDistance.ToString();
        this.textBox2.Text = ClipPlanes.Properties.Settings.Default.DownDistance.ToString();
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(this.textBox1.Text, out var value))
        {
            ClipPlanes.Properties.Settings.Default.UpDistance = value;
            ClipPlanes.Properties.Settings.Default.Save();
        }
    }

    private void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(this.textBox2.Text, out var value))
        {
            ClipPlanes.Properties.Settings.Default.DownDistance = value;
            ClipPlanes.Properties.Settings.Default.Save();
        }
    }

    private void OptionSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (int.TryParse(this.textBox1.Text, out var upValue))
            ClipPlanes.Properties.Settings.Default.UpDistance = upValue;

        if (int.TryParse(this.textBox2.Text, out var downValue))
            ClipPlanes.Properties.Settings.Default.DownDistance = downValue;

        ClipPlanes.Properties.Settings.Default.Save();
    }
}