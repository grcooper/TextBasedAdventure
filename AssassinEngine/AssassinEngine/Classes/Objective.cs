using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    class Objective
    {
        // gives objective properties
        private string title, completionText;

        #region properties

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string CompletionText
        {
            get { return completionText; }
            set { completionText = value; }
        }

        #endregion
    }
}
