using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Item
    {
        // gives items properties
        private string title, pickupText;
        private int weight = 1;

        #region properties

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string PickupText
        {
            get { return pickupText; }
            set { pickupText = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        #endregion

    }
}
