public partial class LoginDocument 
{
    private void Awake()
    {
        InitializeDocument();
        _button1.clicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        _titleLabel.text = "Clicked!";
    }
}