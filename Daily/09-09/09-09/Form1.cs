namespace _09_09;

// 1 ~ 100 사이의 랜덤한 수를 뽑고
// 플레이어가 Up/Down/Catch로 정답 맞추기

public partial class Form1 : Form
{
    private Random _random;
    private int _selectedNum;
    
    public Form1()
    {
        InitializeComponent();
        Initialize_UI();

        _random = new Random();
        _selectedNum = 0;
    }
    
    private void Initialize_UI() // UI 생성 및 수평 중앙 정렬
    {
        this.Size = new Size(400, 350);
        this.ClientSize = this.Size;
        this.AutoScaleMode = AutoScaleMode.Dpi;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.LightSlateGray;
        this.Text = "Catch the Number";
        
        Label gameScreen = new Label();
        gameScreen.Size = new Size(250, 100);
        gameScreen.BackColor = Color.Ivory;
        gameScreen.Location = new Point(75, 50);
        this.Controls.Add(gameScreen);
        
        TextBox textBox = new TextBox();
        textBox.Size = new Size(100, 50);
        textBox.Location = new Point(150, 200);
        textBox.Text = "";
        textBox.Name = "textBox";
        this.Controls.Add(textBox);
        
        Button catchButton = new Button();
        catchButton.Size = new Size(100, 50);
        catchButton.Location = new Point(150, 275);
        catchButton.Text = "정답";
        catchButton.Click += CatchButton_Click!;
        this.Controls.Add(catchButton);
    }

    private void CatchButton_Click(object sender, EventArgs e)
    {
        if (Controls["textBox"] == null)
            return;
        
        Control textBox = Controls["textBox"]!;

        if (textBox.Text == "")
            return;
        
        if (bool.TryParse(textBox.Text, out bool result) && (result == false))
            return;
        
        int catchNum = int.Parse(textBox.Text);
        
        if (_selectedNum < catchNum)
        {
            textBox.Text = "그 숫자보단 낮습니다.";
        }
        else if (_selectedNum > catchNum)
        {
            textBox.Text = "그 숫자보단 높습니다.";
        }
        else
        {
            textBox.Text = "정답!!!";
        }
    }
}