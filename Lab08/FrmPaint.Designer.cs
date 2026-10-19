#nullable disable
namespace COMP1019_Lab08_SimplePaint;

partial class FrmPaint
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlTop = new Panel();
        lblMode = new Label();
        cboMode = new ComboBox();
        lblWidth = new Label();
        nudWidth = new NumericUpDown();
        btnColor = new Button();
        pnlColorPreview = new Panel();
        btnUndo = new Button();
        btnClear = new Button();
        canvas = new DoubleBufferedPanel();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();

        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
        statusStrip1.SuspendLayout();
        SuspendLayout();

        // pnlTop
        pnlTop.Name = "pnlTop";
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Height = 52;
        pnlTop.Controls.AddRange(new Control[] {
            lblMode, cboMode, lblWidth, nudWidth, btnColor, pnlColorPreview, btnUndo, btnClear });

        lblMode.Text = "Chế độ:"; lblMode.Location = new Point(15, 17); lblMode.AutoSize = true;
        cboMode.Name = "cboMode"; cboMode.Location = new Point(85, 14); cboMode.Size = new Size(130, 28);
        cboMode.DropDownStyle = ComboBoxStyle.DropDownList; cboMode.TabIndex = 0;

        lblWidth.Text = "Độ dày:"; lblWidth.Location = new Point(235, 17); lblWidth.AutoSize = true;
        nudWidth.Name = "nudWidth"; nudWidth.Location = new Point(305, 14); nudWidth.Size = new Size(70, 27);
        nudWidth.Minimum = 1; nudWidth.Maximum = 20; nudWidth.Value = 2; nudWidth.TabIndex = 1;

        btnColor.Name = "btnColor"; btnColor.Text = "Chọn màu"; btnColor.Location = new Point(395, 11); btnColor.Size = new Size(100, 32);
        btnColor.TabIndex = 2; btnColor.Click += btnColor_Click;
        pnlColorPreview.Name = "pnlColorPreview"; pnlColorPreview.Location = new Point(503, 13);
        pnlColorPreview.Size = new Size(28, 28); pnlColorPreview.BorderStyle = BorderStyle.FixedSingle; pnlColorPreview.BackColor = Color.Black;

        btnUndo.Name = "btnUndo"; btnUndo.Text = "Undo"; btnUndo.Location = new Point(555, 11); btnUndo.Size = new Size(90, 32);
        btnUndo.TabIndex = 3; btnUndo.Click += btnUndo_Click;
        btnClear.Name = "btnClear"; btnClear.Text = "Clear"; btnClear.Location = new Point(655, 11); btnClear.Size = new Size(90, 32);
        btnClear.TabIndex = 4; btnClear.Click += btnClear_Click;

        // canvas
        canvas.Name = "canvas";
        canvas.Dock = DockStyle.Fill;
        canvas.BackColor = Color.White;
        canvas.BorderStyle = BorderStyle.FixedSingle;
        canvas.Cursor = Cursors.Cross;
        canvas.Paint += canvas_Paint;
        canvas.MouseDown += canvas_MouseDown;
        canvas.MouseMove += canvas_MouseMove;
        canvas.MouseUp += canvas_MouseUp;
        canvas.MouseLeave += canvas_MouseLeave;

        // statusStrip1
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Items.Add(lblStatus);
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Tọa độ: -";

        // FrmPaint
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 600);
        MinimumSize = new Size(800, 500);
        Name = "FrmPaint";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Simple Paint";
        Load += FrmPaint_Load;
        Controls.Add(canvas);
        Controls.Add(pnlTop);
        Controls.Add(statusStrip1);

        pnlTop.ResumeLayout(false); pnlTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
        statusStrip1.ResumeLayout(false); statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel pnlTop, pnlColorPreview;
    private Label lblMode, lblWidth;
    private ComboBox cboMode;
    private NumericUpDown nudWidth;
    private Button btnColor, btnUndo, btnClear;
    private DoubleBufferedPanel canvas;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
}
