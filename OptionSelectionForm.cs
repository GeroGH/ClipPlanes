using System;
using System.Drawing;
using System.Windows.Forms;
public enum UserOption
{
    DirectionX,
    DirectionY,
    DirectionZ
}
public partial class OptionSelectionForm : Form
{
    private Button buttonY;
    private Button buttonZ;
    private Button buttonX;

    public UserOption SelectedOption { get; private set; }
    public OptionSelectionForm()
    {
        this.InitializeComponent();
        this.StartPosition = FormStartPosition.Manual;
        this.Location = new Point(Cursor.Position.X - this.Width / 2, Cursor.Position.Y - this.Height / 2);
    }
    private void ButtonX_Click(object sender, EventArgs e)
    {
        this.SelectedOption = UserOption.DirectionX;
        this.Close();
    }

    private void ButtonY_Click(object sender, EventArgs e)
    {
        this.SelectedOption = UserOption.DirectionY;
        this.Close();
    }

    private void ButtonZ_Click(object sender, EventArgs e)
    {
        this.SelectedOption = UserOption.DirectionZ;
        this.Close();
    }

    private void InitializeComponent()
    {
        this.buttonX = new System.Windows.Forms.Button();
        this.buttonY = new System.Windows.Forms.Button();
        this.buttonZ = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // buttonX
        // 
        this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonX.ForeColor = System.Drawing.Color.Red;
        this.buttonX.Location = new System.Drawing.Point(12, 12);
        this.buttonX.Name = "buttonX";
        this.buttonX.Size = new System.Drawing.Size(115, 41);
        this.buttonX.TabIndex = 0;
        this.buttonX.Text = "X";
        this.buttonX.UseVisualStyleBackColor = true;
        this.buttonX.Click += new System.EventHandler(this.ButtonX_Click);
        // 
        // buttonY
        // 
        this.buttonY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonY.ForeColor = System.Drawing.Color.Green;
        this.buttonY.Location = new System.Drawing.Point(12, 65);
        this.buttonY.Name = "buttonY";
        this.buttonY.Size = new System.Drawing.Size(115, 41);
        this.buttonY.TabIndex = 1;
        this.buttonY.Text = "Y";
        this.buttonY.UseVisualStyleBackColor = true;
        this.buttonY.Click += new System.EventHandler(this.ButtonY_Click);
        // 
        // buttonZ
        // 
        this.buttonZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonZ.ForeColor = System.Drawing.Color.DodgerBlue;
        this.buttonZ.Location = new System.Drawing.Point(12, 118);
        this.buttonZ.Name = "buttonZ";
        this.buttonZ.Size = new System.Drawing.Size(115, 41);
        this.buttonZ.TabIndex = 2;
        this.buttonZ.Text = "Z";
        this.buttonZ.UseVisualStyleBackColor = true;
        this.buttonZ.Click += new System.EventHandler(this.ButtonZ_Click);
        // 
        // OptionSelectionForm
        // 
        this.ClientSize = new System.Drawing.Size(140, 167);
        this.Controls.Add(this.buttonZ);
        this.Controls.Add(this.buttonY);
        this.Controls.Add(this.buttonX);
        this.Location = new System.Drawing.Point(4128, 84);
        this.Name = "OptionSelectionForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.ResumeLayout(false);

    }
}