using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NumbersGame.CardDrawer;
using NumbersGame.PostApi;
using Prism.Commands;

namespace NumbersGame.ViewModel
{
    public class CardsViewModel : BaseViewModel
    {
        private IEnumerable<JsonPlaceHolderResponse> _jsonPlaceHolderResponse;
        private ObservableCollection<PostViewModel> _postViewModel;
        private CardFieldName switchFieldName = CardFieldName.Id;
        public CardsViewModel()
        {
            SwichCommand = new DelegateCommand(SwichCard);
            var JsonPlaceHolderService = new JsonPlaceHolderService();
            Task.Run(() => JsonPlaceHolderService.GetData()).ContinueWith(x =>
            {
                _jsonPlaceHolderResponse = x.Result;
                Draw(CardFieldName.Id);
            });
        }
        public ICommand SwichCommand { get; set; }
        public void Draw(CardFieldName fieldName)
        {
            //catching could be used here to not sort and cast object but for 100 post it shouldn't be issue
            //alternatively I could keep the all bussiness code here 
            //but for following SOLID principle I perefer to use static factory and template pattern 
            var cardDrawer = CardDrawerFactory.GetDrawerType(fieldName);
            PostItemsSource = cardDrawer.Draw(_jsonPlaceHolderResponse);                        
        }
        public ObservableCollection<PostViewModel> PostItemsSource
        {
            get { return _postViewModel; }
            set
            {
                _postViewModel = value;
                RaisePropertyChangedEvent("PostItemsSource");
            }
        }
        private void SwichCard()
        {
            if (switchFieldName == CardFieldName.Id)
            {
                Draw(CardFieldName.Id);
                switchFieldName = CardFieldName.UserId;
            }
            else if (switchFieldName == CardFieldName.UserId)
            {
                Draw(CardFieldName.UserId);
                switchFieldName = CardFieldName.Id;
            }
        }
    }
}
