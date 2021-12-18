using System.Collections.Generic;
using System.Collections.ObjectModel;
using NumbersGame.PostApi;
using NumbersGame.ViewModel;

namespace NumbersGame.CardDrawer
{
    public abstract class BaseCardDrawer
    {
        public abstract ObservableCollection<PostViewModel> Draw(IEnumerable<JsonPlaceHolderResponse> jsonPlaceHolderResponses);
        protected ObservableCollection<PostViewModel> CastToObservableCollection(IEnumerable<PostViewModel> postViewModels)
        {
            return new ObservableCollection<PostViewModel>(postViewModels);
        }
    }
}
