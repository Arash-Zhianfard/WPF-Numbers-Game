namespace NumbersGame.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    base.RaisePropertyChangedEvent("Name");
                }
            }
        }               
    }
}
