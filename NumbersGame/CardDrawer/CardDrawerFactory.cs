using System.Collections.Generic;

namespace NumbersGame.CardDrawer
{
    public class CardDrawerFactory
    {
        public static BaseCardDrawer GetDrawerType(CardFieldName cardFieldName)
        {
            if (cardFieldName == CardFieldName.Id)
            {
                return new UserIdCardDrawer();
            }
            else if (cardFieldName == CardFieldName.UserId)
            {
                return new IdCardDrawer();
            }
            else { throw new KeyNotFoundException(); }
        }
    }
}
