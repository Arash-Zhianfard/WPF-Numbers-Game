using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NumbersGame.PostApi;
using NumbersGame.ViewModel;

namespace NumbersGame.CardDrawer
{
    public class IdCardDrawer : BaseCardDrawer
    {
        public override ObservableCollection<PostViewModel> Draw(IEnumerable<JsonPlaceHolderResponse> jsonPlaceHolderResponses)
        {
            var joson = jsonPlaceHolderResponses.OrderBy(x => x.Id).Select(x => { return new PostViewModel() { Name = x.Id.ToString() }; });
            return CastToObservableCollection(joson);
        }
    }
}
